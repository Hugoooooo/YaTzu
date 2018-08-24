using System.Framework.DataLayer;
using System.DataLayer.Base;
using System;

namespace System.DataLayer.Entities
{
    /// <summary>
    /// Account
    /// </summary>
    public class Phrase : BaseEntity
    {
        #region Name Config
        public enum ncConditions { serno , category, sernolist }
        public enum ncFields { PHS_SERNO, PHS_CATEGORY, PHS_NAME, PHS_INDEX, PHS_TYPE, PHS_MODIFIEDDTTM, PHS_MODIFIEDBY }
        #endregion
        #region Fields
        /// <summary>序號</summary>
        public string PHS_SERNO = "";
        /// <summary>片語類別</summary>
        public string PHS_CATEGORY = "";
        /// <summary>名稱</summary>
        public string PHS_NAME = "";
        /// <summary>順序</summary>
        public string PHS_INDEX = "";
        /// <summary>類型</summary>
        public string PHS_TYPE = "";
        /// <summary>修改日期</summary>
        public DateTime PHS_MODIFIEDDTTM;
        /// <summary>修改時間</summary>
        public string PHS_MODIFIEDBY = "";
        #endregion
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="AConn">資料庫連接物件介面</param>
        public Phrase(IConnection AConn)
            : base(AConn)
        {
            this.TableName = "PHRASE";
            base.addKey("PHS_SERNO");
            this.ConditionDictionary["serno"] = "PHS_SERNO = N'?' ";
            this.ConditionDictionary["sernolist"] = " PHS_SERNO IN (?) ";
            this.ConditionDictionary["category"] = "PHS_CATEGORY = N'?' ";
        }
    }
}
