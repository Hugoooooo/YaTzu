using System;
using System.Reflection;

namespace System.Application.DataAccess.Common
{
    public abstract class ViewBase : IDataObject
    {
        public ViewBase()
        {

        }

        #region Property
        public ObjectType Type
        {
            get
            {
                return ObjectType.View;
            }
        }

        private string mappingView;
        public string Mapping
        {
            get
            {
                MemberInfo member = this.GetType();
                foreach (object attribute in member.GetCustomAttributes(true))
                {
                    if (attribute.GetType() == typeof(TableAttribute))
                    {
                        mappingView = (attribute as TableAttribute).MappingName;
                        break;
                    }
                }
                return mappingView;
            }
        }

        private string fields;
        public string Fields
        {
            get
            {
                fields = "";
                PropertyInfo[] properties = this.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    foreach (Attribute attribute in Attribute.GetCustomAttributes(property))
                    {
                        if ((attribute.GetType() == typeof(ColumnAttribute)) && ((attribute as ColumnAttribute).IsMapping))
                        {
                            if (!string.IsNullOrEmpty((attribute as ColumnAttribute).MappingName))
                                fields += (string.IsNullOrEmpty(fields) ? "" : ", ") + (attribute as ColumnAttribute).MappingName;
                            else
                                fields += (string.IsNullOrEmpty(fields) ? "" : ", ") + property.Name;
                        }
                    }
                }
                return fields;
            }
        }
        #endregion

        #region private Method
        #endregion

        #region public Method
        #endregion
    }
}
