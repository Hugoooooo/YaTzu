using System.Framework.DataLayer;
using System.DataLayer.Base;
using System;

namespace System.DataLayer.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Roster : BaseEntity
    {
        #region Name Config
        public enum ncFields { RST_SERNO, RST_NO, RST_NAME, RST_PHONE, RST_MOBILE2, RST_MOBILE1, RST_ADDR, RST_COMMENT1, RST_COMMENT2, RST_COMMENT3, RST_AMOUNT, RST_ORDERDTTM, RST_MODIFIEDDTTM, RST_MODIFIEDBY, RST_INSERTBY, RST_INSERTDTTM };
        public enum ncConditions { sernolist,serno };
        #endregion

        #region Fields
        /// <summary></summary>
        public string RST_SERNO;
        /// <summary></summary>
        public string RST_NO;
        /// <summary></summary>
        public string RST_NAME;
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
        public DateTime RST_ORDERDTTM;
        /// <summary></summary>
        public DateTime RST_MODIFIEDDTTM;
        /// <summary></summary>
        public string RST_MODIFIEDBY;
        /// <summary></summary>
        public string RST_INSERTBY;
        /// <summary></summary>
        public DateTime RST_INSERTDTTM;
        #endregion

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="AConn">資料庫連接物件介面</param>
        public Roster(IConnection AConn) : base(AConn)
        {
            this.TableName = "ROSTER";
            base.addKey("RST_SERNO");
            this.ConditionDictionary["serno"] = " RST_SERNO = N'?' ";
            this.ConditionDictionary["sernolist"] = " RST_SERNO IN (?) ";
        }
    }
}
