using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Reflection;
using System.Collections;

namespace System.Framework.DataLayer
{
    /// <summary>
    /// XMLAdapter 的摘要描述。
    /// </summary>
    public class XMLAdapter
    {
        #region Privates
        //private char _stage = '¨';        // ASCII 168
        private string _defaultPath = "";
        private ArrayList _dataCollection;

        private string innerXml;
        DataTable table;
        #endregion

        #region Properties
        public virtual string DefaultPath
        {
            get {return _defaultPath;}
            set  {  _defaultPath = value; }
        }

        public ArrayList DataCollection
        {                                                
            get 
            {
                _dataCollection = new ArrayList();
                           
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(innerXml);
                Type t = this.GetType();
                    
                foreach(XmlNode aNode in xmlDoc.SelectNodes(DefaultPath))
                {      
                    string stemp = "";    
                    foreach(FieldInfo fi in t.GetFields())
                    {
                        if (aNode.Attributes[fi.Name] == null) break;
                        if (stemp == "")
                            stemp = aNode.Attributes[fi.Name].Value;
                        else
                            stemp += aNode.Attributes[fi.Name].Value;
                    }
                    _dataCollection.Add(stemp);
                }
                return _dataCollection;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 將XML的資料轉換成DataSet ,專門給DropDownList.DataBind用的
        /// </summary>
        /// <param name="FieldItem">欄位陣列</param>
        /// <returns>DataSet</returns>
        public DataTable GenerateDataSource(string[] FieldItem)
        {       
            if (this.innerXml == "") return null;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(innerXml);

            table = new DataTable("DataSource");
            foreach(string field in FieldItem)
               table.Columns.Add(new System.Data.DataColumn(field,Type.GetType("System.String")));
                                                                 
            DataRow aRow;
                   
            foreach(XmlNode aNode in xmlDoc.SelectNodes(DefaultPath))
            {                                                
                aRow = table.NewRow();
                for(int j=0;j<FieldItem.Length;j++)
                {
                    aRow[j] = aNode.Attributes[FieldItem[j]].Value;
                }

                table.Rows.Add(aRow);     
            }

            return table;
        }

        /// <summary>
        /// 將DataSet的指標，移到該筆記錄
        /// </summary>
        /// <param name="FieldName">欄位</param>
        /// <param name="aValue">值</param>
        public void Locate(string FieldName, string aValue)
        {                                                      
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(innerXml);

            foreach(XmlNode aNode in xmlDoc.SelectNodes(DefaultPath))
            {                   
                if (aValue == aNode.Attributes[FieldName].Value)
                {
                    RetrieveData(aNode);
                    return;
                }
            }
        }

        /// <summary>
        /// 將DataRow的資料，重新放到對應的欄位
        /// </summary>
        /// <param name="aRow">DataRow</param>
        private void RetrieveData(XmlNode aNode)
        {
            Type t = this.GetType();
            foreach(FieldInfo fi in t.GetFields())
            {
                fi.SetValue(this,aNode.Attributes[fi.Name].Value);
            }
        }
        #endregion

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="xml">載入的資料</param>
        public XMLAdapter(string xml)
        {
            innerXml = xml;
        }                     
    }
}
