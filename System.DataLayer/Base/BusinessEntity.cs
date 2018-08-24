using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Base
{
    /// <summary>
    /// BusinessEntity 為含有公司資訊序號屬性的 OutboundEntity 衍生物件
    /// </summary>
    public class BusinessEntity : OutboundEntity
    {                              
        #region Fields
        public string COM_SERNO;
        #endregion

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="AConn">資料庫連接物件介面</param>
        public BusinessEntity(IConnection AConn) : base(AConn) 
        {
            addKey("COM_SERNO");
        }
    }
}
