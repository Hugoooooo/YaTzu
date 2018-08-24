using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// Account 的摘要描述。
    /// </summary>
    public class InventoryInfo : BaseView
    {
        #region Name Config
        public enum ncConditions { serno,sernolist ,code, status , LKcode, LKname, NINsernolist , statuslist }
        public enum ncOrderBy { ODBcode, ODBname }
        public enum ncFields { INV_SERNO, INV_CODE, INV_NAME, INV_STATUS, INV_INAMT, INV_INDTTM, INV_INCOMMENT, INV_OUTAMT, INV_OUTDTTM, INV_OUTCOMMENT, INV_OUTDEALER, INV_MODIFIEDBY, INV_MODIFIEDDTTM, INV_POSTAMT, INV_POSTCOMMENT, INV_POSTDTTM, INV_RETURNAMT, INV_RETURNCOMMENT, INV_RETURNDTTM }
        #endregion

        #region Fields

        /// <summary>序號</summary>
        public string INV_SERNO = "";
        /// <summary>商品代號</summary>
        public string INV_CODE = "";
        /// <summary>商品名稱</summary>
        public string INV_NAME = "";
        /// <summary>狀態</summary>
        public string INV_STATUS = "";
        /// <summary>進貨金額</summary>
        public int INV_INAMT = 0;
        /// <summary>進貨備註</summary>
        public string INV_INCOMMENT = "";
        /// <summary>出貨金額</summary>
        public int INV_OUTAMT = 0;
        /// <summary>出貨備註</summary>
        public string INV_OUTCOMMENT = "";
        /// <summary>負責人</summary>
        public string INV_OUTDEALER = "";
        /// <summary>修改人員</summary>
        public string INV_MODIFIEDBY = "";
        /// <summary>進貨日期</summary>
        public DateTime INV_INDTTM;
        /// <summary>出貨日期</summary>
        public DateTime INV_OUTDTTM;
        /// <summary>修改日期</summary>
        public DateTime INV_MODIFIEDDTTM;
        /// <summary>寄庫金額</summary>
        public int INV_POSTAMT = 0;
        /// <summary>寄庫備註</summary>
        public string INV_POSTCOMMENT = "";
        /// <summary>寄庫日期</summary>
        public DateTime INV_POSTDTTM;
        /// <summary>退貨金額</summary>
        public int INV_RETURNAMT = 0;
        /// <summary>退貨備註</summary>
        public string INV_RETURNCOMMENT = "";
        /// <summary>退貨日期</summary>
        public DateTime INV_RETURNDTTM;
        
        #endregion

        public InventoryInfo(IConnection AConn)
            : base(AConn)
        {
            base.Fields = @"INV_SERNO,INV_CODE,INV_NAME,INV_STATUS,INV_INAMT,INV_INDTTM,INV_INCOMMENT,INV_OUTAMT,INV_OUTDTTM,INV_OUTCOMMENT,INV_OUTDEALER,INV_MODIFIEDBY,INV_MODIFIEDDTTM,INV_POSTAMT,INV_POSTCOMMENT,INV_POSTDTTM,INV_RETURNAMT,INV_RETURNCOMMENT,INV_RETURNDTTM";
            base.From = "INVENTORY";
            base.OrderBy = "INV_INDTTM desc";
            base.ConditionDictionary.Add("sernolist", " INV_SERNO  IN (?) ");
            base.ConditionDictionary.Add("NINsernolist", " INV_SERNO  NOT IN (?) ");
            base.ConditionDictionary.Add("serno", " INV_SERNO = N'?' ");
            base.ConditionDictionary.Add("code", " INV_CODE = N'?' ");
            base.ConditionDictionary.Add("LKcode", " INV_CODE LIKE N'%?%' ");
            base.ConditionDictionary.Add("LKname", " INV_NAME LIKE N'%?%' ");
            base.ConditionDictionary.Add("statuslist", " INV_STATUS  IN (?) ");
            base.ConditionDictionary.Add("status", " INV_STATUS = N'?' ");
            base.OrderByDictionary.Add("ODBcode", " INV_CODE ASC");
            base.OrderByDictionary.Add("ODBname", " INV_NAME ASC");
        }
       

    }

}
