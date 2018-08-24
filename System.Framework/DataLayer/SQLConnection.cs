using log4net;
using log4net.Config;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace System.Framework.DataLayer
{
    /// <summary>
    /// Connection : SQL Server資料庫連接。
    /// </summary>
    public class SQLConnection : IConnection
    {
        private static readonly ILog TxtLog = LogManager.GetLogger("TMPro");

        private bool _debug = false;
        private SqlConnection _conn;
        private SqlTransaction _trans = null;
        private string _connectionString = string.Empty;
        private int timeout = 0;
        private Stopwatch sw = null;

        public Audit audit { get; set; }

        #region Private Methods
        private void StartTiming()
        {
            sw.Reset();
            sw.Start();
        }
        private void EndTiming(string statement)
        {
            sw.Stop();
            TimeSpan ts = TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds);
            string processingTime = string.Format("{0}.{1:D3}秒", (ts.Minutes * 60 + ts.Seconds), ts.Milliseconds);
            if (statement.IndexOf("Key_GUID") == -1)
                TxtLog.Debug(string.Format("Processing time : [{0}]\r\n  {1}\r\n", processingTime, statement));
        }
        #endregion

        #region IConnection Methods
        /// <summary>
        /// 取得資料庫類型
        /// </summary>
        /// <returns>資料庫類型</returns>
        public DatabaseType getDatabaseType()
        {
            return DatabaseType.MSSQL;
        }

        /// <summary>
        /// 執行沒有回傳RecordSet的指令
        /// </summary>
        /// <param name="ASQLCommand"></param>
        /// <returns>成功回傳異動筆數,-1表示異動失敗</returns>
        public int executeNonQuery(string ASQLCommand)
        {
            try
            {
                if (_debug) StartTiming();
                if ((_conn.State == ConnectionState.Closed) && (_trans == null)) 
                    _conn.Open();

                SqlCommand cmd;
                if (_trans == null)
                {
                    cmd = new SqlCommand(ASQLCommand, _conn);
                    cmd.CommandTimeout = timeout;
                }
                else
                {
                    cmd = new SqlCommand(ASQLCommand, _conn, _trans);
                    cmd.CommandTimeout = timeout;
                }
                int result = cmd.ExecuteNonQuery();
                if (_debug) EndTiming(ASQLCommand);
                return result;
            }
            catch (Exception ex)
            {
                TxtLog.Error(string.Format("executeNonQuery SQL : {0} \r\n {1}", ASQLCommand, ex.ToString()));
                if (_debug)
                    throw ex;
                else return -1;
            }
            finally
            {
                if ((_conn.State == ConnectionState.Open) && (_trans == null) && !keepAlive) 
                    _conn.Close();
            }
        }
      
        /// <summary>
        /// 執行後回傳RecordSet的指令,使用IDataReader來控制RecordSet
        /// </summary>
        /// <param name="ASQLCommand"></param>
        /// <returns>IDataReader</returns>
        public IDataReader executeReader(string ASQLCommand)
        {
            try
            {
                if (_debug) StartTiming();
                if ((_conn.State == ConnectionState.Closed) && (_trans == null))
                    _conn.Open();

                SqlCommand cmd;
                if (_trans == null)
                    cmd = new SqlCommand(ASQLCommand, _conn);
                else
                    cmd = new SqlCommand(ASQLCommand, _conn, _trans);
                cmd.CommandTimeout = timeout;

                IDataReader reader;
                if (_trans == null)
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                else reader = cmd.ExecuteReader();
                if (_debug) EndTiming(ASQLCommand);
                return reader;
            }
            catch (Exception ex)
            {
                TxtLog.Error(string.Format("executeReader SQL : {0} \r\n {1}", ASQLCommand, ex.ToString()));
                if (_debug)
                    throw ex;
                else return null;
            }
        }
      
        /// <summary>
        /// 執行後回傳單一值的指令
        /// </summary>
        /// <param name="ASQLCommand"></param>
        /// <returns>object再用各種資料型態,強制轉型</returns>
        public object executeScalar(string ASQLCommand)
        {
            try
            {
                if (_debug) StartTiming();
                if ((_conn.State == ConnectionState.Closed) && (_trans == null)) 
                    _conn.Open();

                SqlCommand cmd;
                if (_trans == null)
                    cmd = new SqlCommand(ASQLCommand, _conn);
                else cmd = new SqlCommand(ASQLCommand, _conn, _trans);
                cmd.CommandTimeout = timeout;
                object result = cmd.ExecuteScalar();
                if (_debug) EndTiming(ASQLCommand);
                return result;
            }
            catch (Exception ex)
            {
                TxtLog.Error(string.Format("executeScalar SQL : {0} \r\n {1}", ASQLCommand, ex.ToString()));
                if (_debug)
                    throw ex;
                else return 0;
            }
            finally
            {
                if ((_conn.State == ConnectionState.Open) && (_trans == null) && !keepAlive) 
                    _conn.Close();
            }
        }
      
        /// <summary>
        /// 執行後回傳RecordSet的指令,使用DataSet來包裝RecordSet
        /// </summary>
        /// <param name="ASQLCommand"></param>
        /// <returns>DataSet</returns>
        public DataSet fillDataSet(string ASQLCommand)
        {
            DataSet dts = new DataSet();
            try
            {
                if (_debug) StartTiming();
                if ((_conn.State == ConnectionState.Closed) && (_trans == null))
                    _conn.Open();

                SqlDataAdapter adapter;
                adapter = new SqlDataAdapter(ASQLCommand, _conn);  
                adapter.SelectCommand.CommandTimeout = timeout;
                
                if (_trans != null)
                    adapter.SelectCommand.Transaction = _trans;
                adapter.Fill(dts);
                if (_debug) EndTiming(ASQLCommand);
                return dts;
            }
            catch (Exception ex)
            {
                if (_debug) TxtLog.Error(string.Format("fillDataSet Conn : {0}", this._conn.ConnectionString));
                TxtLog.Error(string.Format("fillDataSet SQL : {0} \r\n {1}", ASQLCommand, ex.ToString()));
                if (_debug)
                    throw ex;
                else return dts;
            }
            finally
            {
                if ((_conn.State == ConnectionState.Open) && (_trans == null) && !keepAlive) 
                    _conn.Close();
            }
        }

        /// <summary>
        /// 執行後回傳RecordSet的指令,使用DataSet來包裝RecordSet
        /// </summary>
        /// <param name="ASQLCommand"></param>
        /// <returns>DataSet</returns>
        public DataSet fillDataSet(string ASQLCommand,int startRecord, int maxRecord)
        {
            DataSet dts = new DataSet();
            try
            {
                if (_debug) StartTiming();
                if ((_conn.State == ConnectionState.Closed) && (_trans == null)) 
                    _conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(ASQLCommand, _conn);
                adapter.SelectCommand.CommandTimeout = timeout;
                
                if (_trans != null)
                    adapter.SelectCommand.Transaction = _trans;
                adapter.Fill(dts, startRecord, maxRecord, "DataSet");
                if (_debug) EndTiming(ASQLCommand);
                return dts;
            }
            catch (Exception ex)
            {
                TxtLog.Error(string.Format("fillDataSet SQL : {0} \r\n {1}", ASQLCommand, ex.ToString()));
                if (_debug)
                    throw ex;
                else return dts;
            }
            finally
            {
                if ((_conn.State == ConnectionState.Open) && (_trans == null) && !keepAlive)
                    _conn.Close();
            }
        }

        /// <summary>
        /// 執行後回傳DataTable的指令
        /// </summary>
        /// <param name="ASQLCommand"></param>
        /// <returns></returns>
        public DataTable fillDataTable(string ASQLCommand)
        {
            DataTable tb = new DataTable();
            try
            {
                if ((_conn.State == ConnectionState.Closed) && (_trans == null))
                    _conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(ASQLCommand, _conn);
                adapter.SelectCommand.CommandTimeout = timeout;

                if (_trans != null)
                    adapter.SelectCommand.Transaction = _trans;
                adapter.Fill(tb);
                return tb;
            }
            catch (Exception ex)
            {
                TxtLog.Error(string.Format("fillDataTable SQL : {0} \r\n {1}", ASQLCommand, ex.ToString()));
                if (_debug)
                    throw ex;
                else return tb;
            }
            finally
            {
                if ((_conn.State == ConnectionState.Open) && (_trans == null) && !keepAlive)
                    _conn.Close();
            }
        }
      
        /// <summary>
        /// 起動交易
        /// </summary>
        public void startTransaction()
        {
            if (_trans != null) return;
            if (_conn.State == ConnectionState.Closed)
                _conn.Open();
            _trans = _conn.BeginTransaction();
        }
      
        /// <summary>
        /// 確認交易
        /// </summary>
        public void commitTransaction()
        {
            try
            {
                if (_trans == null) return;
                _trans.Commit();
            }
            finally
            {
                _trans = null;
                if (_conn.State == ConnectionState.Open && !keepAlive) 
                    _conn.Close();
            }
        }
      
        /// <summary>
        /// 恢復交易
        /// </summary>
        public void rollbackTransaction()
        {
            try
            {
                if (_trans == null) return;
                _trans.Rollback();
            }
            finally
            {
                _trans = null;
                if (_conn.State == ConnectionState.Open && !keepAlive) 
                    _conn.Close();
            }
        }

        public bool keepAlive { get; private set; }
        public void openConnection()
        {
            keepAlive = true;
            if (_conn.State == ConnectionState.Closed)
                _conn.Open();
        }
        public void closeConnection()
        {
            keepAlive = false;
            if (_conn.State == ConnectionState.Open && _trans == null)
                _conn.Close();
        }

        public string getConnectionString()
        {
            return _connectionString;
        }
        #endregion

        public SQLConnection(string AConnectionString, bool ADebug)
        {
            _connectionString = AConnectionString;
            if (ADebug)
            {
                _debug = true;
                XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config")));
                sw = new Stopwatch();
            }

            _conn = new SqlConnection(AConnectionString);
        }
    }
}
