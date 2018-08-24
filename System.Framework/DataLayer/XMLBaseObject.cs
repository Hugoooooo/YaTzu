using System;      
using System.IO;
using System.Xml;
using System.Reflection;
using System.Collections;

namespace System.Framework.DataLayer
{
    /// <summary>
    /// XMLBaseObject ���K�n�y�z�C
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
        /// �غc��
        /// </summary>
        /// <param name="xml">���J�����</param>
        public XMLBaseObject(string xml)
        {
            innerXml = xml;
        }   

        /// <summary>
        /// Binding Xml����ƨ���������
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
