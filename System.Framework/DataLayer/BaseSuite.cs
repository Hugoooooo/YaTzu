using System;

namespace System.Framework.DataLayer
{
    /// <summary>
    /// BaseSuite 的摘要描述。
    /// </summary>
    public class BaseSuite
    {
        private IConnection _conn;

        #region Properties
        /// <summary>資料庫連接物件介面</summary>
        public IConnection Conn
        {
            get { return _conn; }
        }
        #endregion

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="AConn">資料庫連接物件介面</param>
        public BaseSuite(IConnection AConn)
        {
            _conn = AConn;
        }
    }
}
