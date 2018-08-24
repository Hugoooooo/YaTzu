using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Application.Common;
using System.Application.DataAccess.Common;
using System.Application.Log;
using log4net;
using log4net.Config;
using System.Collections.Generic;

namespace System.Application.DataAccess.Provider.SQLServer
{
    /// <summary>
    /// SQL Server 連接類別
    /// </summary>
    public class SQLConnection: IConnection, ITransaction
    {
        private static readonly ILog TxtLog = LogManager.GetLogger(typeof(SQLConnection));

        private SqlConnection _conn;
        private SqlTransaction _Tx;
        private SqlCommand _cmd;

        private bool _disposed;
        private string _connectionString;
        private const string _exceptionMessage = "Sorry, an error(Sql Connection) occurred, please record current time and contact designer !";

        private bool _debug = true;
        private Stopwatch sw = null;

        public SQLConnection(string connectionString)
        {
            XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config")));
            _connectionString = connectionString;
            sw = new Stopwatch();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    //Release managed resources
                }
                _disposed = true;
            }
        }
        ~SQLConnection()
        {
            Dispose(false);
        }

        #region Property
        private int _commandTimout = 600; //Sec(default 30)
        public int CommandTimeout
        {
            get
            {
                return _commandTimout;
            }
            set
            {
                _commandTimout = value;
            }
        }
        #endregion

        #region Private Method
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
            TxtLog.Debug(string.Format("Processing time : [{0}]\r\n  {1}\r\n", processingTime, statement));
        }
        private void Open()
        {
            try
            {
                if (_conn == null)
                    _conn = new SqlConnection();

                if ((_conn.State == ConnectionState.Closed) && (_Tx == null)) 
                {
                    _conn.ConnectionString = _connectionString;
                    _conn.Open();
                }
            }
            catch
            {
                throw;
            }
        }
        private void Close()
        {
            if ((_conn.State == ConnectionState.Open) && (_Tx == null))
            {
                _conn.Close();
                _conn.Dispose();
                _conn = null;
            }
        }
        #endregion

        #region 交易
        public void BeginTransaction()
        {
            try
            {
                if (_Tx != null)
                    return;
                 
                Open();
                _Tx = _conn.BeginTransaction(IsolationLevel.ReadCommitted);
            }
            catch (Exception ex)
            {
                MyLog.Write(ex.ToString(), LogLevel.Fatal);
                throw new MyException(_exceptionMessage);
            }            
        }
        public void Commit()
        {
            try
            {
                if (_Tx == null) 
                    return;

                _Tx.Commit();
            }
            catch (Exception ex)
            {
                MyLog.Write(ex.ToString(), LogLevel.Fatal);
                throw new MyException(_exceptionMessage);
            }
            finally
            {
                _Tx.Dispose();
                Close();
            }
        }
        public void Rollback()
        {
            try
            {
                if (_Tx == null) 
                    return;

                _Tx.Rollback();
            }
            catch (Exception ex)
            {
                MyLog.Write(ex.ToString(), LogLevel.Fatal);
                throw new MyException(_exceptionMessage);
            }
            finally
            {
                _Tx.Dispose();
                Close();
            }
        }
        #endregion

        #region 執行
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                int result = 0;
                if (_debug) StartTiming();
                Open();

                if (_Tx == null)
                    _cmd = new SqlCommand(sql, _conn);
                else _cmd = new SqlCommand(sql, _conn, _Tx);
                _cmd.CommandTimeout = CommandTimeout;
                result = _cmd.ExecuteNonQuery();
                if (_debug) EndTiming(sql);
                return result;
            }
            catch (Exception ex)
            {
                TxtLog.Error(string.Format("ExecuteNonQuery : [{0}]\r\n  {1}\r\n", sql, ex.ToString()));
                throw new MyException(_exceptionMessage);
            }
            finally
            {
                Close(); 
            }
        }
        public IDataReader ExecuteReader(string sql)
        {
            try
            {
                SqlDataReader reader = null;
                if (_debug) StartTiming();
                Open();

                if (_Tx == null)
                    _cmd = new SqlCommand(sql, _conn);
                else _cmd = new SqlCommand(sql, _conn, _Tx);
                _cmd.CommandTimeout = CommandTimeout;
                if (_Tx == null)
                    reader = _cmd.ExecuteReader(CommandBehavior.CloseConnection);
                else
                    reader = _cmd.ExecuteReader();
                if (_debug) EndTiming(sql);
                return reader;
            }
            catch (Exception ex)
            {
                TxtLog.Error(string.Format("ExecuteReader : [{0}]\r\n  {1}\r\n", sql, ex.ToString()));
                throw new MyException(_exceptionMessage);
            }
        }

        public IDataReader ExecuteReader(string cmd, Dictionary<string, string> cmdParameters)
        {
            try
            {
                SqlDataReader reader = null;
                string sqlLog = cmd;
                if (_debug) StartTiming();
                Open();

                if (_Tx == null)
                    _cmd = new SqlCommand(cmd, _conn);
                else _cmd = new SqlCommand(cmd, _conn, _Tx);
                _cmd.CommandTimeout = CommandTimeout;
                if (cmdParameters != null && cmdParameters.Count >= 1)
                {
                    foreach (KeyValuePair<string, string> item in cmdParameters)
                    {
                        _cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                if (_Tx == null)
                    reader = _cmd.ExecuteReader(CommandBehavior.CloseConnection);
                else
                    reader = _cmd.ExecuteReader();
                if (_debug) EndTiming(sqlLog);
                return reader;
            }
            catch (Exception ex)
            {
                TxtLog.Error(string.Format("ExecuteReader : [{0}]\r\n  {1}\r\n", cmd, ex.ToString()));
                throw new MyException(_exceptionMessage);
            }
        }
        public object ExecuteScalar(string sql)
        {
            try
            {
                object result = null;
                if (_debug) StartTiming();
                Open();
                
                if (_Tx == null)
                    _cmd = new SqlCommand(sql, _conn);
                else _cmd = new SqlCommand(sql, _conn, _Tx);
                _cmd.CommandTimeout = CommandTimeout;
                result = _cmd.ExecuteScalar();
                if (_debug) EndTiming(sql);
                return result;
            }
            catch (Exception ex)
            {
                TxtLog.Error(string.Format("ExecuteScalar : [{0}]\r\n  {1}\r\n", sql, ex.ToString()));
                throw new MyException(_exceptionMessage);
            }
            finally
            {
                Close();
            }
        }

        
        #endregion
    }
}
