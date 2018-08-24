using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// Account 的摘要描述。
    /// </summary>
    public class RosterDialInfo : BaseView
    {
        #region Name Config
        public enum ncConditions { rstserno, rsdserno, status, item, dealer, createSDTTM, createEDTTM, modifySDTTM, modifyEDTTM }
        public enum ncFields { RSD_SERNO, RST_SERNO,RSD_ITEMTYPE, RSD_STATUS, RSD_ITEM, RSD_AMOUNT, RSD_COMMENT, RSD_DEALER, RSD_MODIFIEDBY, RSD_MODIFIEDDTTM, RSD_INSERTBY, RSD_INSERTDTTM , RSD_DEALDDTTM }
        #endregion

        #region Fields

        /// <summary>行銷序號</summary>
        public string RSD_SERNO = "";
        /// <summary>客戶序號</summary>
        public string RST_SERNO = "";
        /// <summary>商品類別</summary>
        public string RSD_ITEMTYPE = "";
        /// <summary>行銷狀態</summary>
        public string RSD_STATUS = "";
        /// <summary>商品</summary>
        public string RSD_ITEM = "";
        /// <summary>實收金額</summary>
        public string RSD_AMOUNT = "";
        /// <summary>備註</summary>
        public string RSD_COMMENT = "";
        /// <summary>處理人員</summary>
        public string RSD_DEALER = "";
        /// <summary>修改日期</summary>
        public DateTime RSD_MODIFIEDDTTM;
        /// <summary>修改人員</summary>
        public string RSD_MODIFIEDBY = "";
        /// <summary>新增日期</summary>
        public DateTime RSD_INSERTDTTM;
        /// <summary>新增人員</summary>
        public string RSD_INSERTBY = "";
        /// <summary>完成日期</summary>
        public DateTime RSD_DEALDDTTM;
        
        #endregion

        public RosterDialInfo(IConnection AConn)
            : base(AConn)
        {
            base.Fields = @"RSD_SERNO,RST_SERNO,RSD_ITEMTYPE,RSD_STATUS,RSD_ITEM,RSD_AMOUNT,RSD_COMMENT,RSD_DEALER,RSD_MODIFIEDBY,RSD_MODIFIEDDTTM,RSD_INSERTBY,RSD_INSERTDTTM,RSD_DEALDDTTM";
            base.From = "ROSTERDIAL";
            base.ConditionDictionary.Add("rstserno", " RST_SERNO = N'?' ");
            base.ConditionDictionary.Add("rsdserno", " RSD_SERNO = N'?' ");
            base.ConditionDictionary.Add("status", " RSD_STATUS = N'?' ");
            base.ConditionDictionary.Add("item", " RSD_ITEM like N'%?%' ");
            base.ConditionDictionary.Add("dealer", " RSD_DEALER = N'?' ");
            base.ConditionDictionary.Add("createSDTTM", " left(RSD_INSERTDTTM,10) >= N'?'");
            base.ConditionDictionary.Add("createEDTTM", " left(RSD_INSERTDTTM,10) <= N'?'");
            base.ConditionDictionary.Add("modifySDTTM", " left(RSD_MODIFIEDDTTM,10) >= N'?'");
            base.ConditionDictionary.Add("modifyEDTTM", " left(RSD_MODIFIEDDTTM,10) <= N'?'");
        }
       

    }

}
