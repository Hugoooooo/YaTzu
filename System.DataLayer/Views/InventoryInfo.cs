using System;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// Account ���K�n�y�z�C
    /// </summary>
    public class InventoryInfo : BaseView
    {
        #region Name Config
        public enum ncConditions { serno,sernolist ,code, status , LKcode, LKname, NINsernolist , statuslist }
        public enum ncOrderBy { ODBcode, ODBname }
        public enum ncFields { INV_SERNO, INV_CODE, INV_NAME, INV_STATUS, INV_INAMT, INV_INDTTM, INV_INCOMMENT, INV_OUTAMT, INV_OUTDTTM, INV_OUTCOMMENT, INV_OUTDEALER, INV_MODIFIEDBY, INV_MODIFIEDDTTM, INV_POSTAMT, INV_POSTCOMMENT, INV_POSTDTTM, INV_RETURNAMT, INV_RETURNCOMMENT, INV_RETURNDTTM }
        #endregion

        #region Fields

        /// <summary>�Ǹ�</summary>
        public string INV_SERNO = "";
        /// <summary>�ӫ~�N��</summary>
        public string INV_CODE = "";
        /// <summary>�ӫ~�W��</summary>
        public string INV_NAME = "";
        /// <summary>���A</summary>
        public string INV_STATUS = "";
        /// <summary>�i�f���B</summary>
        public int INV_INAMT = 0;
        /// <summary>�i�f�Ƶ�</summary>
        public string INV_INCOMMENT = "";
        /// <summary>�X�f���B</summary>
        public int INV_OUTAMT = 0;
        /// <summary>�X�f�Ƶ�</summary>
        public string INV_OUTCOMMENT = "";
        /// <summary>�t�d�H</summary>
        public string INV_OUTDEALER = "";
        /// <summary>�ק�H��</summary>
        public string INV_MODIFIEDBY = "";
        /// <summary>�i�f���</summary>
        public DateTime INV_INDTTM;
        /// <summary>�X�f���</summary>
        public DateTime INV_OUTDTTM;
        /// <summary>�ק���</summary>
        public DateTime INV_MODIFIEDDTTM;
        /// <summary>�H�w���B</summary>
        public int INV_POSTAMT = 0;
        /// <summary>�H�w�Ƶ�</summary>
        public string INV_POSTCOMMENT = "";
        /// <summary>�H�w���</summary>
        public DateTime INV_POSTDTTM;
        /// <summary>�h�f���B</summary>
        public int INV_RETURNAMT = 0;
        /// <summary>�h�f�Ƶ�</summary>
        public string INV_RETURNCOMMENT = "";
        /// <summary>�h�f���</summary>
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
