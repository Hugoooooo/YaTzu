using System.Framework.DataLayer;
using System.DataLayer.Base;
using System;

namespace System.DataLayer.Entities
{
    /// <summary>
    /// Account
    /// </summary>
    public class Account : BaseEntity
    {
        #region Name Config
        public enum ncFields { ACT_SERNO,ACT_ACCOUNT, ACT_NAME, ACT_PASSWORD , ACT_CREATEDTTM };
        public enum ncConditions { ACCOUNT };
        #endregion

        #region Fields
        /// <summary>使用者序號</summary>
        public string ACT_SERNO;
        /// <summary>使用者帳號</summary>
        public string ACT_ACCOUNT;
        /// <summary>使用者名稱</summary>
        public string ACT_NAME;
        /// <summary>使用者密碼</summary>
        public string ACT_PASSWORD;
        /// <summary>使用者密碼</summary>
        public DateTime ACT_CREATEDTTM;
        #endregion

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="AConn">資料庫連接物件介面</param>
        public Account(IConnection AConn)
            : base(AConn)
        {
            this.TableName = "Account";
            base.addKey("ACT_ACCOUNT");
            this.ConditionDictionary.Add("ACCOUNT", " ACT_ACCOUNT = N'?' ");
        }
    }
}
