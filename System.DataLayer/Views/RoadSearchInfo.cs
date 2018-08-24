using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// RoadInfo 的摘要描述。
    /// </summary>
    public class RoadSearchInfo : BaseView
    {
        #region Name Config
        public enum ncConditions { Name }
        public enum ncFields { CTY_NAME, ARA_NAME, ROD_NAME }
        #endregion 
        #region Fields
        public string ARA_NAME;
        public string CTY_NAME;
        public string ROD_NAME;
        #endregion
        /// <param name="AConn">連接物件</param>
        public RoadSearchInfo(IConnection AConn) : base(AConn)
        {
            base.Fields = "CTY_NAME,ARA_NAME,ROD_NAME";
            base.From = @"ROAD R
                        LEFT JOIN AREA A ON R.ARA_NO = A.ARA_NO
                        LEFT JOIN CITY C ON C.CTY_NO = A.CTY_NO  ";
            base.ConditionDictionary.Add("Name", " ROD_NAME like N'%?%' ");
        }
    }
}
