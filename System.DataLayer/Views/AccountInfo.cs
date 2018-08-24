using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// Account ���K�n�y�z�C
    /// </summary>
    public class AccountInfo : BaseView
    {
        #region Name Config
        public enum ncConditions { ACCOUNT }
        public enum ncFields { ACT_SERNO, ACT_ACCOUNT, ACT_PASSWORD, ACT_NAME, ACT_CREATEDTTM }
        #endregion

        #region Fields
        /// <summary>�Ǹ�</summary>
        public string ACT_SERNO;
        /// <summary>�ϥΪ̱b��</summary>
        public string ACT_ACCOUNT;
        /// <summary>�ϥΪ̱K�X</summary>
        public string ACT_PASSWORD;
        /// <summary>�ϥΪ̦W��</summary>
        public string ACT_NAME;
        /// <summary>�ϥΪ̳Ыؤ��</summary>
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
