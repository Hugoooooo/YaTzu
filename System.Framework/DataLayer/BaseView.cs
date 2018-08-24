#define Encrypt
using System.Framework.Common;
using System;
using System.Collections;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;

namespace System.Framework.DataLayer
{
    /// <summary>
    /// BaseView 的摘要描述。
    /// </summary>
    public class BaseView
    { 
        private IConnection _conn = null;
        private DataSet _dataObject = null;
        private bool _isBof = false;
        private bool _isEof = true;
        private int _count = 0;
        private int _currentIndex = 0;
        private string _conditions = "";
        private string _orderby = "";
        private int _topRecord = 0;
        private string _fields = "";
        private string _from = "";
        private string _fixCondition = "";
        private string _groupby = "";
        private string _commondbname = "";
        private string _countTarget = "";
        private Hashtable _conditionDictionary = new Hashtable();
        private Hashtable _orderByDictionary = new Hashtable();
        private string _symmetricKey = "";
        private string[] _encryptFields;
        //private const string EncryptFields =
        //    "RST_ID;RST_NAME;RST_SEX;RST_BIRDT;RST_PHONE1;RST_PHONE2;RST_PHONE3;RST_PHONE4;RST_MOBILE1;RST_MOBILE2;RST_ADDR1;RST_ADDR2;RST_ADDR3;RST_CREDITCARD;RST_ACCOUNT";
        //20170407 Jamie 信用卡;銀行帳戶 欄位加/解密
        private const string EncryptFields =
            "RST_CREDITCARD;RST_ACCOUNT";

        #region Protected Properties
        /// <summary>欄位列表</summary>
        protected virtual string Fields 
        {
            get { return _fields; }
            set { _fields = value; }
        }
        /// <summary>資料來源</summary>
        protected virtual string From 
        {
            get { return getFrom(); }
            set { _from = value; }
        }
        /// <summary>固定條件</summary>
        protected virtual string FixCondition 
        {
            get { return _fixCondition; }
            set { _fixCondition = value; }
        }
        /// <summary>固定群組</summary>
        protected virtual string GroupBy 
        {
            get { return _groupby; }
            set { _groupby = value; }
        }		
        /// <summary>條件參數字典</summary>
        protected virtual Hashtable ConditionDictionary
        {
            get { return _conditionDictionary; }
        }
        /// <summary>排序組合字典</summary>
        protected virtual Hashtable OrderByDictionary
        {
            get { return _orderByDictionary; }
        }
        /// <summary>計算筆數的目標</summary>
        public string CountTarget
        {
            get {return _countTarget; }
            set {_countTarget= value;}
        }
        #endregion

        #region Properties
        public bool IsDistinct = false;
        /// <summary>資料庫連接物件介面</summary>
        public IConnection Conn
        {
            get {return _conn; }
        }
        /// <summary>資料集合物件</summary>
        public virtual DataSet DataObject
        {
            get {return _dataObject;}
        }
        /// <summary></summary>
        public virtual DataRow CurrentDataRow
        {
            get { return _dataObject.Tables[0].Rows[_currentIndex]; }
        }
        /// <summary>記錄是否為第一筆之上</summary>
        public virtual bool IsBof
        {
            get {return _isBof;}
        }
        /// <summary>記錄是否為最後一筆之下</summary>
        public virtual bool IsEof
        {
            get {return _isEof;}
        }
        /// <summary>記錄總筆數</summary>
        public virtual int Count
        {
            get 
            {
                ReSetCount();
                return _count;
            }
        }
        /// <summary>目前記錄索引</summary>
        public virtual int CurrentIndex
        {
            get {return _currentIndex; }
        }
        /// <summary>目前記錄索引</summary>
        public virtual string Conditions
        {
            get {return _conditions; }
            set {_conditions = value;}
        }
        /// <summary>目前記錄索引</summary>
        public virtual string OrderBy
        {
            get {return _orderby; }
            set {_orderby = value;}
        }
        /// <summary>將要執行的SQL查詢語法</summary>
        public virtual string SQLStatement
        {
            get {return getSQLStatement(true);}
        }
        /// <summary>在SELECT時下TOP指令的筆數,0為不限</summary>
        public virtual int TopRecord
        {
            get { return _topRecord; }
            set { _topRecord = value; }
        }
        /// <summary>共用資料庫名稱</summary>
        public virtual string CommonDbName 
        {			
            set { _commondbname = value; }
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// 取得將要執行的SQL查詢語法
        /// </summary>
        /// <returns>回傳SQL查詢語法</returns>
        protected virtual string getSQLStatement(bool bHaveOrderBy)
        {
            string sWhere = "";
            if (FixCondition == "")
            {
                if (Conditions != "")
                    sWhere = "where " + Conditions;
            }
            else
            {
                if (Conditions == "")
                    sWhere = "where " + FixCondition;
                else
                    sWhere = string.Format("where ({0}) AND ({1})", FixCondition , Conditions);
            }

            return string.Format(
                "select {6}{0}{1} from {2} {3} {4} {5}",
                (_topRecord == 0 ? "" : string.Format(" TOP {0} ", _topRecord)),
                Fields,
                From, 
                sWhere,
                (GroupBy == "") ? "" : "group by " + GroupBy,
                (bHaveOrderBy) ? ((OrderBy == "") ? "" : "order by " + OrderBy) : "",
                (IsDistinct ? " DISTINCT " : ""));
        }

        /// <summary>
        /// 取得計算記錄筆數的SQL查詢語法
        /// </summary>
        /// <returns>回傳計算記錄筆數的SQL查詢語法</returns>
        /// <remarks>若有條件，則必須先設定Conditions屬性</remarks>
        protected virtual string getRecordCountSQLStatement()
        {
            if (GroupBy != "" || IsDistinct)
                return string.Format(
                    "select Count(*) from ({0}) as A{1}",
                    getSQLStatement(false), 
                    Guid.NewGuid().ToString().Substring(25, 10));
            else
            {
                string sWhere = "";
                if (FixCondition == "")
                {
                    if (Conditions != "")
                        sWhere = "where " + Conditions;
                }
                else
                {
                    if (Conditions == "")
                        sWhere = "where " + FixCondition;
                    else
                        sWhere = string.Format("where ({0}) AND ({1})", FixCondition , Conditions);
                }

                if(_countTarget=="")
                {
                    return string.Format(
                        "select Count(*) from {0} {1}", this.From, sWhere);
                }
                else
                {
                    return string.Format(
                        "select Count({0}) from {1} {2}", this.CountTarget, this.From, sWhere);
                }
            }
        }

        /// <summary>
        /// 將目前記錄中的欄位值, 設定要Field中
        /// </summary>
        protected virtual void setFieldsValue()
        {
            if (_dataObject.Tables[0].Rows.Count == 0)
            {
                _currentIndex = 0;
                return;
            }

            Type t = GetType();
            DataRow dr = _dataObject.Tables[0].Rows[_currentIndex];
            foreach(DataColumn dc in _dataObject.Tables[0].Columns)
            {
                FieldInfo fi = t.GetField(dc.ColumnName);
                if (fi != null)
                    setPropertyValue(fi, dr[dc]);
            }
            _isBof = false;
            _isEof = false;
        }
        #endregion

        #region Private method
        /// <summary>
        /// 將值放入對應的欄位
        /// </summary>
        /// <param name="fi">FieldInfo</param>
        /// <param name="data">Column Value</param>
        private void setPropertyValue(FieldInfo fi , object data)
        {
            if (fi == null)  return;
            switch (fi.FieldType.ToString())
            {
                case "System.DateTime" :
                    if (data != System.DBNull.Value)
                    {
                        if (data.ToString() != "")
                        {
                            try
                            {
#if(Encrypt)
                                if (EncryptFields.IndexOf(fi.Name.ToUpper()) > -1)
                                    fi.SetValue(this, Convert.ToDateTime(Decrypt(data.ToString())));
                                else fi.SetValue(this, Convert.ToDateTime(data.ToString()));
#else
                                fi.SetValue(this, Convert.ToDateTime(data.ToString()));
#endif
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            fi.SetValue(this, Convert.ToDateTime("0001/01/01 00:00:00"));
                        }
                    }
                    else
                        fi.SetValue(this, Convert.ToDateTime("0001/01/01 00:00:00"));
                    break;
                case "System.Double" :    
                    if (data == System.DBNull.Value)
                        fi.SetValue(this, 0);
                    else
#if(Encrypt)
                        if (EncryptFields.IndexOf(fi.Name.ToUpper()) > -1)
                            fi.SetValue(this, Convert.ToDouble(Decrypt(data.ToString())));
                        else fi.SetValue(this, Convert.ToDouble(data));
#else
                        fi.SetValue(this, Convert.ToDouble(data));
#endif
                    break;

                case "System.Int32" :
                    if (data == System.DBNull.Value)
                        fi.SetValue(this, 0);
                    else
#if(Encrypt)
                        if (EncryptFields.IndexOf(fi.Name.ToUpper()) > -1)
                            fi.SetValue(this, Convert.ToInt32(Decrypt(data.ToString())));
                        else fi.SetValue(this, Convert.ToInt32(data));
#else
                        fi.SetValue(this, Convert.ToInt32(data));
#endif
                    break;

                case "System.Boolean" :
                    if (data == System.DBNull.Value)
                        fi.SetValue(this, false);
                    else
#if(Encrypt)
                        if (EncryptFields.IndexOf(fi.Name.ToUpper()) > -1)
                            fi.SetValue(this, (Decrypt(data.ToString()) == "1"));
                        else fi.SetValue(this, (data.ToString() == "1"));
#else
                        fi.SetValue(this, (data.ToString() == "1"));
#endif
                    break;
                default :
                    if (data == System.DBNull.Value)
                        fi.SetValue(this, "");
                    else
#if(Encrypt)
                        if (EncryptFields.IndexOf(fi.Name.ToUpper()) > -1)
                            fi.SetValue(this, Decrypt(data.ToString()));
                        else fi.SetValue(this, data.ToString());
#else
                        fi.SetValue(this, data.ToString());
#endif
                    break;
            }
        }

        /// <summary>
        /// 替換SQL Statement中From子句資料庫名稱
        /// </summary>
        private string getFrom()
        {
            return _from.Replace("@", string.IsNullOrEmpty(_commondbname) ? "" : _commondbname+".dbo.");
        }

        /// <summary>
        /// 產生Audit Log
        /// </summary>
        private void Audit(bool result)
        {
            if (Conn.audit != null)
            {
                string operation = string.Empty;
                string functionId = string.Empty;
                string functionName = string.Empty;
                bool needAudit = false;

                //一般作業
                foreach (Function function in Conn.audit.Functions)
                {
                    if ((function.ViewName.ToUpper().IndexOf(this.GetType().Name.ToUpper()) > -1 || 
                         function.ViewName.ToUpper().IndexOf(this.GetType().BaseType.Name.ToUpper()) > -1) && 
                         function.Name == Conn.audit.FunctionName)
                    {
                        functionId = function.Serno;
                        functionName = function.Name;
                        needAudit = function.NeedAudit;
                        break;
                    }
                }
                if (this.GetType().Name == "Role")
                    operation = AuditAction.InqueryAutho;
                else operation = AuditAction.InqueryProcess;

                if (needAudit)
                {
                    if (!Conn.audit.AuditHistory.Exists(s => s == (functionId + operation)))
                    {
                        string fields = "ADL_SERNO, COM_SERNO, ADL_LOGINID, ADL_DATE, ADL_TIME, ADL_SYSTEMID, ADL_FUNCTIONID, ADL_FUNCTIONNAME, ADL_ACTION, ADL_STATUS, ADL_CLIENTIP, ADL_HOST, ADL_ISEXPORT";
                        string datas = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}', '0'",
                                                    Utils.GenerateSerialNum(),
                                                    Conn.audit.Company,
                                                    Conn.audit.LoginID,
                                                    Utils.DatetimeToShortDate(DateTime.Now).Replace("/", ""),
                                                    Utils.DatetimeToShortTime(DateTime.Now).Replace(":", ""),
                                                    Conn.audit.SystemID,
                                                    functionId,
                                                    functionName,
                                                    operation,
                                                    result ? AuditStatus.Success : AuditStatus.Fail,
                                                    Conn.audit.ClientIP,
                                                    Conn.audit.Host);
                        string audit = string.Format("insert into [AUDITLOG] ({0}) values ({1})", fields, datas);
                        Conn.executeNonQuery(audit);

                        Conn.audit.AuditHistory.Add(functionId + operation);
                    }
                }
            }
        }

        private string Encrypt(string value)
        {
            return Utils.AESEncrypt(value, _symmetricKey);
        }

        private string Decrypt(string encrypt)
        {
            return Utils.AESDecrypt(encrypt, _symmetricKey);
        }
        #endregion

        #region Method
        /// <summary>
        /// 取得要引用的條件
        /// </summary>
        /// <param name="AParamName">條件參數名稱</param>
        /// <param name="AParamValue">條件參數值</param>
        /// <returns>條件語法內容</returns>
        public virtual string getCondition(string AParamName, string AParamValue)
        {
            return this.getCondition(AParamName, AParamValue, true);
        }

        /// <summary>
        /// 取得要引用的條件
        /// </summary>
        /// <param name="AParamName">條件參數名稱</param>
        /// <param name="AParamValue">條件參數值</param>
        /// <returns>條件語法內容</returns>
        public virtual string getCondition(string AParamName, string AParamValue, bool bReplaceKeyword)
        {
            if (AParamName != null && ConditionDictionary.ContainsKey(AParamName))
            {
                if ((AParamName == "MingTai") ||
                    (AParamName == "Aegon") ||
                    (AParamName == "PcaLife") ||
                    (AParamName == "EmployeeSerNoTree") ||
                    (AParamName == "EmployeeTree") ||
                    (AParamName == "DBGSernoNotIn") ||
                    (AParamName == "DBGSernoIn") ||
                    (AParamName == "RTATree") ||
                    (AParamName == "CAPTree") ||
                    (AParamName == "RstStatusIn") ||
                    (AParamName == "MutileTree") ||
                    (AParamName == "JobIDIn") ||
                    (AParamName == "CampaignSerNoIn") ||
                    (AParamName == "EmployeeBossTree") ||
                    (AParamName == "CAPTree") ||
                    (AParamName == "RTACategory2In") ||
                    (AParamName == "RosterAliasSerNoIn") ||
                    (AParamName == "StatusIn"))
                {
#if(Encrypt)

                    foreach (string field in _encryptFields)
                    {
                        if (ConditionDictionary[AParamName].ToString().IndexOf(field) > -1)
                            return ((string)ConditionDictionary[AParamName]).Replace("?", AParamValue == null ? "" : Encrypt(AParamValue));
                    }
                    return ((string)ConditionDictionary[AParamName]).Replace("?", AParamValue == null ? "" : AParamValue);
#else
                    return ((string)ConditionDictionary[AParamName]).Replace("?", AParamValue == null ? "" : AParamValue);
#endif
                }
                else
                {
#if(Encrypt)
                    foreach (string field in _encryptFields)
                    {
                        if (ConditionDictionary[AParamName].ToString().IndexOf(field) > -1)
                            return ((string)ConditionDictionary[AParamName]).Replace("?", AParamValue == null ? "" : Encrypt(AParamValue));
                    }
                    return ((string)ConditionDictionary[AParamName]).Replace("?", AParamValue == null ? "" : AParamValue);
#else
                    return ((string)ConditionDictionary[AParamName]).Replace("?", AParamValue == null ? "" : ((bReplaceKeyword) ? AParamValue.Replace("'" , "''") : AParamValue));
#endif
                }
            }
            else
                return "";
        }

        /// <summary>
        /// 取得要引用的排序選項
        /// </summary>
        /// <param name="AOptionName">排序選項名稱</param>
        /// <returns>排序欄位內容</returns>
        public virtual string getOptionOrderBy(string AOptionName)
        {
            if (OrderByDictionary.ContainsKey(AOptionName))
                return (string)OrderByDictionary[AOptionName];
            else
                return "";
        }
       
        /// <summary>
        /// 計算頁數
        /// </summary>
        /// <param name="APageSize">每頁筆數</param>
        /// <returns>頁數</returns>
        /// <remarks>若有條件，則必須先設定Conditions屬性</remarks>
        public virtual int calculatePage(int APageSize)
        {
            _count = calculateCount();
            if (_count == 0) return 0;

            if(APageSize>0)
            {
                if (_count % APageSize != 0)
                    return (_count / APageSize) + 1;
                else
                    return _count / APageSize;
            }
            else return 1;
        }

        public virtual void ReSetCount()
        {
            if (_dataObject == null) return;

            _count = _dataObject.Tables[0].Rows.Count;
        }
    
        /// <summary>
        /// 計算頁數
        /// </summary>
        /// <param name="APageSize">每頁筆數</param>
        /// <returns>頁數</returns>
        /// <remarks>若有條件，則必須先設定Conditions屬性</remarks>
        public virtual int calculateCount()
        {
            _count = (int)(Conn.executeScalar(getRecordCountSQLStatement()));
            return Count;
        }
    
        /// <summary>
        /// 將Cursor移到第一筆，在執行load後，才能執行
        /// </summary>
        public virtual void first()
        {
            if (_dataObject == null) return;

            _currentIndex = 0; 
            setFieldsValue();
        }
               
        /// <summary>
        /// 將Cursor移到上一筆，在執行load後，才能執行
        /// </summary>
        public virtual void prev()
        {
            if (_dataObject == null) return;
            if (IsBof) return;

            _currentIndex --;          
            if (_currentIndex == -1)
            {
                _currentIndex++;
                _isBof = true;
                return;
            }       
            setFieldsValue();
        }
      
        /// <summary>
        /// 將Cursor移到下一筆，在執行load後，才能執行
        /// </summary>
        public virtual void next()
        {
            if (_dataObject == null) return;
            if (IsEof) return;

            _currentIndex ++;
            if (_currentIndex == _dataObject.Tables[0].Rows.Count)
            {
                _currentIndex--;
                _isEof = true;
                return;
            }
            setFieldsValue();
        }
      
        /// <summary>
        /// 將Cursor移到最後一筆，在執行load後，才能執行
        /// </summary>
        public virtual void last()
        {
            if (_dataObject == null) return;

            _currentIndex = _dataObject.Tables[0].Rows.Count - 1;
            setFieldsValue();
        }
                    
        /// <summary>
        /// 執行SQL Statement,在執行Load前必須先傳入Command物件
        /// 若有條件，則必須先傳入Parameters
        /// </summary>
        public virtual bool load()
        {
            _dataObject = ((IConnection)_conn).fillDataSet(SQLStatement);
            _count = _dataObject.Tables[0].Rows.Count;
            // 只要執行過一次,就把Top設為0
            _topRecord = 0;
            if (_count <= 0)
            {
                _isBof = true;
                _isEof = true;

                Audit(false);
                return false;
            }
            else
            {
                first();

                Audit(true);
                return true;
            }
        }
      
        /// <summary>
        /// 執行SQL Statement,傳入目前頁次及每頁筆數
        /// Load on demand
        /// </summary>
        /// <param name="APageNo">目前頁次</param>
        /// <param name="APageSize">每頁筆數</param>
        public virtual bool load(int APageNo, int APageSize)
        {
            int startReocrd = 0;
            if (APageNo > 0)
                startReocrd = (APageNo - 1) * APageSize;

            _dataObject = ((IConnection)_conn).fillDataSet(SQLStatement, startReocrd, APageSize);
            _count = _dataObject.Tables[0].Rows.Count;
            if (_count <= 0)
            {
                _isBof = true;
                _isEof = true;

                Audit(false);
                return false;
            }
            else
            {
                first();

                Audit(true);
                return true;
            }
        }
        public void setFields(string fields)
        {
            _fields = fields;
        }
        public void replaceFrom(string sFrom)
        {
            _from = _from.Replace("{0}", sFrom);
        }
        #endregion

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="AConn">資料庫連接物件介面</param>
        public BaseView(IConnection AConn)
        {
            _conn = AConn;
#if(Encrypt)
            _encryptFields = EncryptFields.Split(';');
            if (_conn != null)
                _symmetricKey = Conn.executeScalar("SELECT Key_GUID('xKey')").ToString().ToUpper();
#endif
        }
    }
}
