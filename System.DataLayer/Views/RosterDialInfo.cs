using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// Account ���K�n�y�z�C
    /// </summary>
    public class RosterDialInfo : BaseView
    {
        #region Name Config
        public enum ncConditions { rstserno, rsdserno, status, item, dealer, createSDTTM, createEDTTM, modifySDTTM, modifyEDTTM }
        public enum ncFields { RSD_SERNO, RST_SERNO,RSD_ITEMTYPE, RSD_STATUS, RSD_ITEM, RSD_AMOUNT, RSD_COMMENT, RSD_DEALER, RSD_MODIFIEDBY, RSD_MODIFIEDDTTM, RSD_INSERTBY, RSD_INSERTDTTM , RSD_DEALDDTTM }
        #endregion

        #region Fields

        /// <summary>��P�Ǹ�</summary>
        public string RSD_SERNO = "";
        /// <summary>�Ȥ�Ǹ�</summary>
        public string RST_SERNO = "";
        /// <summary>�ӫ~���O</summary>
        public string RSD_ITEMTYPE = "";
        /// <summary>��P���A</summary>
        public string RSD_STATUS = "";
        /// <summary>�ӫ~</summary>
        public string RSD_ITEM = "";
        /// <summary>�ꦬ���B</summary>
        public string RSD_AMOUNT = "";
        /// <summary>�Ƶ�</summary>
        public string RSD_COMMENT = "";
        /// <summary>�B�z�H��</summary>
        public string RSD_DEALER = "";
        /// <summary>�ק���</summary>
        public DateTime RSD_MODIFIEDDTTM;
        /// <summary>�ק�H��</summary>
        public string RSD_MODIFIEDBY = "";
        /// <summary>�s�W���</summary>
        public DateTime RSD_INSERTDTTM;
        /// <summary>�s�W�H��</summary>
        public string RSD_INSERTBY = "";
        /// <summary>�������</summary>
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
