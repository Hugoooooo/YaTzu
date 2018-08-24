using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// RoadInfo ���K�n�y�z�C
    /// </summary>
    public class RoadInfo : BaseView
    {
        #region Name Config
        public enum ncConditions {AreaNo, Name }
        public enum ncFields {ROD_NAME}
        #endregion 
        #region Fields
        /// <summary>�m�B��B���B��</summary>
        public string ROD_NAME;

        #endregion
        /// <param name="AConn">�s������</param>
        public RoadInfo(IConnection AConn) : base(AConn)
        {
            base.Fields = "ROD_NAME";
            base.From = "ROAD";
            base.ConditionDictionary.Add("AreaNo" , " ARA_NO = ? ");
            base.ConditionDictionary.Add("Name", " ROD_NAME like N'%?%' ");
        }
    }
}
