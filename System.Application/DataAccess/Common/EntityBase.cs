using System;
using System.Reflection;
using System.Application.Common;

namespace System.Application.DataAccess.Common
{
    public abstract class EntityBase : IDataObject
    {
        public EntityBase()
        {
        }

        #region Property
        public ObjectType Type
        {
            get
            {
                return ObjectType.Table;
            }
        }

        private string description;
        public string Description
        {
            get
            {
                description = "";
                foreach (object attribute in this.GetType().GetCustomAttributes(true))
                {
                    if (attribute.GetType() == typeof(TableAttribute))
                    {
                        description = (attribute as TableAttribute).Desciption;
                        break;
                    }
                }
                return description;
            }
        }

        private string mappingTable;
        public string Mapping
        {
            get
            {
                mappingTable = "";
                foreach (object attribute in this.GetType().GetCustomAttributes(true))
                {
                    if (attribute.GetType() == typeof(TableAttribute))
                    {
                        mappingTable = (attribute as TableAttribute).MappingName;
                        break;
                    }
                }
                return mappingTable;
            }
        }

        private string fields;
        public string Fields
        {
            get
            {
                fields = "";
                foreach (PropertyInfo property in this.GetType().GetProperties())
                {
                    foreach (Attribute attribute in Attribute.GetCustomAttributes(property))
                    {
                        if ((attribute.GetType() == typeof(ColumnAttribute)) && ((attribute as ColumnAttribute).IsMapping))
                        {
                            if (!string.IsNullOrEmpty((attribute as ColumnAttribute).MappingName))
                                fields += (string.IsNullOrEmpty(fields) ? "" : ", ") + (attribute as ColumnAttribute).MappingName;
                            else fields += (string.IsNullOrEmpty(fields) ? "" : ", ") + property.Name;
                        }
                    }
                }
                return fields;
            }
        }

        private bool needAudit;
        public bool NeedAudit
        {
            get
            {
                needAudit = false;
                foreach (object attribute in this.GetType().GetCustomAttributes(true))
                {
                    if (attribute.GetType() == typeof(TableAttribute))
                    {
                        needAudit = (attribute as TableAttribute).IsAudit;
                        break;
                    }
                }
                return needAudit;
            }
        }

        public string InsertValues
        {
            get
            {
                string values = "";
                foreach (PropertyInfo property in this.GetType().GetProperties())
                {
                    foreach (Attribute attribute in Attribute.GetCustomAttributes(property))
                    {
                        if ((attribute.GetType() == typeof(ColumnAttribute)) && ((attribute as ColumnAttribute).IsMapping))
                            values += (string.IsNullOrEmpty(values) ? "" : ", ") + SetValueString(property.GetValue(this, null));
                    }
                }
                return values;
            }
        }

        public string UpdateContent
        {
            get
            {
                string contents = "";
                foreach (PropertyInfo property in this.GetType().GetProperties())
                {
                    foreach (Attribute attribute in Attribute.GetCustomAttributes(property))
                    {
                        if ((attribute.GetType() == typeof(ColumnAttribute)) && ((attribute as ColumnAttribute).IsMapping) && (!(attribute as ColumnAttribute).IsKey))
                        {
                            if(SetValueString(property.GetValue(this, null)) != "null")
                            {
                                if (!string.IsNullOrEmpty((attribute as ColumnAttribute).MappingName))
                                    contents += (string.IsNullOrEmpty(contents) ? "" : ", ") + (attribute as ColumnAttribute).MappingName + "=" + SetValueString(property.GetValue(this, null));
                                else contents += (string.IsNullOrEmpty(contents) ? "" : ", ") + property.Name + "=" + SetValueString(property.GetValue(this, null));
                            }
                        }
                    }
                }
                return contents;
            }
        }

        public string KeyCondition
        {
            get
            {
                string conditions = "";
                foreach (PropertyInfo property in this.GetType().GetProperties())
                {
                    foreach (Attribute attribute in Attribute.GetCustomAttributes(property))
                    {
                        if ((attribute.GetType() == typeof(ColumnAttribute)) && ((attribute as ColumnAttribute).IsMapping) && ((attribute as ColumnAttribute).IsKey))
                        {
                            if (!string.IsNullOrEmpty((attribute as ColumnAttribute).MappingName))
                                conditions += (string.IsNullOrEmpty(conditions) ? "" : " AND ") + (attribute as ColumnAttribute).MappingName + "=" + SetValueString(property.GetValue(this, null));
                            else conditions += (string.IsNullOrEmpty(conditions) ? "" : " AND ") + property.Name + "=" + SetValueString(property.GetValue(this, null));
                        }
                    }
                }
                return conditions;
            }
        }
        #endregion

        #region private Method
        /// <summary>
        /// 判斷屬性型別,決定是否加單引號
        /// </summary>
        /// <param name="column">PropertyInfo</param>
        /// <returns>值字串</returns>
        private string SetValueString(object columnValue)
        {
            string result = "";
            if (columnValue == null)
                result = "''";
            else
            {
                switch (columnValue.GetType().ToString())
                {
                    case "System.DateTime":
                        DateTime dt = (DateTime)columnValue;
                        if (dt.Year == 1)
                            result = "null";
                        else result = string.Format("N'{0}/{1}/{2} {3}:{4}:{5}'",
                                My.PatchZero(4, dt.Year),
                                My.PatchZero(2, dt.Month),
                                My.PatchZero(2, dt.Day),
                                My.PatchZero(2, dt.Hour),
                                My.PatchZero(2, dt.Minute),
                                My.PatchZero(2, dt.Second));
                        break;
                    case "System.Double":
                        result = columnValue.ToString();
                        break;
                    case "System.Int32":
                        result = columnValue.ToString();
                        break;
                    case "System.Boolean":
                        result = (bool)columnValue ? "N'Y'" : "N'N'";
                        break;
                    default:
                        result = string.Format("N'{0}'", columnValue.ToString().Replace("'", "''"));
                        break;
                }
            }
            return result;
        }
        #endregion

        #region public Method
        public string GetKeyCondition(string keyValue)
        {
            string conditions = "";
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                foreach (Attribute attribute in Attribute.GetCustomAttributes(property))
                {
                    if ((attribute.GetType() == typeof(ColumnAttribute)) && ((attribute as ColumnAttribute).IsMapping) && ((attribute as ColumnAttribute).IsKey))
                    {
                        if (!string.IsNullOrEmpty((attribute as ColumnAttribute).MappingName))
                            conditions += (string.IsNullOrEmpty(conditions) ? "" : " AND ") + (attribute as ColumnAttribute).MappingName + "=" + SetValueString(keyValue);
                        else conditions += (string.IsNullOrEmpty(conditions) ? "" : " AND ") + property.Name + "=" + SetValueString(keyValue);
                    }
                }
            }
            return conditions;
        }
        public bool CanRecover()
        {
            bool result = false;
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                foreach (Attribute attribute in Attribute.GetCustomAttributes(property))
                {
                    if ((attribute.GetType() == typeof(ColumnAttribute)) && ((attribute as ColumnAttribute).IsRecover))
                        result = property.GetValue(this, null).ToString() == "Y";
                }
            }
            return result;
        }
        public void SetRecover(string value)
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                foreach (Attribute attribute in Attribute.GetCustomAttributes(property))
                {
                    if ((attribute.GetType() == typeof(ColumnAttribute)) && ((attribute as ColumnAttribute).IsRecover))
                        property.SetValue(this, value, null);
                }
            }
        }
        #endregion
    }
}
