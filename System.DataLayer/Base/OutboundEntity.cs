using System;
using System.Framework.DataLayer;
using System.Framework.Common;

namespace System.DataLayer.Base
{
    /// <summary>
    /// OutboundEntity 的摘要描述。
    /// </summary>
    public class OutboundEntity : BaseEntity
    {
        //private string startDate = "2000/01/01 00:00:00.000";

        #region Method
        /// <summary>
        /// 產生時間序號
        /// </summary>
        /// <returns>時間序號字串</returns>
        public string getSerialNum()
        {
            //long timeStamp = DateTime.Now.Ticks -  Convert.ToDateTime(startDate).Ticks;
            return Guid.NewGuid().ToString().Substring(25, 10);

            //return Convert.ToString(timeStamp / 100000, 16).ToUpper();
        }
        #endregion

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="AConn">資料庫連接物件介面</param>
        public OutboundEntity(IConnection AConn) : base(AConn) {}
    }
}
