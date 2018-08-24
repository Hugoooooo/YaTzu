using System;
using System.Framework.DataLayer;
using System.Framework.Common;

namespace System.DataLayer.Base
{
    /// <summary>
    /// OutboundEntity ���K�n�y�z�C
    /// </summary>
    public class OutboundEntity : BaseEntity
    {
        //private string startDate = "2000/01/01 00:00:00.000";

        #region Method
        /// <summary>
        /// ���ͮɶ��Ǹ�
        /// </summary>
        /// <returns>�ɶ��Ǹ��r��</returns>
        public string getSerialNum()
        {
            //long timeStamp = DateTime.Now.Ticks -  Convert.ToDateTime(startDate).Ticks;
            return Guid.NewGuid().ToString().Substring(25, 10);

            //return Convert.ToString(timeStamp / 100000, 16).ToUpper();
        }
        #endregion

        /// <summary>
        /// �غc��
        /// </summary>
        /// <param name="AConn">��Ʈw�s�����󤶭�</param>
        public OutboundEntity(IConnection AConn) : base(AConn) {}
    }
}
