using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// Phrase 的摘要描述。
    /// </summary>
    public class PhraseInfo : BaseView
    {
        #region Name Config
        public enum ncConditions { serno, category, name, modifySDTTM, modifyEDTTM , index , type }
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
        public string PHS_MODIFIEDDTTM = "";
        /// <summary>修改時間</summary>
        public string PHS_MODIFIEDBY = "";

        #endregion

        public PhraseInfo(IConnection AConn)
            : base(AConn)
        {
            base.Fields = @"PHS_SERNO,PHS_CATEGORY,PHS_NAME,PHS_INDEX,PHS_TYPE,PHS_MODIFIEDDTTM,PHS_MODIFIEDBY";
            base.From = "PHRASE";
            base.OrderBy = "PHS_INDEX asc";
            base.ConditionDictionary.Add("serno", " PHS_SERNO = N'?' ");
            base.ConditionDictionary.Add("category", " PHS_CATEGORY = N'?' ");
            base.ConditionDictionary.Add("name", " PHS_NAME like N'%?%' ");
            base.ConditionDictionary.Add("type", " PHS_TYPE like N'%?%' ");
            base.ConditionDictionary.Add("index", " PHS_INDEX = N'?' ");
            base.ConditionDictionary.Add("modifySDTTM", " left(RST_MODIFIEDDTTM,10) >= N'?'");
            base.ConditionDictionary.Add("modifyEDTTM", " left(RST_MODIFIEDDTTM,10) <= N'?'");
        }
       

    }

}
