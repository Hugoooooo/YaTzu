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
        //Database �s�u�r��榡
        public static string MSSQLConnStringFormat = @"packet size=4096;Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};connect timeout=240;Min Pool Size=5;Max Pool Size=200";
        public static string OracleConnStringFormat = @"";

        /// <summary>
        /// �O�_�ݭn���Ͱ���log
        /// </summary>
        private bool _debug = false;
        /// <summary>
        /// Master DB �Ѽ�
        /// </summary>
        private DatabaseType _masterDbType = DatabaseType.MSSQL;
        private string _masterConnectionString = string.Empty;
        /// <summary>
        /// External DB �Ѽ�
        /// </summary>
        private DatabaseType _exDbType = DatabaseType.MSSQL;
        private string _exConnectionString = string.Empty;

        public Hashtable Companys = null;
        /// <summary>
        /// Detail DB �s�u�r��
        /// </summary>
        private Hashtable _detailConnectionStrings = null;
        /// <summary>
        /// Detail DB �s�u�r��
        /// </summary>
        private Hashtable _VCLogConnectionStrings = null;

        #region Static Method
        /// <summary>
        /// �ǤJSQL Server ConncetionString ���o IConnection
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
        /// ���o�t�ΥD��Ʈw�s�u
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
        /// ���o�t�βĤG�ո�Ʈw�s�u
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
        /// �t�m�@�ӷs�����Ӹ�Ʈw�s��(DbType�PMaster)
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
        /// ���oVCLog�t�θ�Ʈw�s�u
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
        /// �غc��
        /// </summary>
        /// <param name="ADBType">��Ʈw����</param>
        /// <param name="ConnectionString">�ǤJ�s����Ʈw�r��</param>
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
