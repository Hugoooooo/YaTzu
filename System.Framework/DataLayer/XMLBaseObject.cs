using System;      
using System.IO;
using System.Xml;
using System.Reflection;
using System.Collections;

namespace System.Framework.DataLayer
{
    /// <summary>
    /// XMLBaseObject 的摘要描述。
    /// </summary>
    public class XMLBaseObject
    {
        #region Privates
        private string _defaultPath = "";
        private string innerXml;
        #endregion

        #region Properties
        public virtual string DefaultPath
        {
            get {return _defaultPath;}
            set  {  _defaultPath = value; }
        }
        #endregion

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="xml">載入的資料</param>
        public XMLBaseObject(string xml)
        {
            innerXml = xml;
        }   

        /// <summary>
        /// Binding Xml的資料到對應的欄位
        /// </summary>
        public void BindXmlData()
        {                         
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(innerXml);

            XmlNodeList Nodes = xmlDoc.SelectNodes(DefaultPath);

            foreach(XmlNode aNode in Nodes)
            {
                for(int i=0; i<aNode.Attributes.Count; i++)
                {
                    SetToField(aNode.Attributes[i].Name, aNode.Attributes[i].Value);
                }
            }
        }

        private void SetToField(string fieldName , string fieldValue)
        {
            Type t = this.GetType();
            foreach(FieldInfo fi in t.GetFields())
            {
                if (fi.Name == fieldName)
                    fi.SetValue(this,fieldValue);
            }
        }
    }
}
