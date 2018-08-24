using System.IO;
using System.Application.DataAccess.Common;

namespace System.Application.DataAccess.Provider.Excel
{
    public class ExcelConnecitonFactory : IConnectionFactory
    {
        //2003
        private const string Excel11ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{0}';Extended Properties='Excel 8.0;HDR=Yex;IMEX=1;'";
        //2007
        private const string Excel12ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties='Excel 12.0;HDR=Yex;IMEX=1;'";

        public static string GenConnectionString(string excelFileName)
        {
            if (Path.GetExtension(excelFileName).ToLower().Equals(".xls"))
                return string.Format(Excel11ConnectionString, excelFileName);
            else if (Path.GetExtension(excelFileName).ToLower().Equals(".xlsx"))
                return string.Format(Excel12ConnectionString, excelFileName);
            else return "";
        }

        public IConnection CreateConneciton(string connectionString)
        {
            return new ExcelConnection(connectionString);
        }
    }
}
