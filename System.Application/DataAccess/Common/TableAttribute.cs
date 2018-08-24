using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Application.DataAccess.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute: Attribute
    {
        public TableAttribute(string description)
        {
            Desciption = description;
        }
        //資料表名稱
        public string MappingName { get; set; }
        //資料表說明
        public string Desciption { get; set; }
        //是否需要稽查
        private bool _isAudit = false;
        public bool IsAudit
        {
            get { return _isAudit; }
            set { _isAudit = value; }
        }
    }
}
