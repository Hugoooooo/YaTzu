using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace System.Application.Office
{
    public class ExcelFile
    {
        private string OleDbConnStr = "";
        private string ExcelContent = "SELECT * FROM [{0}]";

        public ExcelFile()
        {
                
        }

        public string FileName { get; set; }

        public System.Data.DataTable Read()
        {
            bool needDelete = false;
            string newFileName = "";

            if (FileName == string.Empty)
                return null;

            //HDR ( HeaDer Row )
            //  若設定值為 Yes，代表 Excel 檔中的工作表第一列是欄位名稱
            //  若設定值為 No，代表 Excel 檔中的工作表第一列就是資料了，沒有欄位名稱
            //IMEX ( IMport EXport mode )
            //  當 IMEX=0 時為「匯出模式」， Excel 檔案只能用來做「寫入」用途。
            //  當 IMEX=1 時為「匯入模式」， Excel 檔案只能用來做「讀取」用途。
            //  當 IMEX=2 時為「連結模式」，Excel 檔案「讀寫」。
            if (Path.GetExtension(FileName).ToLower().Equals(".xls"))
                OleDbConnStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{0}';Extended Properties='Excel 8.0;HDR=Yex;IMEX=1;'", FileName);
            else if (Path.GetExtension(FileName).ToLower().Equals(".xlsx"))
                OleDbConnStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties='Excel 12.0;HDR=Yex;IMEX=1;'", FileName);
            OleDbConnection conn = new OleDbConnection(OleDbConnStr);
            System.Data.DataTable dt = null;
            try
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    //嘗試再連線
                    try
                    {
                        newFileName = FileName.Replace(".xls", "@.xls").Replace(".XLS", "@.XLS");
                        Microsoft.Office.Interop.Excel.Application myExcel = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook myBook = myExcel.Workbooks.Open(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        myBook.SaveAs(newFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8, Type.Missing, Type.Missing, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        myBook.Close();
                        myExcel.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(myExcel);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(myBook);
                        myBook = null;
                        myExcel = null;
                        GC.Collect();

                        conn = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{0}';Extended Properties='Excel 8.0;HDR=Yex;IMEX=1;'", newFileName));
                        conn.Open();
                        needDelete = true;
                    }
                    catch
                    {
                        throw ex;
                    }
                }

                System.Data.DataTable dtSheetName = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "Table" }
                );
                string[] strTableNames = new string[dtSheetName.Rows.Count];
                for (int i = 0; i < dtSheetName.Rows.Count; i++)
                {
                    strTableNames[i] = dtSheetName.Rows[i]["TABLE_NAME"].ToString();
                }

                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Format(ExcelContent, strTableNames[0]), conn);
                dt = new System.Data.DataTable();
                adapter.Fill(dt);
                adapter.Dispose();
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            if (needDelete) File.Delete(newFileName);
            return dt;
        }

        public static string SaveAsCSV(string file, string titleRow)
        {
            int firstRow = Convert.ToInt32(titleRow) + 1;
            
            Microsoft.Office.Interop.Excel.Application myExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook myBook = myExcel.Workbooks.Open(
                file, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet mySheet = (Worksheet)myBook.ActiveSheet;
            for (int i = 1; i <= mySheet.Columns.Count; i++)
            {
                if (mySheet.Cells[firstRow, i].Value2 != null)
                    mySheet.Cells[firstRow, i].Value2 = string.Format(@"'{0}", mySheet.Cells[firstRow, i].Value2);
            }
            
            string newFileName = file.Replace(".xls", ".csv").Replace(".XLS", ".csv");
            myBook.SaveAs(newFileName, XlFileFormat.xlCSV, Type.Missing, Type.Missing, false, false, 
                Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, 
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            myBook.Close(false);
            myExcel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(myExcel);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(myBook);
            myBook = null;
            myExcel = null;
            GC.Collect();

            return newFileName;
        }
    }
}
