using System;

namespace System.DataLayer
{
    //規則: 欄位名稱(不用資料表前置碼及底線) + "Type"
    /// <summary>
    /// 是否
    /// </summary>
    public class YesNo
    {
        /// <summary>是</summary>
        public static string Yes = "Y";
        /// <summary>否</summary>
        public static string No = "N";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// 
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Y": return "是";
                case "N": return "否";
                default: return "";
            }
        }
    }
    public class TrueFalse
    {
        /// <summary>True</summary>
        public static string True = "1";
        /// <summary>False</summary>
        public static string False = "0";
        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "假";
                case "1": return "真";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 螢幕高度
    /// </summary>
    public class ScreenType
    {
        /// <summary>全螢幕</summary>
        public static string Whole = "W";
        /// <summary>半螢幕</summary>
        public static string Half = "H";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "W": return "全螢幕";
                case "H": return "半螢幕";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 客製化報表
    /// </summary>
    public class CustomReport
    {
        /// <summary>花旗專案客製化報表</summary>
        public static string CITI = "CITI";
        /// <summary>花旗保誠專案客製化報表</summary>
        public static string CITIPCA = "CITIPCA";
        /// <summary>中信專案客製化報表</summary>
        public static string TRUST = "TRUST";
        /// <summary>遠銀專案客製化報表</summary>
        public static string FEIB = "FEIB";
        /// <summary>荷銀專案客製化報表</summary>
        public static string ABN = "ABN";
        /// <summary>聯邦專案客製化報表</summary>
        public static string UB = "UB";
        /// <summary>投資型專案客製化報表</summary>
        public static string VNLS = "VNLS";
        /// <summary>渣打專案客製化報表</summary>
        public static string SCB = "SCB";
        /// <summary>不使用</summary>
        public static string NONE = "NONE";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "CITI": return "花旗專案客製化報表";
                case "CITIPCA": return "花旗保誠專案客製化報表";
                case "TRUST": return "中信專案客製化報表";
                case "FEIB": return "遠銀專案客製化報表";
                case "ABN": return "荷銀專案客製化報表";
                case "UB": return "聯邦專案客製化報表";
                case "VNLS": return "投資型專案客製化報表";
                case "SCB": return "渣打專案客製化報表";
                case "NONE": return "不使用";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 花旗類別
    /// </summary>
    public class CitiType
    {
        /// <summary>花旗全球</summary>
        public static string AEGON = "AEGON";
        /// <summary>花旗外包</summary>
        public static string Outsourcing = "Outsourcing";
        /// <summary>不使用</summary>
        public static string NONE = "NONE";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "AEGON": return "全球專案";
                case "Outsourcing": return "外包專案";
                case "NONE": return "不使用";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 投保對象
    /// </summary>
    public class InsuredType
    {
        /// <summary>本人</summary>
        public static string Self = "Self";
        /// <summary>子女一</summary>
        public static string Child1 = "Child1";
        /// <summary>子女二</summary>
        public static string Child2 = "Child2";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Self": return "本人";
                case "Child1": return "子女一";
                case "Child2": return "子女二";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 文件類別
    /// </summary>
    public class DocumentType
    {
        /// <summary>DM</summary>
        public static string DM = "DM";
        /// <summary>要保書</summary>
        public static string Application = "Application";
        /// <summary>問卷</summary>
        public static string Inquire = "Inquire";
        /// <summary>保單條款</summary>
        public static string Insurance = "Insurance";
        /// <summary>保單樣本</summary>
        public static string Policy = "Policy";
        /// <summary>新契約問卷</summary>
        public static string NBInquire = "NBInquire";
        /// <summary>保服表單</summary>
        public static string POM = "POM";
        /// <summary>保誠朋友卡</summary>
        public static string PCALife = "PCALife";
        /// <summary>H2G文宣</summary>
        public static string H2G = "H2G";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "DM": return "建議書";
                case "Application": return "要保書";
                case "Inquire": return "問卷";
                case "Insurance": return "保單條款";
                case "Policy": return "保單樣本";
                case "NBInquire": return "新契約問卷";
                case "POM": return "保服表單";
                case "PCALife": return "保誠朋友卡";
                case "H2G": return "H2G文宣";

                default:
                    return "";
            }
        }
    }

    /// <summary>
    /// 文件套印前工作類別
    /// </summary>
    public class DocumentWorkType
    {
        /// <summary>無</summary>
        public static string None = "None";
        /// <summary>試算表</summary>
        public static string Calculation = "Calculation";
        /// <summary>填寫要保書</summary>
        public static string Application = "Application";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "None": return "無";
                case "Calculation": return "試算表";
                case "Application": return "填寫要保書";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 滿期保險金種類
    /// </summary>
    public class ExpireType
    {
        /// <summary>計算滿期保險金</summary>
        public static string P = "P";
        /// <summary>年繳化保費</summary>
        public static string Y = "Y";
        /// <summary>年繳保費</summary>
        public static string T = "T";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "P": return "計算滿期保險金";
                case "Y": return "年繳化保費";
                case "T": return "年繳保費";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 基金標的分類
    /// </summary>
    public class FundTargetCategory
    {
        /// <summary>僅選擇結構型債券及新台幣貨幣存款帳戶者</summary>
        public static string A = "A";
        /// <summary>其他</summary>
        public static string B = "B";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "僅選擇結構型債券及新台幣貨幣存款帳戶者";
                case "B": return "其他";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 基金標的配置類別
    /// </summary>
    public class FundTargetConfigureType
    {
        /// <summary>積極型</summary>
        public static string A = "A";
        /// <summary>成長型</summary>
        public static string B = "B";
        /// <summary>穩健型</summary>
        public static string C = "C";
        /// <summary>安穩型</summary>
        public static string D = "D";
        /// <summary>保守型</summary>
        public static string E = "E";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "積極型";
                case "B": return "成長型";
                case "C": return "穩健型";
                case "D": return "安穩型";
                case "E": return "保守型";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 費率類別
    /// </summary>
    public class PlanRateType
    {
        /// <summary>VNL</summary>
        public static string VNL = "VN";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "VN": return "參考保險費費率表";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 險種組合類別
    /// </summary>
    public class PlanComposeType
    {
        /// <summary>傳統型</summary>
        public static string Tradition = "A";
        /// <summary>投資型</summary>
        public static string Invest = "B";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "傳統型";
                case "B": return "投資型";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 工作日種類
    /// </summary>
    public class WorkDateType
    {
        /// <summary>固定例假日</summary>
        public static string Fix = "1";
        /// <summary>特定例假日</summary>
        public static string Speciall = "2";
        /// <summary>補班日</summary>
        public static string Suplly = "3";
        /// <summary>結績日</summary>
        public static string Count = "4";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "1": return "固定例假日";
                case "2": return "特定例假日";
                case "3": return "補班日";
                case "4": return "結績日";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 工作記錄種類
    /// </summary>
    public class WorkTimeType
    {
        /// <summary>登入</summary>
        public static string Login = "0";
        /// <summary>登出</summary>
        public static string Logout = "1";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "登入";
                case "1": return "登出";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 工作記錄來源
    /// </summary>
    public class WorkTimeSource
    {
        /// <summary>應用程式</summary>
        public static string Application = "0";
        /// <summary>交換機</summary>
        public static string PBX = "1";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "應用程式";
                case "1": return "交換機";
                default: return "";
            }
        }
    }

    /// <summary>
    /// EMail狀態
    /// </summary>
    public class EMailStatus
    {
        /// <summary>等待套印</summary>
        public static string WaitMerge = "0";
        /// <summary>等待發送</summary>
        public static string WaitEMail = "1";
        /// <summary>發送成功</summary>
        public static string Success = "2";
        /// <summary>發送失敗</summary>
        public static string Fail = "3";
        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "等待套印";
                case "1": return "等待發送";
                case "2": return "發送成功";
                case "3": return "發送失敗";
                default: return "";
            }
        }
    }

    /// <summary>
    /// EMail結果
    /// </summary>
    public class EMailResult
    {
        /// <summary>尚未發送</summary>
        public static string NotSent = "0";
        /// <summary>發送成功</summary>
        public static string Sent = "1";
        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "尚未發送";
                case "1": return "發送成功";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 傳真狀態
    /// </summary>
    public class FaxStatus
    {
        /// <summary>等待處理</summary>
        public static string WaitProcess = "0";
        /// <summary>發送成功</summary>
        public static string Success = "1";
        /// <summary>處理中</summary>
        public static string Processing = "2";
        /// <summary>等待發送中</summary>
        public static string WaitSend = "3";
        /// <summary>無人接聽</summary>
        public static string NoAnswer = "4";
        /// <summary>對方掛線</summary>
        public static string Hangup = "5";
        /// <summary>發送傳真中失敗</summary>
        public static string Fail = "6";
        /// <summary>發送傳真協定溝通時失敗</summary>
        public static string CommunicateFail = "7";
        /// <summary>對方未按Start鍵</summary>
        public static string NotStart = "8";
        /// <summary>發送中</summary>
        public static string Sending = "9";
        /// <summary>取消作業</summary>
        public static string Cancel = "10";
        /// <summary>等待套印</summary>
        public static string WaitMerge = "99";
        /// <summary>過期文件,已由系統自動刪除</summary>
        public static string Delete = "88";
        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "等待處理";
                case "1": return "發送成功";
                case "2": return "處理中";
                case "3": return "等待發送中";
                case "4": return "無人接聽";
                case "5": return "對方掛線";
                case "6": return "發送傳真中失敗";
                case "7": return "發送傳真協定溝通時失敗";
                case "8": return "對方未按Start鍵";
                case "9": return "發送中";
                case "10": return "取消作業";
                case "99": return "等待套印";
                case "88": return "過期文件,已由系統自動刪除";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 成交結轉狀態
    /// </summary>
    public class DealExportType
    {
        /// <summary>否</summary>
        public static string No = "0";
        /// <summary>是</summary>
        public static string Yes = "1";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "";
                //case "1":	return "●";	
                case "1": return "結轉";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 名單類型
    /// </summary>
    public class RosterType
    {
        /// <summary>首撥名單</summary>
        public static string New = "0";
        /// <summary>回撥名單</summary>
        public static string Followup = "1";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "首撥名單";
                case "1": return "回撥名單";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 保費計算模式
    /// </summary>
    public class PlanComposeRateUseType
    {
        /// <summary>固定保額/固定保費</summary>
        public static string Fix = "0";
        /// <summary>固定保額/依費率計算保費</summary>
        public static string NotFix = "1";
        /// <summary>彈性保額/依費率計算保費</summary>
        public static string NotFixCompose = "2";
        /// <summary>參考保費</summary>
        public static string Premium = "3";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "固定保額/固定保費";
                case "1": return "固定保額/依費率計算保費";
                case "2": return "彈性保額/依費率計算保費";
                case "3": return "參考保費";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 費率指標因子使用類型
    /// </summary>
    public class PlanRateUseType
    {
        /// <summary>職業等級</summary>
        public static string V = "A";
        /// <summary>年齡 + 性別</summary>
        public static string AS = "B";
        /// <summary>職業等級 +  年齡 + 性別</summary>
        public static string VAS = "C";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "職業等級";
                case "B": return "年齡 + 性別";
                case "C": return "職業等級 +  年齡 + 性別";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 費率指標因子不使用
    /// </summary>
    public class PlanRateNoUseType
    {
        /// <summary>不使用</summary>
        public static string VocationLevelNoUse = "0";
        /// <summary>不使用</summary>
        public static string AgeNoUse = "";
        /// <summary>不使用</summary>
        public static string SexNoUse = "";
        /// <summary>不使用</summary>
        public static string PlanRateNoUse = "";
        /// <summary>拒保</summary>
        public static string VocationLevelReject = "7";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "不使用";
                case "": return "不使用";
                case "7": return "拒保";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 頭班等級
    /// </summary>
    public class VocationLevelType
    {
        /// <summary>拒保</summary>
        public static string Refuse = "7";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "7": return "拒保";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 電話名稱類型
    /// </summary>
    public class DefaultProductCategoryNameType
    {
        /// <summary>市調問卷</summary>
        public static string Inquire = "A";
        /// <summary>商品組合</summary>
        public static string ProductCombo = "B";
        /// <summary>險種組合</summary>
        public static string ProductPlan = "C";
        /// <summary>貸款商品</summary>
        public static string ProductLoan = "D";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "市調問卷";
                case "B": return "商品組合";
                case "C": return "險種組合";
                case "D": return "貸款商品";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 電話類型
    /// </summary>
    public class PhoneType
    {
        /// <summary>住家</summary>
        public static string Home = "住家";
        /// <summary>公司</summary>
        public static string Company = "公司";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "住家": return "住家";
                case "公司": return "公司";
                default: return "";
            }
        }

        /// <summary>
        /// 依欄位值取得欄位說明簡稱
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldCommentSimple(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "住家": return "(家)";
                case "公司": return "(公)";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 電話名稱類型
    /// </summary>
    public class TelNameType
    {
        /// <summary>電話一(日) 工具頁</summary>
        public static string PHONE1 = "A";
        /// <summary>電話二(夜) 工具頁</summary>
        public static string PHONE2 = "B";
        /// <summary>電話三(其) 工具頁</summary>
        public static string PHONE3 = "C";
        /// <summary>電話四(其) 工具頁</summary>
        public static string PHONE4 = "F";
        /// <summary>手機一 工具頁</summary>
        public static string MOBILE1 = "D";
        /// <summary>手機二 工具頁</summary>
        public static string MOBILE2 = "E";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "電話一(日)";
                case "B": return "電話二(夜)";
                case "C": return "電話三(其)";
                case "F": return "電話四(其)";
                case "D": return "手機一";
                case "E": return "手機二";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 活動工具頁類型
    /// </summary>
    public class CampaignToolTypes
    {
        /// <summary>活動說明 工具頁</summary>
        public static string ToolDocument = "A";
        /// <summary>行銷話術 工具頁</summary>
        public static string ToolWordFlow = "B";
        /// <summary>Q&A 工具頁</summary>
        public static string ToolQNA = "C";
        /// <summary>保費試算 工具頁</summary>
        public static string ToolContent = "D";
        /// <summary>我的最愛 工具頁</summary>
        public static string ToolFavorite = "E";
        /// <summary>試算表 工具頁</summary>
        public static string ToolCalculation = "F";
        /// <summary>基金資料 工具頁</summary>
        public static string ToolFund = "G";
        /// <summary>行銷話術 工具頁</summary>
        public static string ToolCheckList = "H";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "活動說明";
                case "B": return "行銷話術";
                case "C": return "Q&A";
                case "D": return "保費試算";
                case "E": return "我的最愛";
                case "F": return "試算表";
                case "G": return "基金資料";
                case "H": return "必問項目";
                default: return "";
            }
        }
    }

    /// <summary>
    /// RCF工具頁類型
    /// </summary>
    public class ReconfirmToolTypes
    {
        /// <summary>RCF話術 工具頁</summary>
        public static string ToolWordFlow = "A";
        /// <summary>RCF聯絡紀錄 工具頁</summary>
        public static string ToolRCFRecord = "B";
        /// <summary>RCF約訪名單 工具頁</summary>
        public static string ToolAppointment = "C";
        /// <summary>行銷撥打紀錄 工具頁</summary>
        public static string ToolDialRecord = "D";
        /// <summary>成交記錄 工具頁</summary>
        public static string ToolDialBargain = "E";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "RCF話術";
                case "B": return "RCF聯絡記錄";
                case "C": return "RCF約訪名單";
                case "D": return "行銷撥打記錄";
                case "E": return "成交記錄";
                default: return "";
            }
        }
    }

    /// <summary>
    /// RCF Call Type
    /// </summary>
    public class ReconfirmCallTypes
    {
        /// <summary>未聯絡上</summary>
        public static string UnContact = "AUnContact";
        /// <summary>無人接聽</summary>
        public static string NoBody = "ANoBody";
        /// <summary>n次聯絡不上</summary>
        public static string UnContactOver = "AUnContactOver";
        /// <summary>n次聯絡不上(View使用)</summary>
        public static string UnContactOver1 = "AUnContactOver1";
        /// <summary>RCF/QA進件</summary>
        public static string Success = "ASuccess";
        /// <summary>RCF/QA退件</summary>
        public static string Fail = "AFail";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "AUnContact": return "需再回撥";
                case "ANoBody": return "無人接聽";
                case "AUnContactOver": return "{0}次聯絡不上";
                case "AUnContactOver1": return "次聯絡不上";
                case "ASuccess": return "RC成功";
                case "AFail": return "RC失敗";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 險種主附約
    /// </summary>
    public class ProductPlanOptionType
    {
        /// <summary>主約 模式</summary>
        public static string Master = "A";
        /// <summary>附約 模式</summary>
        public static string Detail = "B";
        /// <summary>全部 模式</summary>
        public static string All = "C";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "主約";
                case "B": return "附約";
                case "C": return "主約+附約";
                default: return "";
            }
        }
    }

    /// <summary>
    /// DM套印險種別
    /// </summary>
    public class DMProductPlanOptionType
    {
        /// <summary>主約 模式</summary>
        public static string Master = "A";
        /// <summary>附約(NCC) 模式</summary>
        public static string DetailNCC = "B";
        /// <summary>全部(QTL) 模式</summary>
        public static string AllQTL = "C";
        /// <summary>主約(NCB) 模式</summary>
        public static string MasterNCB = "D";
        /// <summary>主約(NED) 模式</summary>
        public static string MasterNED = "E";
        /// <summary>主約+副約(BVPA) 模式</summary>
        public static string AllVBPA = "F";
        /// <summary>全部(QTL3X) 模式</summary>
        public static string QTL3X = "G";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "主約";
                case "B": return "附約(NCC)";
                case "C": return "主約+附約(QTL)";
                case "D": return "主約(NCB)";
                case "E": return "主約(NED)";
                case "F": return "主約+附約(BVPA)";
                case "G": return "全部(QTL3X)";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 險種種類
    /// </summary>
    public class ProductPlanType
    {
        /// <summary>團險 模式</summary>
        public static string GroupPlan = "A";
        /// <summary>壽險 模式</summary>
        public static string LifePlan = "B";
        /// <summary>產險 模式</summary>
        public static string Immovable = "C";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "團險";
                case "B": return "壽險";
                case "C": return "產險";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 繳別
    /// </summary>
    public class PayModeType
    {
        /// <summary>年繳 模式</summary>
        public static string Year = "Y";
        /// <summary>半年繳 模式</summary>
        public static string HalfYear = "S";
        /// <summary>季繳 模式</summary>
        public static string Quarter = "Q";
        /// <summary>月繳 模式</summary>
        public static string Month = "M";
        public static string Whole = "W";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Y": return "年繳";
                case "S": return "半年繳";
                case "Q": return "季繳";
                case "M": return "月繳";
                case "W": return "躉繳";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 首期月繳
    /// </summary>
    public class MonthlyPayType
    {
        /// <summary>一個月 模式</summary>
        public static string OneMonth = "1";
        /// <summary>兩個月 模式</summary>
        public static string TwoMonth = "2";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "1": return "一個月";
                case "2": return "兩個月";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 付款模式
    /// </summary>
    public class PayType
    {
        /// <summary>信用卡扣款 模式(保誠使用)</summary>
        public static string Card = "A";
        /// <summary>郵局劃撥 模式</summary>
        public static string PostalTransfer = "B";
        /// <summary>匯款 模式(保誠使用)</summary>
        public static string BankTransfer = "C";
        /// <summary>ATM繳款 模式</summary>
        public static string ATM = "D";
        /// <summary>銀行轉帳 模式(保誠使用)</summary>
        public static string Store = "E";
        /// <summary>自行繳納 模式</summary>
        public static string Self = "F";
        /// <summary>現金 模式</summary>
        public static string Cash = "G";
        /// <summary>帳戶扣款 模式</summary>
        public static string Bank = "H";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "信用卡扣款";
                case "B": return "郵局劃撥";
                case "C": return "匯款"; //銀行匯款
                case "D": return "ATM繳款";
                case "E": return "銀行轉帳";  //"金融機構自動轉帳"; //便利商店繳款
                case "F": return "自行繳納";
                case "G": return "現金";
                case "H": return "帳戶扣款";
                default: return "";
            }
        }
        public static string getCFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "信用卡扣款": return "A";
                case "郵局劃撥": return "B";
                case "銀行匯款":
                case "匯款": return "C";
                case "ATM繳款": return "D";
                case "便利商店繳款":
                case "金融機構自動轉帳": 
                case "銀行轉帳": return "E";
                case "自行繳納": return "F";
                case "現金": return "G";
                case "帳戶扣款": return "H";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 商品佣金模式
    /// </summary>
    public class CommType
    {
        /// <summary>訂價百分比 模式</summary>
        public static string Percentage = "0";
        /// <summary>佣金金額 模式</summary>
        public static string Price = "1";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "訂價百分比";
                case "1": return "佣金金額";
                default: return "";
            }
        }
    }

    /// <summary>
    ///  名單狀態
    /// </summary>
    public class RosterStatusType
    {
        /// <summary>再聯絡 狀態</summary>
        public static string ContactAgain = "0";
        /// <summary>考慮中 狀態</summary>
        public static string ThinkAbout = "1";
        /// <summary>成功 狀態</summary>
        public static string Success = "2";
        /// <summary>行銷失敗 狀態</summary>
        public static string Fail = "3";
        /// <summary>無效名單 狀態</summary>
        public static string Useless = "4";
        /// <summary>客戶拒絕 狀態</summary>
        public static string Fail2 = "5";
        /// <summary>名單問題 狀態</summary>
        public static string Useless2 = "6";
        /// <summary>未撥打 狀態</summary>
        public static string NoDial = "X";
        /// <summary>精華 狀態</summary>
        public static string IsEssence = "E";
        /// <summary>約訪 狀態</summary>
        public static string IsAppoint = "A";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "再聯絡";
                case "1": return "考慮中";
                case "2": return "成功";
                case "3": return "行銷失敗";
                case "4": return "無效名單";
                case "5": return "客戶拒絕";
                case "6": return "名單問題";
                case "X": return "未撥打";
                case "E": return "精華名單";
                case "A": return "約訪名單";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 撥打狀態動作
    /// </summary>
    public class CallTypeActionType
    {
        /// <summary>無動作 動作</summary>
        public static string None = "0";
        /// <summary>選項訊息窗 動作</summary>
        public static string Option = "1";
        /// <summary>開啟成交記錄視窗 動作</summary>
        public static string SuccessSale = "2";
        /// <summary>開啟成交問卷視窗 動作</summary>
        public static string SuccessInquire = "3";
        /// <summary>錯誤電話 動作</summary>
        public static string ErrorPhoneNumber = "4";
        /// <summary>約訪 動作</summary>
        public static string Appointment = "5";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "無動作";
                case "1": return "選項訊息窗";
                case "2": return "開啟成交記錄視窗";
                case "3": return "開啟成交問卷視窗";
                case "4": return "錯誤電話";
                case "5": return "約訪名單";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 撥打狀態
    /// </summary>
    public class CallType1
    {
        /// <summary>本人接聽</summary>
        public static string myself = "0";
        /// <summary>不願電銷</summary>
        public static string unwilling1 = "1";
        /// <summary>不願電銷</summary>
        public static string unwilling5 = "5";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "本人接聽";
                case "1": return "不願電銷";
                case "5": return "不願電銷";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 工作狀態
    /// </summary>
    public class JobStatus
    {
        public static string UnCompleted = "未完成";
        public static string Canceled = "取消";
        public static string Completed = "已完成";
    }

    /// <summary>
    /// 工作優先權
    /// </summary>
    public class JobPriority
    {
        public static string Highest = "最高";
        public static string High = "次高";
        public static string Normal = "普通";
        public static string Low = "次低";
        public static string Lowest = "最低";
    }

    /// <summary>
    /// 問卷顯示模式
    /// </summary>
    public class InquireShowWay
    {
        /// <summary>單題顯示 模式</summary>
        public static string Single = "0";
        /// <summary>整份顯示 模式</summary>
        public static string All = "1";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "單題顯示";
                case "1": return "整份顯示";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 問卷題目類型
    /// </summary>
    public class InquireQuestionType
    {
        /// <summary>單選題 類型</summary>
        public static string SingleOption = "1";
        /// <summary>複選題 模式</summary>
        public static string MultiOption = "2";
        /// <summary>排序題 模式</summary>
        public static string SortOption = "3";
        /// <summary>問答題 模式</summary>
        public static string Input = "4";
        /// <summary>問卷答案 模式</summary>
        public static string InquireAnswer = "X";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "問卷調查開始";
                case "1": return "單選題";
                case "2": return "複選題";
                case "3": return "排序題";
                case "4": return "問答題";
                case "X": return "問卷答案";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 問卷調查狀態
    /// </summary>
    public class DialInquireStatus
    {
        /// <summary>未填寫 狀態</summary>
        public static string None = "0";
        /// <summary>已填寫 狀態</summary>
        public static string Complete = "1";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "未填寫";
                case "1": return "已填寫";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 活動狀態
    /// </summary>
    public class CampaignStatus
    {
        /// <summary>未啟用 狀態</summary>
        public static string NotEnabled = "0";
        /// <summary>啟用 狀態</summary>
        public static string Enable = "1";
        /// <summary>中止 狀態</summary>
        public static string Stop = "2";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "未啟用";
                case "1": return "啟用";
                case "2": return "停用";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 活動參與者身分
    /// </summary>
    public class CampaignParticipantsTarget
    {
        /// <summary>組別 身分</summary>
        public static string Team = "0";
        /// <summary>訪員 身分</summary>
        public static string TSR = "1";
        /// <summary>分發員 身分</summary>
        public static string Dispatcher = "2";
        /// <summary>管理者 身分</summary>
        public static string Manager = "3";
        /// <summary>Monitor 身分</summary>
        public static string Monitor = "4";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "組別";
                case "1": return "訪員";
                case "2": return "分派員";
                case "3": return "管理者";
                case "4": return "Monitor人員";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 名單姓別
    /// </summary>
    public class RosterSex
    {
        /// <summary>男</summary>
        public static string Man = "M";
        /// <summary>女</summary>
        public static string Feminie = "F";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "M": return "男";
                case "F": return "女";
                default: return "";
            }
        }

        public static string getFieldTitle(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "M": return "先生";
                case "F": return "小姐";
                default: return "";
            }
        }
    }

    public class CheckType
    {
        /// <summary>選取</summary>
        public static string Yes = "T";
        /// <summary>未選取</summary>
        public static string No = "F";

        public static string getFieldLabel(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "T": return "■";
                case "F": return "□";
                default: return "";
            }
        }
    }

    public class DateType
    {
        /// <summary>年</summary>
        public static string Year = "Year";
        /// <summary>月</summary>
        public static string Month = "Month";
        /// <summary>日</summary>
        public static string Day = "Day";

        public static string getFieldLabel(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Year": return "年";
                case "Month": return "月";
                case "Day": return "日";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 名單電話狀態
    /// </summary>
    public class RosterPhoneStatus
    {
        /// <summary>錯誤電話</summary>
        public static string Error = "0";
        /// <summary>限用電話</summary>
        public static string Only = "1";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "錯誤電話";
                case "1": return "限用電話";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 布林值對應資料庫儲存的值
    /// </summary>
    public class DBBooleanType
    {
        /// <summary>偽</summary>
        public static string False = "0";
        /// <summary>真</summary>
        public static string True = "1";
    }

    public class FieldMapping
    {
        public static string getRosterFieldName(string aField)
        {
            switch (aField)
            {
                /// <summary>身分證字號</summary>
                case "RST_ID": return "身分證號";
                /// <summary>姓名</summary>
                case "RST_NAME": return "姓名";
                /// <summary>保險年齡</summary>
                case "InsuranceAge": return "保險年齡";
                /// <summary>性別</summary>
                case "Gender": return "性別";
                /// <summary>出生日期</summary>
                case "RST_BIRDT": return "出生日期";
                /// <summary>電話一</summary>
                case "RST_PHONE1": return "電話一";
                /// <summary>電話二</summary>
                case "RST_PHONE2": return "電話二";
                /// <summary>電話三</summary>
                case "RST_PHONE3": return "電話三";
                /// <summary>電話四</summary>
                case "RST_PHONE4": return "電話四";
                /// <summary>手機一</summary>
                case "RST_MOBILE1": return "手機一";
                /// <summary>手機二</summary>
                case "RST_MOBILE2": return "手機二";
                /// <summary>傳真號碼</summary>
                case "RST_FAX": return "傳真號碼";
                /// <summary>電子郵件信箱</summary>
                case "RST_EMAIL": return "電子郵件信箱";
                /// <summary>公司名稱</summary>
                case "RST_COMPANY": return "公司名稱";
                /// <summary>職稱</summary>
                case "RST_JOB": return "職稱";
                /// <summary>銀行名稱</summary>
                case "RST_BANKNAME": return "銀行名稱";
                /// <summary>帳號類型</summary>
                case "RST_ACCOUNTTYPE": return "帳號類型";
                /// <summary>郵遞區號</summary>
                case "RST_POSTCODE1": return "郵遞區號";
                /// <summary>通訊位址</summary>
                case "RST_ADDR1": return "通訊位址";
                /// <summary>自定欄位四</summary>
                case "RST_CUSTFIELD4": return "自定欄位四";
                /// <summary>自定欄位四</summary>
                case "RST_LCALLTYPE5": return "撥打狀態名稱";

                default: return "";
            }
        }
    }

    public class DispatchStatus
    {
        /// <summary>Batch分派</summary>
        public static int Dispatch = 0;
        /// <summary>Batch回收</summary>
        public static int Recycle = 1;
        /// <summary>單筆修改</summary>
        public static int SingleUpdate = 3;
        /// <summary>Emp分派</summary>
        public static int EmpDispatch = 4;
        /// <summary>Emp回收</summary>
        public static int EmpRecycle = 5;
    }

    /// <summary>
    /// 退件狀態
    /// </summary>
    public class RejectStatus
    {
        /// <summary>保全件</summary>
        public static string ReconfirmReject = "2";
        /// <summary>退件</summary>
        public static string Reject = "1";
        /// <summary>新件</summary>
        public static string NotReject = "0";
        public static string getFieldComment(string status)
        {
            switch (status)
            {
                case "2":
                    //return "保全件";
                    return "重新送審";
                case "1":
                    return "退件";
                case "0":
                    return "新件送審";
                default:
                    return "";
            }
        }
    }
    /// <summary>
    /// 進件狀態
    /// </summary>
    public class IsReapply
    {

        /// <summary>重新進件</summary>
        public static string Reapply = "1";
        /// <summary>新件</summary>
        public static string NotReapply = "0";

        public static string getFieldReapply(string status)
        {
            switch (status)
            {
                case "1":
                    return "重新進件";
                case "0":
                    return "新件";
                default:
                    return "";
            }
        }
    }

    /// <summary>
    /// Reconfirm類別
    /// </summary>
    public class ReconfirmType
    {
        /// <summary>新件</summary>
        public static string New = "0";
        /// <summary>保全件</summary>
        public static string Pos = "1";
        /// <summary>授權件</summary>///已rcf成功的件~但在之後的節點被退
        public static string RCF = "2";

        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "0": return "新件";
                case "1": return "保全件";
                case "2": return "授權件";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 成交類別
    /// </summary>
    public class DialBargainType
    {
        /// <summary>線上成交</summary>
        public static string Online = "1";
        /// <summary>書面進件成交</summary>
        public static string Fax = "2";
        /// <summary>依健康核保規則判定線上或書面進件成交</summary>
        public static string Underwriting = "3";

        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "1": return "MPG";
                case "2": return "人工MPG";
                case "3": return "依健康核保規則判定MPG或人工MPG成交";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 成交流成節點
    /// </summary>
    public class BargainFlowNode
    {
        /// <summary>依據Dialbargain上Current Item處理</summary>
        public static string ByFlow = "";
        /// <summary>TSR送審</summary>
        public static string Start = "Start";
        /// <summary>TSM覆核</summary>
        public static string Recheck = "Recheck";
        /// <summary>Reconfirm</summary>
        public static string Reconfirm = "Reconfirm";
        /// <summary>成教結轉</summary>
        public static string Closed = "Closed";
        public static string getStatusFieldName(string status)
        {
            switch (status)
            {
                case "Start":
                    return "TSR送審";
                case "Recheck":
                    return "TSR覆核";
                case "Reconfirm":
                    return "Reconfirm";
                case "Closed":
                    return "成交結轉";
                default:
                    return "";
            }
        }
    }
    
    /// <summary>
    /// 成交記錄狀態
    /// </summary>
    public class BargainFlowStatus
    {
        /// <summary>待訪員繼續處理的案件</summary>
        public static string InProcess = "InProcess";
        /// <summary>待訪員追蹤處理的退件</summary>
        public static string Reject = "Reject";
        /// <summary>待分派</summary>
        public static string Dispatch = "Dispatch";
        /// <summary>待覆核</summary>
        public static string Recheck = "Recheck";
        //	/// <summary>待結案</summary>
        public static string Close = "Close";
        /// <summary>已結案</summary>
        public static string Closed = "Closed";
        /// <summary>撤件</summary>
        public static string Withdraw = "Withdraw";
        /// <summary>Reconfirm</summary>
        public static string Reconfirm = "Reconfirm";
        /// <summary>已結轉</summary>
        public static string Exported = "Exported";
        /// <summary>行政授權</summary>
        public static string Authorize = "Authorize";
        /// <summary>行政覆核</summary>
        public static string Adcheck = "Adcheck";
        public static string getStatusFieldName(string status)
        {
            switch (status)
            {
                case "InProcess":
                    return "處理中";
                case "Reject":
                    return "退件";
                case "Dispatch":
                    return "待分派";
                case "Recheck":
                    return "待覆核";
                //	case "Close" :
                //	return "待結案";
                case "Closed":
                    return "已結案";
                case "Withdraw":
                    return "撤件";
                case "Reconfirm":
                    return "Reconfirm";
                case "Exported":
                    return "已結轉";
                case "Adcheck":
                    return "行政覆核";
                case "Authorize":
                    return "行政授權";
                default:
                    return "";
            }
        }
    }

    /// <summary>
    /// PCALife成交記錄狀態
    /// </summary>
    public class PCALifeBargainFlowStatus
    {
        /// <summary>TSM覆核中</summary>
        public static string TSMProcess = "TSMProcess";
        /// <summary>TSM退件</summary>
        public static string TSMReject = "TSMReject";
        /// <summary>RCF審單中</summary>
        public static string RCFProcess = "RCFProcess";
        /// <summary>RCF失敗</summary>
        public static string RCFFail = "RCFFail";
        /// <summary>行政結轉中</summary>
        public static string ADMProcess = "ADMProcess";
        /// <summary>行政已結轉</summary>
        public static string ADMSuccess = "ADMSuccess";
        /// <summary>行政退件</summary>
        public static string ADMReject = "ADMReject";
        public static string getStatusFieldName(string status)
        {
            switch (status)
            {
                case "TSMProcess":
                    return "TSM覆核中";
                case "TSMReject":
                    return "TSM退件";
                case "RCFProcess":
                    return "RCF審單中";
                case "RCFFail":
                    return "RCF退件";
                case "ADMProcess":
                    return "行政結轉中";
                case "ADMSuccess":
                    return "行政已結轉";
                case "ADMReject":
                    return "行政退件";
                default:
                    return "";
            }
        }
    }

    public class BargainFlowMethod
    {
        /// <summary>通過</summary>
        public static string Pass = "Pass";
        /// <summary>退件</summary>
        public static string Reject = "Reject";
        /// <summary>結案</summary>
        public static string Close = "Closed";
        public static string getMethodFieldName(string method)
        {
            switch (method)
            {
                case "Reject":
                    return "退件";
                case "Pass":
                    return "通過";
                case "Closed":
                    return "已結案";
                default:
                    return "";
            }
        }
    }

    /// <summary>
    /// View中所使用到的一般訊息
    /// </summary>
    public class ViewMessage
    {
        public static string Hour = "小時";
    }

    /// <summary>
    /// 成交流程錯誤代碼
    /// </summary>
    public class BargainFlowErrorCode
    {
        public static string NotFoundUser = "接收者可能已離職,或該帳號已停用!";
        public static string NotNextNode = "找不到下一個流程節點!";
        public static string NotEnoughPolicy = "沒有保單號碼可分派，無法覆核!";
        public static string NotFoundCloseNode = "沒有任何結束點!";
        public static string RecheckMustTwoLine = "複核節點必須要各有一條透過線和退件線!";
        public static string NotEnoughPolicyNotify = "《{0}》保單號碼警示通知!!!";
        public static string NotEnoughPolicyMessage = "提醒您，活動{0}剩餘可用保單號碼數為{1}，請記得在使用完畢前至“行銷活動維護”作業重新設定!";
    }

    public class ReportMessage
    {
        public static string RejectReason = "退件原因";
        public static string ContactFailHeader = "期間連絡未遇";
        public static string ContactFailDetail = "{0}次(含)以上聯絡不到";
    }

    public class WordFlowMessage
    {
        public static string CodeOrNameExist = "行銷話術流程代碼或名稱已存在";
        public static string CodeExist = "行銷話術流程代碼已存在";
        public static string NameExist = "行銷話術流程名稱已存在";
    }

    public class DialFlowMessage
    {
        public static string CodeOrNameExist = "撥打狀態流程代碼或名稱已存在";
        public static string CodeExist = "撥打狀態流程代碼已存在";
        public static string NameExist = "撥打狀態流程名稱已存在";
    }

    public class QuestionMessage
    {
        public static string Yes = "是";
        public static string No = "否";
    }

    public class WeeklyName
    {
        public static string Sunday = "星期日";
        public static string Monday = "星期一";
        public static string Tuesday = "星期二";
        public static string Wednesday = "星期三";
        public static string Thursday = "星期四";
        public static string Friday = "星期五";
        public static string Saturday = "星期六";

        public static string getWeeklyName(string num)
        {
            switch (num)
            {
                case "0":
                case "7": return WeeklyName.Sunday;
                case "1": return WeeklyName.Monday;
                case "2": return WeeklyName.Tuesday;
                case "3": return WeeklyName.Wednesday;
                case "4": return WeeklyName.Thursday;
                case "5": return WeeklyName.Friday;
                case "6": return WeeklyName.Saturday;
                default: return "";
            }
        }
    }

    public class ProductPlanPayType
    {
        public static string getPayTypeName(string code)
        {
            switch (code)
            {
                case "1": return "按基本保額";
                case "2": return "退還保費";
                default: return "無還本給付";
            }
        }
    }

    /// <summary>
    /// 問卷調查匯出欄位
    /// </summary>
    public class InquireExportField
    {
        public enum FieldName { IRT_CAPNAME, IRT_RTANAME, IRT_EMPNAME, IRT_RSTNAME, IRT_IQQCODE, IRT_IQQNAME, IRT_LPDTTM, IRD_TYPE, IRD_SEQUENCE, IRD_CONTENT, IRD_ANSWER }
        public static string getInquireField(string code)
        {
            switch (code)
            {
                case "IRT_CAPNAME": return "活動名稱";
                case "IRT_RTANAME": return "名單代號";
                case "IRT_EMPNAME": return "訪員姓名";
                case "IRT_RSTNAME": return "客戶姓名";
                case "IRT_IQQCODE": return "問卷代碼";
                case "IRT_IQQNAME": return "問卷名稱";
                case "IRT_LPDTTM": return "問卷調查日期";
                case "IRD_TYPE": return "題目類型";
                case "IRD_SEQUENCE": return "題目順序";
                case "IRD_CONTENT": return "題目內容";
                case "IRD_ANSWER": return "答案";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 婚姻狀況
    /// </summary>
    public class Married
    {
        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Y": return "已婚";
                case "N": return "未婚";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 子女狀況
    /// </summary>
    public class HaveChild
    {
        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Y": return "有";
                case "N": return "  ";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 來電服務項目處理作業
    /// </summary>
    public class ServiceItemProcess
    {
        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "online": return "線上回覆處理";
                case "none": return "無";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 貸款商品照會電話項目
    /// </summary>
    public class ProductLoanNote
    {
        public enum Type { Phone1, Phone2, Phone3, Mobile1, Mobile2, Contact, Call104, Bank, Labor, TaxBureau }
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Phone1": return "公司電話";
                case "Phone2": return "現住電話";
                case "Phone3": return "戶籍電話";
                case "Mobile1": return "手機一";
                case "Mobile2": return "手機二";
                case "Contact": return "照會連絡人電話";
                case "Call104": return "電話查詢104/105";
                case "Bank": return "照會銀行/郵局";
                case "Labor": return "照會勞保局";
                case "TaxBureau": return "照會國稅局";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 貸款照會電話狀況
    /// </summary>
    public class ProductLoanNoteStatus
    {
        public static string NoPerson = "A";
        public static string OK = "B";
        public static string NO = "C";
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "無人接聽";
                case "B": return "正常";
                case "C": return "異常";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 貸款商品核准層級
    /// </summary>
    public class ProductLoanApproveClass
    {
        public enum Type { A, B, C }
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "科長核准";
                case "B": return "副理核准";
                case "C": return "經理核准";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 案件取消類別
    /// </summary>
    public class DialBargainCancelType
    {
        public enum Type { CustomerReason, OperatorReason }

        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "CustomerReason": return "客戶自行取消";
                case "OperatorReason": return "承辦人員拒絕";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 審核狀況
    /// </summary>
    public class DialBargainRecheckStatus
    {
        public static string RecheckOK = "A";
        public static string DocNotComplete = "B";
        public static string NoteNotFinish = "C";
        public static string NotTheorem = "D";
        public static string RecheckComplete = "E";

        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "已經通過審核.";
                case "B": return "檢附文件不完整.";
                case "C": return "未完成照會.";
                case "D": return "未通過授信五原則.";
                case "E": return "審核內容完整.";
                default: return "尚未執行審核工作.";
            }
        }
    }

    /// <summary>
    /// 教育程度
    /// </summary>
    public class Background
    {
        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string Level1 = "1";
        public static string Level2 = "2";
        public static string Level3 = "3";
        public static string Level4 = "4";
        public static string Level5 = "5";
        public static string Level6 = "6";
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "1": return "高中職";
                case "2": return "大學";
                case "3": return "碩士";
                case "4": return "國中以下";
                case "5": return "碩士以上";
                case "6": return "專科";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 客戶歸屬-婚姻狀況
    /// </summary>
    public class MarriedStatus
    {
        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string Yes = "1";
        public static string No = "2";
        public static string NoData = "3";
        public static string Divorced = "4";
        public static string BSpouse = "5";
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "1": return "已婚";
                case "2": return "未婚";
                case "3": return "其他";
                case "4": return "離婚";
                case "5": return "喪偶";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 是/否狀態
    /// </summary>
    public class YesNoStatus
    {
        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Y": return "是";
                case "N": return "否";
                default: return "否";
            }
        }
    }

    /// <summary>
    /// 貸款付款計算方式
    /// </summary>
    public class ProductLoanFeeType
    {
        public static string ByRate = "A";
        public static string ByProcedure = "B";
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "依利率";
                case "B": return "依手續費比率";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 貸款檢附文件狀況
    /// </summary>
    public class ProductLoanDocStatus
    {
        public static string OK = "A";
        public static string NO = "B";
        public static string NotNote = "C";
        public static string None = "D";
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "正常";
                case "B": return "異常";
                case "C": return "不提供照會";
                case "D": return "不需要照會";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 貸款案件來源
    /// </summary>
    public class ProductLoanSource
    {
        public enum Type { A, B, C }

        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "A": return "外撥電話";
                case "B": return "客戶來電";
                case "C": return "DM通信寄回";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 評分物件項目字串
    /// </summary>
    public class ScorerItemString
    {
        public const string Age = "年齡";
        public const string AnnualIncome = "年收入(萬)";
        public const string AttachDocument = "附加文件";
        public const string Children = "子女人數";
        public const string CustomerTitle = "客戶職稱";
        public const string CustomerTrade = "行業別";
        public const string EducationLevel = "教育程度";
        public const string HouseStatus = "房屋狀況";
        public const string LivingTime = "居住時間(年)";
        public const string MaritalStatus = "婚姻狀況";
        public const string Seniority = "服務年資";
        public const string Sex = "性別";
    }

    /// <summary>
    /// 數字轉換成大寫國字
    /// </summary>
    public class ApplyAmountUpper
    {
        private static string GetNumberChar(int num)
        {
            switch (num)
            {
                case 0: return "零";
                case 1: return "壹";
                case 2: return "貳";
                case 3: return "參";
                case 4: return "肆";
                case 5: return "伍";
                case 6: return "陸";
                case 7: return "柒";
                case 8: return "捌";
                case 9: return "玖";
                case 10: return "拾";
                case 100: return "佰";
                default: return "";
            }
        }

        public static string Change(int Aamount)
        {
            double amount = Aamount;
            string result = "";
            if (amount > 99)
            {
                result = GetNumberChar(Convert.ToInt32(Math.Floor(amount / 100))) + GetNumberChar(100);
                amount = amount - Convert.ToInt32(Math.Floor(amount / 100)) * 100;
                if (Math.Floor(amount / 10) == 0)
                    result += GetNumberChar(0);
            }

            if (amount > 9)
            {
                if (Math.Floor(amount) >= 20)
                    result += GetNumberChar(Convert.ToInt32(Math.Floor(amount / 10))) + GetNumberChar(10);
                else
                    result += GetNumberChar(10);

                amount = amount - Convert.ToInt32(Math.Floor(amount / 10)) * 10;
            }

            if (amount > 0)
                result += GetNumberChar(Convert.ToInt32(amount));

            return result;
        }
    }

    /// <summary>
    /// 傳送申請書方式
    /// </summary>
    public class LoanDialBargainSendType
    {
        public static string EMail = "E";
        public static string Fax = "F";

        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "E": return "電子郵件傳送";
                case "F": return "傳真發送";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 合庫成交記錄狀態
    /// </summary>
    public class LoanBargainFlowStatus
    {
        /// <summary>通過</summary>
        public static string Pass = "Pass";
        /// <summary>退件</summary>
        public static string Reject = "Reject";
        /// <summary>初審中</summary>
        public static string SelfCheck = "SelfCheck";
        /// <summary>審核中</summary>
        public static string Recheck = "Recheck";
        /// <summary>核定中</summary>
        public static string Allow = "Allow";
        /// <summary>撥款結案中</summary>
        public static string Close = "Close";
        /// <summary>已結案</summary>
        public static string Closed = "Closed";
        /// <summary>撤件</summary>
        public static string Cancel = "Cancel";
        public enum Activity { Circular, SelfCheck, Recheck, Allow, Close, Closed };

        public static string getStatusFieldName(string status)
        {
            switch (status)
            {
                case "Pass": return "通過";
                case "Reject": return "退件";
                case "SelfCheck": return "初審中";
                case "Recheck": return "審核中";
                case "Allow": return "核定中";
                case "Close": return "撥款結案中";
                case "Closed": return "已結案";
                case "Cancel": return "撤件";
                default: return "";
            }
        }

        public static string getActivityFieldName(string activity)
        {
            switch (activity)
            {
                case "Circular": return "同意申請";
                case "SelfCheck": return "初審";
                case "Recheck": return "審核";
                case "Allow": return "核定";
                case "Close": return "撥款結案";
                case "Closed": return "已結案";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 專家系統警示項目
    /// </summary>
    public class SystemExpertAlertStatus
    {
        public enum Items
        {
            ApplyAmount, RejectRecord, ApplyRecord, OnBoardTime, Age, LivedTime, Budget,
            DebtRatio, SignatureLoan, IncomeYear
        }

        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "ApplyAmount": return "申請金額較高(萬元)";
                case "RejectRecord": return "幾天內拒貸記錄(天)";
                case "ApplyRecord": return "客戶申請貸款次數(次)";
                case "OnBoardTime": return "到職時間(年)";
                case "Age": return "年齡(年)";
                case "LivedTime": return "居住地年限(年)";
                case "Budget": return "全體行庫無擔保月付款(含本次申貸金額) / 月收入";
                case "DebtRatio": return "客戶負債比,全體行存無擔保貸款的總額 / 月收入";
                case "SignatureLoan": return "無擔保總額(萬元)";
                case "IncomeYear": return "客戶年收入(萬元)";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 黑名單類型
    /// </summary>
    public class SystemRiskType
    {
        public enum Items { ID, Address, Area, BusinessItem, CompanyName }

        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "ID": return "身分證字號";
                case "Address": return "地址";
                case "Area": return "地區";
                case "BusinessItem": return "行業別";
                case "CompanyName": return "公司名稱";
                default: return "";
            }
        }

        public static string getAlertMessage(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "ID": return "黑名單-身分證字號";
                case "Address": return "高風險地區";
                case "Area": return "高風險地區";
                case "BusinessItem": return "高風險行業";
                case "CompanyName": return "黑名單-公司名稱";
                default: return "";
            }
        }
    }
    /// <summary>
    /// 客戶評分屬性項目
    /// </summary>
    public class AttributeGradeType
    {
        public enum Items
        {
            Seniority, CustomerTrade, CustomerTitle, Sex, Age, EducationLevel, MaritalStatus,
            Children, HouseStatus, LivingTime, AnnualIncome, AttachDocument, ScorerItem
        }

        public enum Type { Scope, Term }

        /// <summary>
        /// 取得評分項目的中文名稱
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static string getFieldComment(string attribute)
        {
            switch (attribute)
            {
                case "Seniority": return "年資(年)";
                case "CustomerTrade": return "行業別";
                case "CustomerTitle": return "職稱";
                case "Sex": return "性別";
                case "Age": return "年齡(歲)";
                case "EducationLevel": return "教育程度";
                case "MaritalStatus": return "婚姻狀態";
                case "Children": return "子女人數(人)";
                case "HouseStatus": return "現住房屋狀況";
                case "LivingTime": return "已居住年數(年)";
                case "AnnualIncome": return "年收入(萬元)";
                case "AttachDocument": return "檢附文件";
                case "ScorerItem": return "金融市場整體環境";
                default: return "";
            }
        }

        /// <summary>
        /// 取得評分項目-型態
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static Type getAttributeType(string attribute)
        {
            if (attribute == "Seniority" || attribute == "Age" || attribute == "Children" || attribute == "LivingTime" || attribute == "AnnualIncome")
                return Type.Scope;
            else
                return Type.Term;
        }
    }

    /// <summary>
    /// 失聯名單排序欄位
    /// </summary>
    public class LostContactField
    {
        public static string getFieldComment(string field)
        {
            switch (field)
            {
                case "RST_NAME": return "客戶姓名";
                case "RST_ID": return "身分證字號";
                case "LCT_EMPNAME": return "訪員姓名";
                case "RST_LOANBANK1": return "貸款分行名稱";
                case "RST_LOANACCOUNT1": return "貸款帳號";
                case "RST_SAVEBANK": return "存款分行名稱";
                case "RST_SAVEACCOUNT": return "存款帳號";
                case "LCT_LPDATE": return "最後撥打日期";
                default: return "";
            }
        }
    }

    public class RosterModifyField
    {
        public static string getFieldComment(string field)
        {
            switch (field)
            {
                case "RST_NAME": return "姓名";
                case "RST_ADDR1": return "公司地址";
                case "RST_ADDR2": return "通訊地址";
                case "RST_ADDR3": return "戶籍地址";
                case "RST_BIRDT": return "出生日期";
                case "RST_EMAIL": return "電子郵件";
                case "RST_MOBILE1": return "行動電話";
                case "RST_MOBILE2": return "電話二";
                case "RST_PHONE1": return "公司電話";
                case "RST_PHONE2": return "住家電話";
                case "RST_PHONE3": return "電話一";
                case "EMPNAME": return "歸屬人員";
                default: return "";
            }
        }
    }



    /// <summary>
    /// Mapping狀態
    /// </summary>
    public class BargainFlowMapping
    {
        /// <summary>不需要Mapping</summary>
        public static string NoMapping = "0";
        /// <summary>需要Mapping</summary>
        public static string Mapping = "1";
        /// <summary>Mapping成功</summary>
        public static string MappingSuc = "2";
        /// <summary>Mapping失敗</summary>
        public static string MappingFal = "3";
        /// <summary>花旗Outsourcing Mapping</summary>
        public static string CitiOutsourcingMapping = "4";
        /// <summary>花旗Outsourcing Non-Mapping</summary>
        public static string CitiOutsourcingNonMapping = "5";
        /// <summary>非花旗名單</summary>
        public static string NotMapping = "X";

        public static string getMappingFieldName(string status)
        {
            switch (status)
            {
                case "0":
                    return "不需要Mapping";
                case "1":
                    return "需要Mapping";
                case "2":
                    return "Mapping成功";
                case "3":
                    return "Mapping失敗";
                case "4":
                    return "CITI Outsourcing Mapping";
                case "5":
                    return "CITI Outsourcing Non-Mapping";
                case "X":
                    return "非花旗名單";

                default:
                    return "";
            }
        }
    }

    /// <summary>
    /// 信用卡類別
    /// </summary>
    public class CreditCardType
    {
        /// <summary>VISA</summary>
        public static string VISA = "VISA";
        /// <summary>MASTER</summary>
        public static string MASTER = "MASTER";
        /// <summary>JCB</summary>
        public static string JCB = "JCB";
        /// <summary>聯合信用卡</summary>
        public static string NCC = "NCC";

        public static string getName(string CardType)
        {
            switch (CardType)
            {
                case "VISA":
                    return "VISA";
                case "MASTER":
                    return "MASTER";
                case "JCB":
                    return "JCB";
                case "NCC":
                    return "聯合信用卡";

                default:
                    return "";
            }
        }
    }

    /// <summary>
    /// 修改記錄檔-主要功能
    /// </summary>
    public class MainFunction
    {
        /// <summary>行銷作業-撥打管理</summary>
        public static string DailResult = "行銷作業-撥打管理";
        /// <summary>行銷作業-電話行銷</summary>
        public static string SaleByPhone = "行銷作業-電話行銷";
        /// <summary>行銷作業-新增名單</summary>
        public static string AddRoster = "行銷作業-新增名單";
        /// <summary>成交處理-成交覆核處理</summary>
        public static string Recheck = "成交處理-成交覆核處理";
        /// <summary>成交處理-Reconfirm作業</summary>
        public static string Reconfirm = "成交處理-Reconfirm作業";
        /// <summary>成交處理-成交件修改(RCF)</summary>
        public static string RCF = "成交處理-成交件修改(RCF)";
        /// <summary>成交處理-成交追蹤處理</summary>
        public static string Trace = "成交處理-成交追蹤處理";
        /// <summary>專案活動管理-名單鎖定</summary>
        public static string LockRoster = "專案活動管理-名單鎖定";
        /// <summary>專案活動管理-行銷活動維護</summary>
        public static string Campain = "專案活動管理-行銷活動維護";
        /// <summary>專案活動管理-名單分派回收</summary>
        public static string RosterDispatch = "專案活動管理-名單分派回收";
        /// <summary>人事資料管理-人事資料維護</summary>
        public static string Employee = "人事資料管理-人事資料維護";
        /// <summary>系統管理-名單管理設定</summary>
        public static string NLIP = "系統管理-名單管理設定";
        /// <summary>系統管理-匯出入作業設定</summary>
        public static string Export = "系統管理-匯出入作業設定";
        /// <summary>系統管理-SFTP作業設定</summary>
        public static string FTP = "系統管理-SFTP作業設定";
    }

    /// <summary>
    /// 修改記錄檔-主要作業
    /// </summary>
    public class SecFunction
    {
        /// <summary>CallType異動</summary>
        public static string CallTypeModify = "CallType異動";
        /// <summary>客戶資料異動</summary>
        public static string CustomerModify = "客戶資料異動";
        /// <summary>客戶資料新增</summary>
        public static string CustomerAdd = "客戶資料新增";
        /// <summary>歸屬訪員異動</summary>
        public static string OwnerEMPModify = "歸屬訪員異動";
        /// <summary>要保書資料異動</summary>
        public static string ContentModify = "要保書資料異動";
        /// <summary>名單鎖定</summary>
        public static string LockRoster = "名單鎖定";
        /// <summary>名單解除</summary>
        public static string NotLockRoster = "名單解除";
        /// <summary>專案活動資料異動</summary>
        public static string CampainModify = "專案活動資料異動";
        /// <summary>專案活動管理-名單分派</summary>
        public static string Dispatch = "名單分派";
        /// <summary>專案活動管理-名單回收</summary>
        public static string Recycle = "名單回收";
        /// <summary>人事資料異動</summary>
        public static string EmployeeModify = "人事資料異動";
        /// <summary>獎懲資料異動</summary>
        public static string EmployeeRerard = "獎懲資料異動";
        /// <summary>業績目標異動</summary>
        public static string EmployeeGoal = "業績目標異動";
        /// <summary>訓練資料異動</summary>
        public static string EmployeeTraining = "訓練資料異動";

        /// <summary>名單管理設定異動</summary>
        public static string NLIPSetup = "名單管理設定異動";
        /// <summary>匯出入作業設定異動</summary>
        public static string ExportSetup = "匯出入作業設定異動";
        /// <summary>SFTP作業設定異動</summary>
        public static string FTPSetup = "SFTP作業設定異動";
    }

    /// <summary>
    ///英文月份縮寫
    /// </summary>
    public class ShortMonth
    {
        /// <summary>一月</summary>
        public static string Jan = "Jan.";
        /// <summary>二月</summary>
        public static string Feb = "Feb.";
        /// <summary>三月</summary>
        public static string Mar = "Mar.";
        /// <summary>四月</summary>
        public static string Apr = "Apr.";
        /// <summary>五月</summary>
        public static string May = "May.";
        /// <summary>六月</summary>
        public static string Jun = "Jun.";
        /// <summary>七月</summary>
        public static string Jul = "Jul.";
        /// <summary>八月</summary>
        public static string Aug = "Aug.";
        /// <summary>九月</summary>
        public static string Sep = "Sep.";
        /// <summary>十月</summary>
        public static string Oct = "Oct.";
        /// <summary>十一月</summary>
        public static string Nov = "Nov.";
        /// <summary>十二月</summary>
        public static string Dec = "Dec.";

        public static string getName(string month)
        {
            switch (month)
            {
                case "01":
                    return "Jan.";
                case "02":
                    return "Feb.";
                case "03":
                    return "Mar.";
                case "04":
                    return "Apr.";
                case "05":
                    return "May.";
                case "06":
                    return "Jun.";
                case "07":
                    return "Jul.";
                case "08":
                    return "Aug.";
                case "09":
                    return "Sep.";
                case "10":
                    return "Oct.";
                case "11":
                    return "Nov.";
                case "12":
                    return "Dec.";

                default:
                    return "";
            }
        }
    }
    /// <summary>
    /// 撥打模式
    /// </summary>
    public class DialMode
    {
        /// <summary>Preview</summary>
        public static string Preview = "Preview";
        /// <summary>Predictive</summary>
        public static string Predictive = "Predictive";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// 
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Preview": return "Preview";
                case "Predictive": return "Predictive";
                default: return "";
            }
        }
    }
    /// <summary>
    /// 活動類別
    /// </summary>
    public class CampaignType
    {
        /// <summary>TeleMarketing</summary>
        public static string TM = "TM";
        /// <summary>Customer Service</summary>
        public static string CS = "CS";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// 
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "TM": return "TM";
                case "CS": return "CS";
                default: return "";
            }
        }
    }

    /// <summary> 匯出Excel文件:XML Tag </summary>
    public class ExportXMLExcel
    {
        /// <summary> 使用string.Format,帶入日期/時間值 </summary>
        public static string HeaderStartTag = @"<?xml version='1.0'?>
<?mso-application progid='Excel.Sheet'?>i
<Workbook xmlns='urn:schemas-microsoft-com:office:spreadsheet'
 xmlns:o='urn:schemas-microsoft-com:office:office'
 xmlns:x='urn:schemas-microsoft-com:office:excel'
 xmlns:ss='urn:schemas-microsoft-com:office:spreadsheet'
 xmlns:html='http://www.w3.org/TR/REC-html40'>
 <DocumentProperties xmlns='urn:schemas-microsoft-com:office:office'>
  <Description>Query Range: {0}</Description>
  <LastAuthor>Jeter</LastAuthor>
  <Created>{0}</Created>
  <Version>1.00</Version>
 </DocumentProperties>
 <ExcelWorkbook xmlns='urn:schemas-microsoft-com:office:excel'>
  <WindowHeight>10005</WindowHeight>
  <WindowWidth>10005</WindowWidth>
  <WindowTopX>120</WindowTopX>
  <WindowTopY>135</WindowTopY>
  <ProtectStructure>False</ProtectStructure>
  <ProtectWindows>False</ProtectWindows>
 </ExcelWorkbook>
 <Styles>
    <Style ss:ID='Default' ss:Name='Normal'><Alignment ss:Vertical='Center'/><Borders/>
        <Font ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8' ss:Color='#000000'/><Interior/>
        <NumberFormat ss:Format='#,##0_ '/>
        <Protection/></Style>
    <Style ss:ID='colcenter'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='bcolcenter'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' ss:FontName='Arial' ss:Size='9'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='title'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Font ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='14' ss:Color='#000000'/>
    </Style>
    <Style ss:ID='ssCenter'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='ssRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='ssbRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' ss:FontName='Arial' ss:Size='9'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='ssLeft'>
        <Alignment ss:Horizontal='Left' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='bCenter'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='bRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='bLeft'>
        <Alignment ss:Horizontal='Left' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>	
    <Style ss:ID='nbCenter'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center'/>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='nbRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='nbLeft'>
        <Alignment ss:Horizontal='Left' ss:Vertical='Center' ss:WrapText='1'/>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>		
    <Style ss:ID='nbLeft12'>
        <Alignment ss:Horizontal='Left' ss:Vertical='Center' ss:WrapText='1'/>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='12'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='nbblLeft12'>
        <Alignment ss:Horizontal='Left' ss:Vertical='Center' ss:WrapText='1'/>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='12'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='sbCenter'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8'/>
        <Interior ss:Color='#CCFFCC' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='sbRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8'/>
        <Interior ss:Color='#CCFFCC' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='sbLeft'>
        <Alignment ss:Horizontal='Left' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8'/>
        <Interior ss:Color='#CCFFCC' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='gbCenter'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8'/>
        <Interior ss:Color='#CCCCFF' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='gbRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8'/>
        <Interior ss:Color='#CCCCFF' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='gbLeft'>
        <Alignment ss:Horizontal='Left' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1'/>
        <Interior ss:Color='#CCCCFF' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='noCenter'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='noRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='noRight12'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Font ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='12'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='noLeft'>
        <Alignment ss:Horizontal='Left' ss:Vertical='Center' ss:WrapText='1'/>		
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='noLeft12'>
        <Alignment ss:Horizontal='Left' ss:Vertical='Center' ss:WrapText='1'/>
        <Font ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='12'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='bnoLeft'>
        <Alignment ss:Horizontal='Left' ss:Vertical='Center' ss:WrapText='1'/>		
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='0'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='0'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='0'/>
        </Borders>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='bnoLeft12'>
        <Alignment ss:Horizontal='Left' ss:Vertical='Center' ss:WrapText='1'/>
        <Font ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='12'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
    <Style ss:ID='Float2'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <NumberFormat ss:Format='#,##0.00_ '/>
    </Style>	
    <Style ss:ID='nFloat2'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <NumberFormat ss:Format='#,##0.00_ '/>
    </Style>
    <Style ss:ID='nFloat'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <NumberFormat ss:Format='#,##0.0_ '/>
    </Style>
    <Style ss:ID='nbFloat2'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' ss:FontName='Arial' ss:Size='9'/>
        <NumberFormat ss:Format='#,##0.00_ '/>
    </Style>
    <Style ss:ID='nPercent'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <NumberFormat ss:Format='Percent'/>
    </Style>
    <Style ss:ID='nbPercent'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' ss:FontName='Arial' ss:Size='9'/>
        <NumberFormat ss:Format='Percent'/>
    </Style>
    <Style ss:ID='nPercent2'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <NumberFormat ss:Format='Percent'/>
    </Style>
    <Style ss:ID='s71'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders/>		
    </Style>		
    <Style ss:ID='s73'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>		
    </Style>
    <Style ss:ID='HeadOrange'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        
        <Interior ss:Color='#FFCC99' ss:Pattern='Solid'/>
     </Style>
    <Style ss:ID='BHeadOrange'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' />
        <Interior ss:Color='#FFCC99' ss:Pattern='Solid'/>
     </Style>
    <Style ss:ID='BHeadOrangeRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' />
        <Interior ss:Color='#FFCC99' ss:Pattern='Solid'/>
     </Style>
    <Style ss:ID='nBFloatHeadOrangeRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' />
        <Interior ss:Color='#FFCC99' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.00_ '/>
     </Style>
     <Style ss:ID='HeadYallow'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        
        <Interior ss:Color='#FFFF99' ss:Pattern='Solid'/>
     </Style>
     <Style ss:ID='BHeadYallow'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' />
        <Interior ss:Color='#FFFF99' ss:Pattern='Solid'/>
     </Style>
     <Style ss:ID='BHeadYallowRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' />
        <Interior ss:Color='#FFFF99' ss:Pattern='Solid'/>
     </Style>
    <Style ss:ID='nBFloatHeadYallowRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' />
        <Interior ss:Color='#FFFF99' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.00_ '/>
    </Style>
    <Style ss:ID='HeadGreen'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
    
        <Interior ss:Color='#99FF99' ss:Pattern='Solid'/>
     </Style>
     <Style ss:ID='HeadBlue'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
    
        <Interior ss:Color='#9999cc' ss:Pattern='Solid'/>
     </Style>
     <Style ss:ID='HeadBlueR'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8' ss:Color='#ff0000'/>
    
        <Interior ss:Color='#9999cc' ss:Pattern='Solid'/>
     </Style>
     <Style ss:ID='nrBlue'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Interior ss:Color='#9999cc' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0 '/>
    </Style>
     <Style ss:ID='nrFloatBlue'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Interior ss:Color='#9999cc' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.00_ '/>
    </Style>
     <Style ss:ID='nrFloatBlue%'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Interior ss:Color='#9999cc' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='0.00%'/>
    </Style>
     <Style ss:ID='nFloatBlue'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Interior ss:Color='#9999cc' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.0_ '/>
    </Style>
     <Style ss:ID='nFloatBlue%'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Interior ss:Color='#9999cc' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='0.0%'/>
    </Style>
     <Style ss:ID='nFloatGreen'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Interior ss:Color='#99FF99' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.0_ '/>
    </Style>
     <Style ss:ID='nFloatGreen%'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Interior ss:Color='#99FF99' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='0.0%'/>
    </Style>
     <Style ss:ID='nFloatOrange'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        
        <Interior ss:Color='#FFCC99' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.0_ '/>
    </Style>
     <Style ss:ID='nFloatOrange%'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        
        <Interior ss:Color='#FFCC99' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='0.0%'/>
    </Style>
    <Style ss:ID='nBFloatOrangeRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' />
        <Interior ss:Color='#FFCC99' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.00_ '/>
    </Style>
    <Style ss:ID='nBFloatOrangeRight%'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' />
        <Interior ss:Color='#FFCC99' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='0.00%'/>
    </Style>
     <Style ss:ID='nFloatYallow'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Interior ss:Color='#FFFF99' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.0_ '/>
    </Style>
    <Style ss:ID='nFloatYallow%'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Interior ss:Color='#FFFF99' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='0.0%'/>
    </Style>
     <Style ss:ID='nBFloatYallowRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' />
        <Interior ss:Color='#FFFF99' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.00 '/>
    </Style>
    <Style ss:ID='nBFloatYallowRight%'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' />
        <Interior ss:Color='#FFFF99' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='0.00%'/>
    </Style>
   <Style ss:ID='ncFloat'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <NumberFormat ss:Format='#,##0.0_ '/>
    </Style>
    <Style ss:ID='ncFloat%'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <NumberFormat ss:Format='0.0%'/>
    </Style>
<Style ss:ID='ncFloat2'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <NumberFormat ss:Format='#,##0.00_ '/>
    </Style>
<Style ss:ID='bCBule'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
            <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
            <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:Bold='1' ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8' ss:Color='#000080'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
 <Style ss:ID='nFloatLightGray'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Interior ss:Color='#C0C0C0' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.0_ '/>
    </Style>
<Style ss:ID='nFloatLightGrayRight'>
        <Alignment ss:Horizontal='Right' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Interior ss:Color='#C0C0C0' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.0_ '/>
    </Style>
<Style ss:ID='nFloatGray'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Interior ss:Color='#969696' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.0_ '/>
    </Style>
<Style ss:ID='BluenFloatLightGray'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
<Font ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8' ss:Color='#3366FF'/>
        <Interior ss:Color='#C0C0C0' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.0_ '/>
    </Style>
<Style ss:ID='BluenC'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8' ss:Color='#3366FF'/>
        <Interior ss:Color='#C0C0C0' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
<Style ss:ID='RednC'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <Font ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8' ss:Color='#FF6600'/>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>
<Style ss:ID='BluenFloat'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
<Font ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8' ss:Color='#3366FF'/>
        <Interior ss:Color='#C0C0C0' ss:Pattern='Solid'/>
        <NumberFormat ss:Format='#,##0.00_ '/>
    </Style>
<Style ss:ID='RednFloat'>
        <Alignment ss:Horizontal='Center' ss:Vertical='Center' ss:WrapText='1'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
<Font ss:FontName='Arial' x:CharSet='136' x:Family='Roman' ss:Size='8' ss:Color='#FF6600'/>
        <NumberFormat ss:Format='#,##0.00_ '/>
    </Style>
  <Style ss:ID='NoWrapTextL'>
        <Alignment ss:Vertical='Center'/>
        <Borders>
        <Border ss:Position='Bottom' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Left' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Right' ss:LineStyle='Continuous' ss:Weight='1'/>
        <Border ss:Position='Top' ss:LineStyle='Continuous' ss:Weight='1'/>
        </Borders>
        <NumberFormat ss:Format='#,##0_ '/>
    </Style>

 </Styles>";

        //
        //<Interior ss:Color="#CCFFCC" ss:Pattern="Solid"/>
        /// <summary> 使用string.Format,帶入Worksheet名稱 </summary>
        public static string WorkSheetStartTag = @"<Worksheet ss:Name='{0}'><Table ss:DefaultColumnWidth='60' ss:DefaultRowHeight='16.5'>";
        /// <summary> 使用string.Format,帶入欄位文字 </summary>
        public static string StringTitleTag = @"<Cell ss:MergeAcross='{0}' ss:StyleID='title'><Data ss:Type='String'>{1}</Data></Cell>";
        /// <summary> 使用string.Format,帶入欄位文字 </summary>
        public static string StringTitleTag12 = @"<Cell ss:MergeAcross='11' ss:StyleID='title'><Data ss:Type='String'>{0}</Data></Cell>";
        /// <summary> 使用string.Format,帶入欄位文字 </summary>
        public static string StringLeftTag = @" <Cell ss:StyleID='ssLeft' ss:MergeAcross='8'><Data ss:Type='String'>{0}</Data></Cell>";
        /// <summary> 使用string.Format,帶入欄位文字 </summary>
        public static string StringRightTag = @" <Cell ss:StyleID='ssRight' ss:MergeAcross='{0}'><Data ss:Type='String'>{1}</Data></Cell>";
        /// <summary> 直接使用 </summary>
        public static string HeaderEndTag = @"<Selected/><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios></WorksheetOptions></Worksheet></Workbook>";
        /// <summary> 直接使用 ( 橫式,一頁長一頁寬 )</summary>
        public static string HeaderEndLandscapeTag = @"<Selected/><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios><PageSetup><Layout x:Orientation='Landscape'/></PageSetup><Unsynced/><FitToPage/></WorksheetOptions></Worksheet></Workbook>";
        /// <summary> 直接使用 </summary>
        public static string WorkbookEndTag = @"</Workbook>";
        /// <summary> 直接使用 </summary>
        public static string WorkSheetEndTag2 = @"</Table><WorksheetOptions xmlns='urn:schemas-microsoft-com:office:excel'><Selected/><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios><PageSetup><Header x:Data='&amp;L&amp;A'/><Layout x:Orientation='Landscape'/></PageSetup><Unsynced/><FitToPage/></WorksheetOptions></Worksheet>";
        /// <summary> 直接使用 </summary>
        public static string WorkSheetEndTag = @"</Table><WorksheetOptions xmlns='urn:schemas-microsoft-com:office:excel'>";
        /// <summary> 直接使用 </summary>
        public static string WorkSheetEndTag3 = @"</Table><WorksheetOptions xmlns='urn:schemas-microsoft-com:office:excel'><Selected/><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios></WorksheetOptions></Worksheet>";
        /// <summary> 使用string.Format,帶入欄位文字 </summary>
        public static string StringTag = @"<Cell ss:StyleID='ssLeft'><Data ss:Type='String'>{0}</Data></Cell>";
        /// <summary> 使用string.Format,帶入欄位文字 </summary>
        public static string StringCenterTag = @"<Cell ss:StyleID='colcenter'><Data ss:Type='String'>{0}</Data></Cell>";
        public static string BStringCenterTag = @"<Cell ss:StyleID='bcolcenter'><Data ss:Type='String'>{0}</Data></Cell>";
        /// <summary> 使用string.Format,帶入欄位文字 </summary>
        public static string StringRTag = @"<Cell ss:StyleID='ssRight'><Data ss:Type='String'>{0}</Data></Cell>";
        /// <summary> 使用string.Format,帶入欄位數值 </summary>
        public static string NumberTag = @"<Cell ss:StyleID='ssRight'><Data ss:Type='Number'>{0}</Data></Cell>";
        public static string BNumberTag = @"<Cell ss:StyleID='ssbRight'><Data ss:Type='Number'>{0}</Data></Cell>";
        /// <summary> 直接使用 </summary>
        public static string RowStartTag = @"<Row ss:AutoFitHeight='0'>";
        /// <summary> 直接使用 </summary>
        public static string RowStartHeightTag = @"<Row ss:Height='{0}'>";
        /// <summary> 直接使用 </summary>
        public static string RowEndTag = @"</Row>";
        /// <summary> 使用string.Format,帶入欄位寬度 </summary>
        public static string ColumnSetWidth = @"<Column ss:AutoFitWidth='0' ss:Width='{0}'/>";

        /// <summary> 定義cell欄位屬性</summary>
        /// <param name="mergeacross">橫向向右合拼欄位(0為不合拼，1為合拼1欄)</param>
        /// <param name="mergedown">垂直向下合拼欄位(0為不合拼，1為合拼1欄)</param>
        /// <param name="cellnum">欄位編號,每一行由左往右計算，由第一欄起始點為1，以此類推，設0表不設定編號</param>
        /// <param name="stytle">對齊方向("l":置左,"r":置右,"c":中央)</param>
        /// <param name="sstype">儲值型態,("s"字串,"n"數值)</param>
        /// <param name="val">值</param>
        /// <returns>回傳Cell格式字串</returns>
        private static string CellTag(int mergeacross, int mergedown, int cellnum, string stytle, string sstype, string val)
        {
            string s_ren = "";

            if (mergeacross < 0) mergeacross = 0;
            if (mergedown < 0) mergedown = 0;

            switch (stytle)
            {
                case "nc":
                    stytle = "noCenter";
                    break;
                case "nr":
                    stytle = "noRight";
                    break;
                case "nr12":
                    stytle = "noRight12";
                    break;
                case "nl":
                    stytle = "noLeft";
                    break;
                case "nl12":
                    stytle = "noLeft12";
                    break;
                case "bnl":
                    stytle = "bnoLeft";
                    break;
                case "bnl12":
                    stytle = "bnoLeft12";
                    break;
                case "l":
                    stytle = "ssLeft";
                    break;
                case "c":
                    stytle = "ssCenter";
                    break;
                case "r":
                    stytle = "ssRight";
                    break;
                case "bc":
                    stytle = "bCenter";
                    break;
                case "br":
                    stytle = "bRight";
                    break;
                case "bl":
                    stytle = "bLeft";
                    break;
                case "nbc":
                    stytle = "nbCenter";
                    break;
                case "nbr":
                    stytle = "nbRight";
                    break;
                case "nbl":
                    stytle = "nbLeft";
                    break;
                case "gbc":
                    stytle = "gbCenter";
                    break;
                case "gbr":
                    stytle = "gbRight";
                    break;
                case "gbl":
                    stytle = "gbLeft";
                    break;
                case "sbc":
                    stytle = "sbCenter";
                    break;
                case "sbr":
                    stytle = "sbRight";
                    break;
                case "sbl":
                    stytle = "sbLeft";
                    break;
                case "ct":
                    stytle = "s73";
                    break;
                case "cnone":
                    stytle = "s71";
                    break;
                case "":
                    stytle = "ssLeft";
                    break;
                default:
                    break;
            }

            s_ren = "<Cell";

            if (mergeacross > 0)
                s_ren += " ss:MergeAcross='" + Convert.ToString(mergeacross) + "'";
            if (mergedown > 0)
                s_ren += " ss:MergeDown='" + Convert.ToString(mergedown) + "'";
            if (cellnum > 0)
                s_ren += " ss:Index='" + Convert.ToString(cellnum) + "'";

            s_ren += " ss:StyleID='" + stytle + "'";

            s_ren += ">";

            s_ren += "<Data ss:Type='" + sstype + "'>" + val + "</Data></Cell>";

            return s_ren;
        }

        /// <summary> 定義cell欄位屬性</summary>
        /// <param name="mergeacross">橫向向右合拼欄位(0為不合拼，1為合拼1欄)</param>
        /// <param name="mergedown">垂直向下合拼欄位(0為不合拼，1為合拼1欄)</param>
        /// <param name="cellnum">欄位編號,每一行由左往右計算，由第一欄起始點為1，以此類推，設0表不設定編號</param>
        /// <param name="stytle">對齊方向("l":置左,"r":置右,"c":中央)</param>
        /// <param name="val">值</param>
        /// <returns>回傳Cell格式字串</returns>
        public static string CellTag(int mergeacross, int mergedown, int cellnum, string stytle, string val)
        {
            return CellTag(mergeacross, mergedown, cellnum, stytle, "String", val);
        }
        /// <summary> 定義cell欄位屬性</summary>
        /// <param name="mergeacross">橫向向右合拼欄位(0為不合拼，1為合拼1欄)</param>
        /// <param name="mergedown">垂直向下合拼欄位(0為不合拼，1為合拼1欄)</param>
        /// <param name="cellnum">欄位編號,每一行由左往右計算，由第一欄起始點為1，以此類推，設0表不設定編號</param>
        /// <param name="stytle">對齊方向("l":置左,"r":置右,"c":中央)</param>
        /// <param name="val">值</param>
        /// <returns>回傳Cell格式字串</returns>
        public static string CellTag(int mergeacross, int mergedown, int cellnum, string stytle, int val)
        {
            return CellTag(mergeacross, mergedown, cellnum, stytle, "Number", Convert.ToString(val));
        }
        public static string CellTag(int mergeacross, int mergedown, int cellnum, string stytle, double val)
        {
            return CellTag(mergeacross, mergedown, cellnum, stytle, "Number", Convert.ToString(val));
        }
        /// <summary> 定義cell欄位屬性</summary>
        /// <param name="stytle">對齊方向("l":置左,"r":置右,"c":中央)</param>
        /// <param name="sstype">儲值型態,("s"字串,"n"數值)</param>
        /// <param name="val">值</param>
        /// <returns>回傳Cell格式字串</returns>
        public static string CellTag(string stytle, string val)
        {
            return CellTag(0, 0, 0, stytle, "String", val);
        }
        /// <summary> 定義cell欄位屬性</summary>
        /// <param name="stytle">對齊方向("l":置左,"r":置右,"c":中央)</param>
        /// <param name="sstype">儲值型態,("s"字串,"n"數值)</param>
        /// <param name="val">值</param>
        /// <returns>回傳Cell格式字串</returns>
        public static string CellTag(string stytle, int val)
        {
            return CellTag(0, 0, 0, stytle, "Number", Convert.ToString(val));
        }
        /// <summary> 定義cell欄位屬性</summary>
        /// <param name="stytle">StyleID</param>
        /// <param name="val">值</param>
        /// <returns>回傳Cell格式字串</returns>
        public static string CellTag(string stytle, double val)
        {
            return CellTag(0, 0, 0, stytle, "Number", Convert.ToString(val));
        }
    }

    /// <summary>
    /// 健告審核分類
    /// </summary>
    public class IllnessType
    {
        /// <summary>可線上受理疾病</summary>
        public static string Minor = "M";
        /// <summary>拒保疾病</summary>
        public static string Reject = "R";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "M": return "可線上受理疾病";
                case "R": return "拒保疾病";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 獎懲類別
    /// </summary>
    public class RewardType
    {
        /// <summary>獎勵</summary>
        public static string Reward = "Reward";
        /// <summary>懲處</summary>
        public static string Punish = "Punish";
        /// <summary>品質輔導下線</summary>
        public static string Tutor = "Tutor";
        /// <summary>PTQC榮譽會員</summary>
        public static string PTQC = "PTQC";
        /// <summary>不可進行線上成交</summary>
        public static string NoOnlineDeal = "NoOnlineDeal";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Reward": return "獎勵";
                case "Punish": return "懲處";
                case "Tutor": return "品質輔導下線";
                case "PTQC": return "PTQC榮譽會員";
                case "NoOnlineDeal": return "不可進行線上成交";
                default: return "";
            }
        }
    }

    public class SMSStatus
    {
        /// <summary>等待寄送</summary>
        public static string Waitting = "Waitting";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Waitting": return "等待寄送";
                default: return "";
            }
        }
    }

    public class DeleteDBType
    {
        /// <summary>便條紙</summary>
        public static string MEMO = "MEMO";
        /// <summary>公告</summary>
        public static string MARQUEE = "MARQUEE";
        /// <summary>待辦事項</summary>
        public static string JOB = "JOB";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "MEMO": return "便條紙";
                case "MARQUEE": return "公告";
                case "JOB": return "待辦事項";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 罐頭簡訊發送頻率
    /// </summary>
    public class SMCSENDTYPE
    {
        /// <summary>即時發送</summary>
        public static string TIMELY = "1";
        /// <summary>批次發送</summary>
        public static string BATCH = "2";
        /// <summary>即時發送+批次發送</summary>
        public static string Both = "12";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "1": return "即時發送";
                case "2": return "批次發送";
                case "12": return "即時發送+批次發送";
                default: return "";
            }
        }
        public static string getFieldShortComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "1": return "即時";
                case "2": return "批次";
                case "12": return "即時+批次";
                default: return "";
            }
        }
    }

    /// <summary>
    /// 批次發送執行時間
    /// </summary>
    public class SMCBATCHTYPE
    {
        /// <summary>分</summary>
        public static string DayMinute = "Minute";
        /// <summary>每日</summary>
        public static string Day = "Day";
        /// <summary>每月</summary>
        public static string Month = "Month";
        /// <summary>時間</summary>
        public static string Time = "Time";
    }

    /// <summary>
    /// 成交內容 VPOS 狀態
    /// </summary>
    public class DBGContentVPOSStatus
    {
        /// <summary>尚未執行VPOS</summary>
        public static string NotYet = "";
        /// <summary>失敗</summary>
        public static string Failed = "0";
        /// <summary>成功</summary>
        public static string Success = "1";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "": return "尚未執行VPOS";
                case "0": return "失敗";
                case "1": return "成功";
                default: return "";
            }
        }
    }

    //SR-32880 保單遞送方式
    public class PolicyType
    {
        /// <summary>紙本保單</summary>
        public static string Paper = "P";
        /// <summary>電子保單</summary>
        public static string Electronic = "E";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "P": return "紙本保單";
                case "E": return "電子保單";
                default: return "";
            }
        }
    }

    //SR-32894_毅聲-登錄證字號採IVR撥放
    public class IVRType
    {
        /// <summary>成交宣告</summary>
        public static string DealDeclare = "1";
        /// <summary>登錄證字號</summary>
        public static string LicenseNo = "2";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "1": return "成交宣告";
                case "2": return "登錄證字號";
                default: return "";
            }
        }
    }

    //SR-33488 勿擾備註
    public class RosterDontBother
    {
        /// <summary>保誠+銀行勿擾</summary>
        public static string Both = "Both";
        /// <summary>保誠勿擾</summary>
        public static string PCALife = "PCALife";
        /// <summary>銀行勿擾</summary>
        public static string Bank = "Bank";

        /// <summary>
        /// 依欄位值取得欄位說明
        /// </summary>
        /// <param name="AFieldValue">欄位值</param>
        /// <returns>欄位說明</returns>
        public static string getFieldComment(string AFieldValue)
        {
            switch (AFieldValue)
            {
                case "Both": return "保誠+銀行勿擾";
                case "PCALife": return "保誠勿擾";
                case "Bank": return "銀行勿擾";
                default: return "";
            }
        }
    }
}

