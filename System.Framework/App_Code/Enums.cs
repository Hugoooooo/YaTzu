using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Framework
{
    #region Audit
    /// <summary>
    /// Audit Action
    /// </summary>
    public class AuditAction
    {
        /// <summary>登入系統作業</summary>
        public static string Login = "Login";
        /// <summary>登出系統作業</summary>
        public static string Logout = "Logout";
        /// <summary>更換密碼</summary>
        public static string ResetPassword = "Reset Password";
        /// <summary>更新資料-一般作業</summary>
        public static string UpdateProcess = "Update Process";
        /// <summary>刪除資料-一般作業</summary>
        public static string DeleteProcess = "Delete Process";
        /// <summary>新增資料-一般作業</summary>
        public static string CreateProcess = "Create Process";
        /// <summary>查詢資料-一般作業</summary>
        public static string InqueryProcess = "Inquery Process";
        /// <summary>更新-權限資料作業</summary>
        public static string UpdateAutho = "Update Autho";
        /// <summary>刪除-權限資料作業</summary>
        public static string DeleteAutho = "Delete Autho";
        /// <summary>新增-權限資料作業</summary>
        public static string CreateAutho = "Create Autho";
        /// <summary>查詢-權限資料作業</summary>
        public static string InqueryAutho = "Inquery Autho";
        /// <summary>一般功能作業</summary>
        public static string Function = "Function";
        /// <summary>更新-付款資料作業</summary>
        public static string UpdatePayment = "Update Payment";
        /// <summary>刪除-付款資料作業</summary>
        public static string DeletePayment = "Delete Payment";
        /// <summary>新增-付款資料作業</summary>
        public static string CreatePayment = "Create Payment";
        /// <summary>查詢-付款資料作業</summary>
        public static string InqueryPayment = "Inquery Payment";
        /// <summary>系統登出作業</summary>
        public static string SystemLogout = "System Logout";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Login": return "登入系統作業";
                case "Logout": return "登出系統作業";
                case "Reset Password": return "更換密碼";
                case "Update Process": return "更新資料-一般作業";
                case "Delete Process": return "刪除資料-一般作業";
                case "Create Process": return "新增資料-一般作業";
                case "Inquery Process": return "查詢資料-一般作業";
                case "Update Autho": return "更新-權限資料作業";
                case "Delete Autho": return "刪除-權限資料作業";
                case "Create Autho": return "新增-權限資料作業";
                case "Inquery Autho": return "查詢-權限資料作業";
                case "Function": return "一般功能作業";
                case "Update Payment": return "更新-付款資料作業";
                case "Delete Payment": return "刪除-付款資料作業";
                case "Create Payment": return "新增-付款資料作業";
                case "Inquery Payment": return "查詢-付款資料作業";
                case "System Logout": return "系統登出作業";
                default: return "";
            }
        }
    }
    /// <summary>
    /// Audit Status
    /// </summary>
    public class AuditStatus
    {
        /// <summary>處理達成</summary>
        public static string Success = "Success";
        /// <summary>處理無法達成</summary>
        public static string Fail = "Fail";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Success": return "處理達成";
                case "Fail": return "處理無法達成";
                default: return "";
            }
        }
    }
    #endregion

    public enum commands
    {
        checkDBConnect = 255
    }

    #region YaTzu
    public enum ShowBoxType
    {
        confirm,
        alert
    }

    public enum mode
    {
        Edit,
        Add,
        View
    }

    public enum YESNO
    {
        Y,
        N
    }

    public enum PhraseCategory
    {
        收入類別,
        銷售商品資訊,
        案件負責人
    }

    public enum InventoryStatus
    {
        寄庫品,
        庫存中,
        已出貨,
        進貨退出
    }

    public enum SortMode
    {
        [Description("Ascending")]
        ASC,
        [Description("Descending")]
        DESC
    }
    #endregion
}
