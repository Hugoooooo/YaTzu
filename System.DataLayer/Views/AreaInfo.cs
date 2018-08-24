using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// AreaInfo ���K�n�y�z�C
    /// </summary>
    public class AreaInfo : BaseView
    {
        #region Name Config
        public enum ncConditions {CityNo}
        public enum ncFields {ARA_NO , ARA_NAME , ARA_ZIP}
        #endregion

        #region Fields
        /// <summary>�m�B��B���B��</summary>
        public string ARA_NAME;
        public string ARA_NO;
        public string ARA_ZIP;
        #endregion

        public AreaInfo(IConnection AConn) : base(AConn)
        {
            base.Fields = "ARA_NO , ARA_NAME , ARA_ZIP";
            base.From = "AREA";
            base.ConditionDictionary.Add("CityNo", " CTY_NO = ? ");
        }
    }
}
