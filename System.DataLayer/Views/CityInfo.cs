using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// CityInfo ���K�n�y�z�C
    /// </summary>
    public class CityInfo : BaseView
    {
        #region Name Config
        public enum ncFields {CTY_NO , CTY_NAME}
        #endregion

        #region Fields
        /// <summary>����</summary>
        public string CTY_NO;
        /// <summary>����</summary>
        public string CTY_NAME;
        #endregion

        /// <summary>
        /// �غc��
        /// </summary>
        /// <param name="AConn">�s������</param>
        public CityInfo(IConnection AConn) : base(AConn)
        {
            base.Fields = "CTY_NO , CTY_NAME";
            base.From = "CITY";
        }
    }
}
