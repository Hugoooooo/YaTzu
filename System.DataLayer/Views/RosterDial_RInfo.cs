using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// Account ���K�n�y�z�C
    /// </summary>
    public class RosterDial_RInfo : BaseView
    {
        #region Name Config
        public enum ncConditions { rsdserno, item, main,name, createSDTTM, createEDTTM, modifySDTTM, modifyEDTTM, dealSDTTM, dealEDTTM, status, type, dealer, comment, typelist }
        public enum ncFields {RSD_SERNO, RSD_STATUS, RSD_ITEMTYPE, RSD_ITEM, RSD_AMOUNT, RSD_COMMENT, RSD_DEALER, RSD_DEALDDTTM, RSD_MODIFIEDBY, RSD_MODIFIEDDTTM
                            , RSD_INSERTBY, RSD_INSERTDTTM, RST_SERNO, RST_MAIN, RST_NAME, RST_SEX, RST_PHONE1, RST_PHONE2, RST_MOBILE, RST_FAX
                            , RST_ADDR, RST_PRINCIPAL, RST_COMMENT, RST_MODIFIEDDTTM, RST_MODIFIEDBY, RST_INSERTBY, RST_INSERTDTTM}
        public enum ncSort { Default }
        #endregion

        #region Fields

        /// <summary>�Ǹ�</summary>
        public string RST_SERNO = "";
        /// <summary>�D�n�p���q��</summary>
        public string RST_MAIN = "";
        /// <summary>�Ȥ�m�W</summary>
        public string RST_NAME = "";
        /// <summary>�Ȥ�ʧO</summary>
        public string RST_SEX = "";
        /// <summary>��a�q��1</summary>
        public string RST_PHONE1 = "";
        /// <summary>��a�q��2</summary>
        public string RST_PHONE2 = "";
        /// <summary>���</summary>
        public string RST_MOBILE = "";
        /// <summary>�ǯu</summary>
        public string RST_FAX = "";
        /// <summary>�a�}</summary>
        public string RST_ADDR = "";
        /// <summary>�Ƶ�</summary>
        public string RST_COMMENT = "";
        /// <summary>�t�d�H</summary>
        public string RST_PRINCIPAL = "";
        /// <summary>�ק���</summary>
        public DateTime RST_MODIFIEDDTTM;
        /// <summary>�ק�H��</summary>
        public string RST_MODIFIEDBY = "";
        /// <summary>�s�W���</summary>
        public DateTime RST_INSERTDTTM;
        /// <summary>�s�W�H��</summary>
        public string RST_INSERTBY = "";
        /// <summary>��P�Ǹ�</summary>
        public string RSD_SERNO = "";
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

        public RosterDial_RInfo(IConnection AConn)
            : base(AConn)
        {
            base.Fields = @"RSD.RSD_SERNO,RSD.RSD_STATUS,RSD.RSD_ITEMTYPE,RSD.RSD_ITEM,RSD.RSD_AMOUNT,RSD.RSD_COMMENT,RSD.RSD_DEALER,RSD.RSD_DEALDDTTM,RSD.RSD_MODIFIEDBY,RSD.RSD_MODIFIEDDTTM
                            ,RSD.RSD_INSERTBY,RSD.RSD_INSERTDTTM,RST.RST_SERNO,RST.RST_MAIN,RST.RST_NAME,RST.RST_SEX,RST.RST_PHONE1,RST.RST_PHONE2,RST.RST_MOBILE,RST.RST_FAX
                            ,RST.RST_ADDR,RST.RST_PRINCIPAL,RST.RST_COMMENT,RST.RST_MODIFIEDDTTM,RST.RST_MODIFIEDBY,RST.RST_INSERTBY,RST.RST_INSERTDTTM";
            base.From = @"ROSTERDIAL RSD
                            LEFT JOIN ROSTER  RST ON RST.RST_SERNO=RSD.RST_SERNO";
            base.OrderBy = " RSD_DEALDDTTM desc";
            base.ConditionDictionary.Add("rsdserno", " RSD.RSD_SERNO = N'?' ");

            base.ConditionDictionary.Add("item", " RSD.RSD_ITEM like N'%?%' ");
            base.ConditionDictionary.Add("main", " RST.RST_MAIN like N'%?%' ");
            base.ConditionDictionary.Add("name", " RST.RST_NAME like N'%?%' ");
            base.ConditionDictionary.Add("createSDTTM", " left(RST_INSERTDTTM,10) >= N'?'");
            base.ConditionDictionary.Add("createEDTTM", " left(RST_INSERTDTTM,10) <= N'?'");
            base.ConditionDictionary.Add("modifySDTTM", " left(RST_MODIFIEDDTTM,10) >= N'?'");
            base.ConditionDictionary.Add("modifyEDTTM", " left(RST_MODIFIEDDTTM,10) <= N'?'");
            base.ConditionDictionary.Add("dealSDTTM", " left(RSD_DEALDDTTM,10) >= N'?'");
            base.ConditionDictionary.Add("dealEDTTM", " left(RSD_DEALDDTTM,10) <= N'?'");
            base.ConditionDictionary.Add("status", " RSD.RSD_STATUS = N'?' ");
            base.ConditionDictionary.Add("type", " RSD.RSD_ITEMTYPE = N'?' ");
            base.ConditionDictionary.Add("typelist", " RSD.RSD_ITEMTYPE IN ( ? ) ");
            base.ConditionDictionary.Add("dealer", " RSD.RSD_DEALER = N'?' ");
            base.ConditionDictionary.Add("comment", " RSD.RSD_COMMENT like N'%?%' ");

            base.OrderByDictionary.Add("Default", " RSD_MODIFIEDDTTM desc ");
            base.OrderByDictionary.Add("dgvSale_CSTName", " RST.RST_NAME ");
            base.OrderByDictionary.Add("dgvSale_Main", " RST.RST_MAIN ");
            base.OrderByDictionary.Add("dgvSale_Status", " RSD.RSD_STATUS ");
            base.OrderByDictionary.Add("dgvSale_Type", " RSD.RSD_ITEMTYPE ");
            base.OrderByDictionary.Add("dgvSale_Item", " RSD.RSD_ITEM ");
            base.OrderByDictionary.Add("dgvSale_Dealer", " RSD.RSD_DEALER ");
            base.OrderByDictionary.Add("dgvSale_Amount", " RSD.RSD_AMOUNT ");
            base.OrderByDictionary.Add("dgvSale_Comment", " RSD.RSD_COMMENT ");
            base.OrderByDictionary.Add("dgvSale_DealDTTM", " RSD.RSD_DEALDDTTM ");
            base.OrderByDictionary.Add("dgvSale_ModifyDTTM", " RSD.RSD_MODIFIEDDTTM ");
        }
       

    }

}
