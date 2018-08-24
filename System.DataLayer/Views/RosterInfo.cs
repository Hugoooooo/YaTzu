using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// 
    /// </summary>
    public class RosterInfo : BaseView
    {
        #region Name Config
        public enum ncFields { RST_SERNO, RST_NO, RST_NAME, RST_SEX, RST_PHONE, RST_MOBILE2, RST_MOBILE1, RST_ADDR, RST_COMMENT1, RST_COMMENT2, RST_COMMENT3, RST_AMOUNT, RST_ORDERDTTM, RST_MODIFIEDDTTM, RST_MODIFIEDBY, RST_INSERTBY, RST_INSERTDTTM };
        public enum ncConditions { serno, name, address, phoneLike, orderSDTTM, orderEDTTM ,no, noLike };
        public enum ncSort { Default }
        #endregion

        #region Fields
        /// <summary>序號</summary>
        public string RST_SERNO;
        /// <summary>編碼</summary>
        public string RST_NO;
        /// <summary>客戶姓名</summary>
        public string RST_NAME;
        /// <summary>客戶電話</summary>
        public string RST_PHONE;
        /// <summary>客戶手機一</summary>
        public string RST_MOBILE2;
        /// <summary>客戶手機二</summary>
        public string RST_MOBILE1;
        /// <summary>客戶地址</summary>
        public string RST_ADDR;
        /// <summary>客戶備註一</summary>
        public string RST_COMMENT1;
        /// <summary>客戶備註二</summary>
        public string RST_COMMENT2;
        /// <summary>客戶備註三</summary>
        public string RST_COMMENT3;
        /// <summary>訂單總金額</summary>
        public int RST_AMOUNT;
        /// <summary>訂單日期</summary>
        public DateTime RST_ORDERDTTM;
        /// <summary>修改日期</summary>
        public DateTime RST_MODIFIEDDTTM;
        /// <summary>修改人員</summary>
        public string RST_MODIFIEDBY;
        /// <summary>新增人員</summary>
        public string RST_INSERTBY;
        /// <summary>新增日期</summary>
        public DateTime RST_INSERTDTTM;
        #endregion

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="AConn">資料庫連接物件介面</param>
        public RosterInfo(IConnection AConn) : base(AConn)
        {
            this.Fields = " RST_SERNO, RST_NO, RST_NAME, RST_PHONE, RST_MOBILE2, RST_MOBILE1, RST_ADDR, RST_COMMENT1, RST_COMMENT2, RST_COMMENT3, RST_AMOUNT, RST_ORDERDTTM, RST_MODIFIEDDTTM, RST_MODIFIEDBY, RST_INSERTBY, RST_INSERTDTTM ";
            this.From = " ROSTER ";
            base.ConditionDictionary.Add("serno", " RST_SERNO = N'?' ");
            base.ConditionDictionary.Add("no", " RST_No = N'?' ");
            base.ConditionDictionary.Add("name", " RST_NAME like N'%?%' ");
            base.ConditionDictionary.Add("address", " RST_ADDR like N'%?%' ");
            base.ConditionDictionary.Add("noLike", " RST_No like N'%?%' ");
            base.ConditionDictionary.Add("phoneLike", " (RST_PHONE LIKE N'%?%' OR RST_MOBILE1 LIKE N'%?%' OR RST_MOBILE2 LIKE N'%?%') ");
            base.ConditionDictionary.Add("orderSDTTM", " left(RST_MODIFIEDDTTM,10) >= N'?'");
            base.ConditionDictionary.Add("orderEDTTM", " left(RST_MODIFIEDDTTM,10) <= N'?'");


            base.OrderByDictionary.Add("Default", " RST_MODIFIEDDTTM desc "); 
            base.OrderByDictionary.Add("dgvMember_No", " RST_No ");
            base.OrderByDictionary.Add("dgvMember_Name", " RST_NAME ");
            base.OrderByDictionary.Add("dgvMember_Mobile1", " RST_MOBILE1 ");
            base.OrderByDictionary.Add("dgvMember_Mobile2", " RST_MOBILE2 ");
            base.OrderByDictionary.Add("dgvMember_Phone", " RST_PHONE ");
            base.OrderByDictionary.Add("dgvMember_Addr", " RST_ADDR ");
            base.OrderByDictionary.Add("dgvMember_OrderDTTM", " RST_ORDERDTTM ");
            base.OrderByDictionary.Add("dgvMember_Amount", " RST_AMOUNT ");
            base.OrderByDictionary.Add("dgvMember_ModifiedDTTM", " RST_MODIFIEDDTTM ");
        }
    }
}
