using System;
using System.Framework;
using System.Framework.DataLayer;

namespace System.DataLayer.Views
{
    /// <summary>
    /// Account 的摘要描述。
    /// </summary>
    public class InventroyRPTInfo : BaseView
    {
        #region Name Config
        public enum ncConditions { code, name, importSDTTM, importEDTTM, exportSDTTM, exportEDTTM, status, dealer , postSDTTM , postEDTTM , returnSDTTM, returnEDTTM }
        public enum ncFields { INV_SERNO, INV_NAME , SERNOLIST , ITEMTOTAL, INAMT , OUTAMT , POSTAMT , RETURNAMT }
        public enum ncSort { Default }
        #endregion

        #region Fields

        /// <summary>序號</summary>
        public string INV_SERNO = "";
        /// <summary>機型</summary>
        public string INV_NAME = "";
        /// <summary>序號列</summary>
        public string SERNOLIST = "";
        /// <summary>商品總數</summary>
        public string ITEMTOTAL = "";
        /// <summary>進貨總額</summary>
        public int INAMT = 0;
        /// <summary>出貨總額</summary>
        public int OUTAMT = 0;
        /// <summary>寄庫總額</summary>
        public int POSTAMT = 0;
        /// <summary>退貨總額</summary>
        public int RETURNAMT = 0;

        #endregion

        public void condFormat(string cond)
        {
            base.Fields = string.Format(base.Fields, cond);
        }

        public InventroyRPTInfo(IConnection AConn)
            : base(AConn)
        {
            base.Fields = @" INV_NAME, STUFF(( SELECT  ',' + INV_SERNO FROM INVENTORY T WHERE INV_NAME=MAIN.INV_NAME {0} FOR XML PATH( '' )), 1 , 1 , '' ) AS SERNOLIST
                        ,COUNT(*) AS ITEMTOTAL
                        ,SUM(CASE INV_STATUS WHEN  '"+ InventoryStatus.庫存中 + @"' THEN INV_INAMT ELSE 0 END) AS INAMT
                        ,SUM(CASE INV_STATUS WHEN  '" + InventoryStatus.已出貨 + @"' THEN INV_OUTAMT ELSE 0 END) AS OUTAMT
                        ,SUM(CASE INV_STATUS WHEN  '" + InventoryStatus.寄庫品 + @"' THEN INV_POSTAMT ELSE 0 END) AS POSTAMT
                        ,SUM(CASE INV_STATUS WHEN  '" + InventoryStatus.進貨退出 + @"' THEN INV_RETURNAMT ELSE 0 END) AS RETURNAMT";
            base.From = "INVENTORY MAIN";
            this.GroupBy = "INV_NAME";

            
            base.ConditionDictionary.Add("code", " INV_CODE like N'%?%' ");
            base.ConditionDictionary.Add("name", " INV_NAME like N'%?%' ");
            base.ConditionDictionary.Add("importSDTTM", " left(INV_INDTTM,10) >= N'?'");
            base.ConditionDictionary.Add("importEDTTM", " left(INV_INDTTM,10) <= N'?'");
            base.ConditionDictionary.Add("exportSDTTM", " left(INV_OUTDTTM,10) >= N'?'");
            base.ConditionDictionary.Add("exportEDTTM", " left(INV_OUTDTTM,10) <= N'?'");
            base.ConditionDictionary.Add("returnSDTTM", " left(INV_RETURNDTTM,10) >= N'?'");
            base.ConditionDictionary.Add("returnEDTTM", " left(INV_RETURNDTTM,10) <= N'?'");
            base.ConditionDictionary.Add("postSDTTM", " left(INV_POSTDTTM,10) >= N'?'");
            base.ConditionDictionary.Add("postEDTTM", " left(INV_POSTDTTM,10) <= N'?'");
            base.ConditionDictionary.Add("status", " INV_STATUS = N'?' ");
            base.ConditionDictionary.Add("dealer", " INV_OUTDEALER = N'?' ");


            base.OrderByDictionary.Add("Default", " INV_NAME desc ");
            base.OrderByDictionary.Add("dgvInventory_Name", " INV_NAME ");
            base.OrderByDictionary.Add("dgvInventory_Count", " ITEMTOTAL ");
            base.OrderByDictionary.Add("dgvInventory_INAMT", " INAMT ");
            base.OrderByDictionary.Add("dgvInventory_OUTAMT", " OUTAMT ");
            base.OrderByDictionary.Add("dgvInventory_POSTAMT", " POSTAMT ");
            base.OrderByDictionary.Add("dgvInventory_RETURNAMT", " RETURNAMT ");
        }
       

    }

}
