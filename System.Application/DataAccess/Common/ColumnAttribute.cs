using System;

namespace System.Application.DataAccess.Common
{
    public enum FieldType
    {
        charType,
        datetimeType,
        decimalType,
        intType,
        varcharType,
        ncharType,
        nvarcharType
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute: System.Attribute
    {
        public ColumnAttribute(string description)
        {
            Description = description;
        }
        //是否對應儲存媒體
        private bool _isMapping = true;
        public bool IsMapping
        {
            get { return _isMapping; }
            set { _isMapping = value; }
        }
        //是否為主索引鍵
        private bool _isKey = false;
        public bool IsKey
        {
            get { return _isKey; }
            set { _isKey = value; }
        }        
        //是否為外索引鍵
        private bool _isForeignKey = false;
        public bool IsForeignKey
        {
            get { return _isForeignKey; }
            set { _isForeignKey = value; }
        }
        //是否為還原索引鍵
        private bool _isRecover = false;
        public bool IsRecover
        {
            get { return _isRecover; }
            set { _isRecover = value; }
        }
        //對應欄位名稱
        public string MappingName { get; set; }
        //對應欄位型別
        public FieldType MappingType { get; set; }
        //最大資料長度
        public int MaxLength { get; set; }
        //資料初始值
        public string InitialValue { get; set; }
        //欄位說明
        public string Description { get; set; }
        //是否需要稽查
        private bool _isAudit = false;
        public bool IsAudit
        {
            get { return _isAudit; }
            set { _isAudit = value; }
        }
        //是否需要匯出CSV
        private bool _isExport = false;
        public bool IsExport
        {
            get { return _isExport; }
            set { _isExport = value; }
        }
        //是否需要轉換角色序號
        private bool _isRConvert = false;
        public bool IsRConvert
        {
            get { return _isRConvert; }
            set { _isRConvert = value; }
        }
    }
}
