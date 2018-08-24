using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// Account 的摘要描述。
    /// </summary>
    public class AccountInfo : BaseView
    {
        #region Name Config
        public enum ncConditions { ACCOUNT }
        public enum ncFields { ACT_SERNO, ACT_ACCOUNT, ACT_PASSWORD, ACT_NAME, ACT_CREATEDTTM }
        #endregion

        #region Fields
        /// <summary>序號</summary>
        public string ACT_SERNO;
        /// <summary>使用者帳號</summary>
        public string ACT_ACCOUNT;
        /// <summary>使用者密碼</summary>
        public string ACT_PASSWORD;
        /// <summary>使用者名稱</summary>
        public string ACT_NAME;
        /// <summary>使用者創建日期</summary>
        public string ACT_CREATEDTTM;

        #endregion

        public AccountInfo(IConnection AConn)
            : base(AConn)
        {
            base.Fields = "ACT_SERNO,ACT_ACCOUNT,ACT_PASSWORD,ACT_NAME,ACT_CREATEDTTM";
            base.From = "ACCOUNT";
            base.ConditionDictionary.Add("ACCOUNT", " ACT_ACCOUNT = N'?' ");
        }
       

    }

}
