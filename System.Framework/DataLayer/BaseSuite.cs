using System;

namespace System.Framework.DataLayer
{
    /// <summary>
    /// BaseSuite ���K�n�y�z�C
    /// </summary>
    public class BaseSuite
    {
        private IConnection _conn;

        #region Properties
        /// <summary>��Ʈw�s�����󤶭�</summary>
        public IConnection Conn
        {
            get { return _conn; }
        }
        #endregion

        /// <summary>
        /// �غc��
        /// </summary>
        /// <param name="AConn">��Ʈw�s�����󤶭�</param>
        public BaseSuite(IConnection AConn)
        {
            _conn = AConn;
        }
    }
}
