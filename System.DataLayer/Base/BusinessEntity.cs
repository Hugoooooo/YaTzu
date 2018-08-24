using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Base
{
    /// <summary>
    /// BusinessEntity ���t�����q��T�Ǹ��ݩʪ� OutboundEntity �l�ͪ���
    /// </summary>
    public class BusinessEntity : OutboundEntity
    {                              
        #region Fields
        public string COM_SERNO;
        #endregion

        /// <summary>
        /// �غc��
        /// </summary>
        /// <param name="AConn">��Ʈw�s�����󤶭�</param>
        public BusinessEntity(IConnection AConn) : base(AConn) 
        {
            addKey("COM_SERNO");
        }
    }
}
