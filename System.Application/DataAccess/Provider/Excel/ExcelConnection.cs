using System;
using System.Data;
using System.Data.OleDb;
using System.Application.Common;
using System.Application.DataAccess.Common;
using System.Application.Log;
using System.Collections.Generic;

namespace System.Application.DataAccess.Provider.Excel
{
    public class ExcelConnection: IConnection, ITransaction
    {
        private OleDbConnection _conn;
        private OleDbTransaction _Tx;
        private OleDbCommand _cmd;

        private bool _disposed;
        private string _connectionString;
        private const string _exceptionMessage = "Sorry, an error(OleDb Connection) occurred, please record current time and contact designer !";

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

        public ExcelConnection(string connectionString)
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
        ~ExcelConnection()
        {
            Dispose(false);
        }

        #region Private Method
        private void Open()
        {
            try
            {
                if (_conn == null)
                    _conn = new OleDbConnection();
                
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
        public int ExecuteNonQuery(string sheet)
        {
            try
            {
                Open();

                if (_Tx == null)
                    _cmd = new OleDbCommand(sheet, _conn);
                else _cmd = new OleDbCommand(sheet, _conn, _Tx);
                _cmd.CommandTimeout = CommandTimeout;
                return _cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MyLog.Write(string.Format("(ExecuteNonQuery SQL = {0}) \r\n {1}", sheet, ex.ToString()), LogLevel.Error);
                throw new MyException(_exceptionMessage);
            }
            finally
            {
                Close();
            }
        }
        public IDataReader ExecuteReader(string sheet)
        {
            string _sql = string.Format("SELECT * FROM [{0}$]", sheet);
            try
            {
                Open();

                /*
                DataTable dtSheetName = _conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "Table" }
                );
                for (int i = 0; i < dtSheetName.Rows.Count; i++)
                {
                    if (dtSheetName.Rows[i]["TABLE_NAME"].ToString().Contains(sheet))
                    {
                        _sql = string.Format(_sql, dtSheetName.Rows[i]["TABLE_NAME"].ToString());
                        break;
                    }
                }
                 */ 

                if (_Tx == null)
                {
                    _cmd = new OleDbCommand(_sql, _conn);
                    _cmd.CommandTimeout = CommandTimeout;
                    return _cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                else
                {
                    _cmd = new OleDbCommand(_sql, _conn, _Tx);
                    _cmd.CommandTimeout = CommandTimeout;
                    return _cmd.ExecuteReader();
                }                
            }
            catch (Exception ex)
            {
                MyLog.Write(string.Format("(ExecuteReader SQL = {0}) \r\n {1}", _sql, ex.ToString()), LogLevel.Error);
                throw new MyException(_exceptionMessage);
            }
        }
        public IDataReader ExecuteReader(string sheet, Dictionary<string, string> cmdParameters)
        {
            throw new NotImplementedException();
        }

        public IDataReader ExecuteReader(int sheetIndex)
        {
            string _sql = "SELECT * FROM [{0}]";
            DataTable dt = new DataTable();

            try
            {
                Open();
                DataTable dtSheetName = _conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "Table" }
                );
                string[] strTableNames = new string[dtSheetName.Rows.Count];
                int j = 0;
                for (int i = 0; i < dtSheetName.Rows.Count; i++)
                {
                    if (dtSheetName.Rows[i]["TABLE_NAME"].ToString().IndexOf("_") < 0)
                    {
                        strTableNames[j++] = dtSheetName.Rows[i]["TABLE_NAME"].ToString();                        
                    }
                }

                _sql = string.Format(_sql, strTableNames[sheetIndex]);

                if (_Tx == null)
                {
                    _cmd = new OleDbCommand(_sql, _conn);
                    _cmd.CommandTimeout = CommandTimeout;
                    return _cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                else
                {
                    _cmd = new OleDbCommand(_sql, _conn, _Tx);
                    _cmd.CommandTimeout = CommandTimeout;
                    return _cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                MyLog.Write(string.Format("(ExecuteReader SQL = {0}) \r\n {1}", _sql, ex.ToString()), LogLevel.Error);
                throw new MyException(_exceptionMessage);
            }
        }
        public object ExecuteScalar(string sheet)
        {
            try
            {
                Open();

                if (_Tx == null)
                    _cmd = new OleDbCommand(sheet, _conn);
                else _cmd = new OleDbCommand(sheet, _conn, _Tx);
                _cmd.CommandTimeout = CommandTimeout;
                return _cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MyLog.Write(string.Format("(ExecuteScalar SQL = {0}) \r\n {1}", sheet, ex.ToString()), LogLevel.Error);
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
