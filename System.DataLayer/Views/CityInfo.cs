using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// CityInfo 的摘要描述。
    /// </summary>
    public class CityInfo : BaseView
    {
        #region Name Config
        public enum ncFields {CTY_NO , CTY_NAME}
        #endregion

        #region Fields
        /// <summary>縣市</summary>
        public string CTY_NO;
        /// <summary>縣市</summary>
        public string CTY_NAME;
        #endregion

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="AConn">連接物件</param>
        public CityInfo(IConnection AConn) : base(AConn)
        {
            base.Fields = "CTY_NO , CTY_NAME";
            base.From = "CITY";
        }
    }
}
