using System;
using System.Collections;

namespace System.Framework.DataLayer
{
    public enum DatabaseType
    {
        MSSQL , Oracle
    }

    public class CompanyClass
    {
        public string DatabaseName = "";
        public string CompanySerno = "";
        public string ConnectionString = "";

        public CompanyClass(string _CompanySerno , string _DatabaseName , string _ConnectionString)
        {
            DatabaseName = _DatabaseName;
            CompanySerno = _CompanySerno;
            ConnectionString = _ConnectionString;
        }
    }

    public class DataManager
    {
        //Database 連線字串格式
        public static string MSSQLConnStringFormat = @"packet size=4096;Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};connect timeout=240;Min Pool Size=5;Max Pool Size=200";
        public static string OracleConnStringFormat = @"";

        /// <summary>
        /// 是否需要產生除錯log
        /// </summary>
        private bool _debug = false;
        /// <summary>
        /// Master DB 參數
        /// </summary>
        private DatabaseType _masterDbType = DatabaseType.MSSQL;
        private string _masterConnectionString = string.Empty;
        /// <summary>
        /// External DB 參數
        /// </summary>
        private DatabaseType _exDbType = DatabaseType.MSSQL;
        private string _exConnectionString = string.Empty;

        public Hashtable Companys = null;
        /// <summary>
        /// Detail DB 連線字串
        /// </summary>
        private Hashtable _detailConnectionStrings = null;
        /// <summary>
        /// Detail DB 連線字串
        /// </summary>
        private Hashtable _VCLogConnectionStrings = null;

        #region Static Method
        /// <summary>
        /// 傳入SQL Server ConncetionString 取得 IConnection
        /// </summary>
        /// <param name="connstr"></param>
        /// <returns>IConnection</returns>
        public static IConnection AllocateConnection(string connStr)
        {
            return new SQLConnection(connStr, false);
        }
        #endregion

        #region Method
        /// <summary>
        /// 取得系統主資料庫連線
        /// </summary>
        /// <returns>IConnection</returns>
        public virtual IConnection AllocateMasterConnection()
        {
            IConnection conn = null;
            if (string.IsNullOrEmpty(_masterConnectionString)) return conn;

            switch (_masterDbType)
            {
                case DatabaseType.MSSQL:
                    conn = new SQLConnection(_masterConnectionString, _debug);
                    break;
            }
            return conn;
        }
        /// <summary>
        /// 取得系統第二組資料庫連線
        /// </summary>
        /// <returns>IConnection</returns>
        public virtual IConnection AllocateExternalConnection()
        {
            IConnection conn = null;
            if (string.IsNullOrEmpty(_exConnectionString)) return conn;

            switch (_exDbType)
            {
                case DatabaseType.MSSQL:
                    conn = new SQLConnection(_exConnectionString, _debug);
                    break;
            }
            return conn;
        }
        /// <summary>
        /// 配置一個新的明細資料庫連接(DbType同Master)
        /// </summary>
        /// <returns>IConnection</returns>
        public virtual IConnection AllocateNewConnection(string ACompany, Audit audit = null)
        {
            IConnection conn = null;
            if (!_detailConnectionStrings.ContainsKey(ACompany.ToUpper())) return conn;

            switch (_masterDbType)
            {
                case DatabaseType.MSSQL:
                    conn = new SQLConnection((string)_detailConnectionStrings[ACompany.ToUpper()], _debug);
                    conn.audit = audit;
                    break;
            }
            return conn;
        }
        /// <summary>
        /// 取得VCLog系統資料庫連線
        /// </summary>
        /// <returns>IConnection</returns>
        public virtual IConnection AllocateVCLogConnection(string ACompany, Audit audit = null)
        {
            IConnection conn = null;
            if (!_VCLogConnectionStrings.ContainsKey(ACompany.ToUpper())) return conn;

            switch (_masterDbType)
            {
                case DatabaseType.MSSQL:
                    conn = new SQLConnection((string)_VCLogConnectionStrings[ACompany.ToUpper()], _debug);
                    conn.audit = audit;
                    break;
            }
            return conn;
        }

        public void SetExternalConnection(DatabaseType ADBType, string AConnectionString)
        {
            _exDbType = ADBType;
            _exConnectionString = AConnectionString;
        }

        public void SetCompanyConnection(string ACompany, string AConnectionString)
        {
            _detailConnectionStrings[ACompany.ToUpper()] = AConnectionString;
        }
        public void SetVCLogConnection(string ACompany, string AConnectionString)
        {
            _VCLogConnectionStrings[ACompany.ToUpper()] = AConnectionString;
        }
        #endregion

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="ADBType">資料庫類型</param>
        /// <param name="ConnectionString">傳入連接資料庫字串</param>
        public DataManager(DatabaseType ADBType, string AConnectionString, bool ADebug = false)
        {
            _detailConnectionStrings = new Hashtable();
            _VCLogConnectionStrings = new Hashtable();

            _masterDbType = ADBType;
            _masterConnectionString = AConnectionString;
            _debug = ADebug;
        } 
    }
}
