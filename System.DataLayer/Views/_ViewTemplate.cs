using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// 
    /// </summary>
    public class ROSTERInfo: BaseView
    {
        #region Name Config
        public enum ncFields { RST_SERNO, RST_NO, RST_NAME, RST_SEX, RST_PHONE, RST_MOBILE2, RST_MOBILE1, RST_ADDR, RST_COMMENT1, RST_COMMENT2, RST_COMMENT3, RST_AMOUNT, RST_ORDERDTTM, RST_MODIFIEDDTTM, RST_MODIFIEDBY, RST_INSERTBY, RST_INSERTDTTM };
        public enum ncConditions { CompanySerno, Serno };
        #endregion

        #region Fields
        /// <summary></summary>
        public string RST_SERNO;
        /// <summary></summary>
        public string RST_NO;
        /// <summary></summary>
        public string RST_NAME;
        /// <summary></summary>
        public string RST_SEX;
        /// <summary></summary>
        public string RST_PHONE;
        /// <summary></summary>
        public string RST_MOBILE2;
        /// <summary></summary>
        public string RST_MOBILE1;
        /// <summary></summary>
        public string RST_ADDR;
        /// <summary></summary>
        public string RST_COMMENT1;
        /// <summary></summary>
        public string RST_COMMENT2;
        /// <summary></summary>
        public string RST_COMMENT3;
        /// <summary></summary>
        public int RST_AMOUNT;
        /// <summary></summary>
        public string RST_ORDERDTTM;
        /// <summary></summary>
        public string RST_MODIFIEDDTTM;
        /// <summary></summary>
        public string RST_MODIFIEDBY;
        /// <summary></summary>
        public string RST_INSERTBY;
        /// <summary></summary>
        public string RST_INSERTDTTM;
        #endregion

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="AConn">資料庫連接物件介面</param>
        public ROSTERInfo(IConnection AConn) : base(AConn)
        {
            this.Fields = " RST_SERNO, RST_NO, RST_NAME, RST_SEX, RST_PHONE, RST_MOBILE2, RST_MOBILE1, RST_ADDR, RST_COMMENT1, RST_COMMENT2, RST_COMMENT3, RST_AMOUNT, RST_ORDERDTTM, RST_MODIFIEDDTTM, RST_MODIFIEDBY, RST_INSERTBY, RST_INSERTDTTM ";
            this.From = " ROSTER ";
            this.ConditionDictionary.Add("CompanySerno", " COM_SERNO = N'?' ");
            this.ConditionDictionary.Add("Serno", " RST_SERNO = N'?' ");
        }
    }
}
