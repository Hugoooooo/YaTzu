using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace System.Application.DataAccess.Common
{
    /// <summary>
    /// 資料庫連接介面
    /// </summary>
    public interface IConnection : System.IDisposable
    {    
        #region 執行
        /// <summary>
        /// 執行傳回資料列的命令。
        /// </summary>
        /// <param name="sql">Sql Statement</param>
        /// <returns></returns>
        int ExecuteNonQuery(string cmd);

        /// <summary>
        /// 執行 SQL INSERT、DELETE、UPDATE 和 SET 陳述式之類的命令。
        /// </summary>
        /// <param name="sql">Sql Statement</param>
        /// <returns></returns>
        IDataReader ExecuteReader(string cmd);

        /// <summary>
        /// 執行傳回資料列的命令。
        /// </summary>
        /// <param name="cmd">Sql Statement</param>
        /// <param name="cmdParameters">Sql Statement Parameters</param>
        /// <returns></returns>
        //IDataReader ExecuteReader(string cmd, string cmdParameters);

        IDataReader ExecuteReader(string cmd, Dictionary<string, string> cmdParameters);
        /// <summary>
        /// 從資料庫擷取單一值 (例如彙總值)。
        /// </summary>
        /// <param name="sql">Sql Statement</param>
        /// <returns></returns>
        object ExecuteScalar(string cmd);
        #endregion

        #region 交易
        void BeginTransaction();
        void Commit();
        void Rollback();
        #endregion
    }
}
