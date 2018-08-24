using System.Framework.DataLayer;
using System.DataLayer.Base;
using System;

namespace System.DataLayer.Entities
{
    /// <summary>
    /// Account
    /// </summary>
    public class RosterDial : BaseEntity
    {
        #region Name Config
        public enum ncConditions { serno, sernolist }
        public enum ncFields { RSD_SERNO, RST_SERNO, RSD_ITEMTYPE, RSD_STATUS, RSD_ITEM, RSD_AMOUNT, RSD_COMMENT, RSD_DEALER, RSD_MODIFIEDBY, RSD_MODIFIEDDTTM, RSD_INSERTBY, RSD_INSERTDTTM, RSD_DEALDDTTM }
        #endregion
        #region Fields

        /// <summary>行銷序號</summary>
        public string RSD_SERNO = "";
        /// <summary>客戶序號</summary>
        public string RST_SERNO = "";
        /// <summary>行銷狀態</summary>
        public string RSD_STATUS = "";
        /// <summary>商品類別</summary>
        public string RSD_ITEMTYPE = "";
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
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="AConn">資料庫連接物件介面</param>
        public RosterDial(IConnection AConn)
            : base(AConn)
        {
            this.TableName = "ROSTERDIAL";
            base.addKey("RSD_SERNO");
            this.ConditionDictionary["serno"] = " RSD_SERNO = N'?' ";
            this.ConditionDictionary["sernolist"] = " RSD_SERNO IN (?) ";
        }
    }
}
