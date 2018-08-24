using System;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Application.Common;
using System.Application.DataAccess.Common;
using System.Application.Log;
using System.Collections.Generic;

namespace System.Application.DataAccess.Provider.Text
{
    public class TextConnection: IConnection
    {
        private OdbcConnection _conn;
        private OdbcTransaction _Tx;
        private OdbcCommand _cmd;

        private bool _disposed;
        private string _connectionString;
        private const string _exceptionMessage = "Sorry, an error(Odbc Connection) occurred, please record current time and contact designer !";

        public TextConnection(string connectionString)
        {
            _connectionString = connectionString;
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
        ~TextConnection()
        {
            Dispose(false);
        }

        #region Property
        private int _commandTimout = 60; //Sec
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
        private void Open()
        {
            try
            {
                if (_conn == null)
                    _conn = new OdbcConnection();

                if (_conn.State == ConnectionState.Closed)
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
            if (_conn.State == ConnectionState.Open)
            {
                _conn.Close();
                _conn.Dispose();
                _conn = null;
            }
        }
        #endregion        

        #region 執行
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                Open();

                _cmd = new OdbcCommand(sql, _conn);
                _cmd.CommandTimeout = CommandTimeout;
                return _cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MyLog.Write(string.Format("(ExecuteNonQuery SQL = {0}) \r\n {1}", sql, ex.ToString()), LogLevel.Error);
                throw new MyException(_exceptionMessage);
            }
            finally
            {
                Close(); 
            }
        }
        public IDataReader ExecuteReader(string fileName)
        {
            string _sql = string.Format("SELECT * FROM [{0}]", Path.GetFileName(fileName));
            try
            {
                Open();

                _cmd = new OdbcCommand(_sql, _conn);
                _cmd.CommandTimeout = CommandTimeout;
                return _cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MyLog.Write(string.Format("(ExecuteReader SQL = {0}) \r\n {1}", fileName, ex.ToString()), LogLevel.Error);
                throw new MyException(_exceptionMessage);
            }
        }

        public IDataReader ExecuteReader(string fileName, Dictionary<string, string> cmdParameters)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string sql)
        {
            try
            {
                Open();

                _cmd = new OdbcCommand(sql, _conn);
                _cmd.CommandTimeout = CommandTimeout;
                return _cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MyLog.Write(string.Format("(ExecuteScalar SQL = {0}) \r\n {1}", sql, ex.ToString()), LogLevel.Error);
                throw new MyException(_exceptionMessage);
            }
            finally
            {
                Close();
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

    }
}
