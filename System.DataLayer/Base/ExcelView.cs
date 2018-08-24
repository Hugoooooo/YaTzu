using System;
using System.Framework.DataLayer;
using System.Collections.Generic;
using System.Data;

namespace System.DataLayer.Base
{
    /// <summary>
    /// ExcelView 的摘要描述。
    /// </summary>
    public class ExcelView : BaseView
    {
        public class TermCodeItem
        {
            public enum ncCalType { Count, Sum, LCallType }

            /// <summary>欄位名稱</summary>
            public string Name { get; private set; }

            /// <summary>sql alias name</summary>
            public string Key { get; private set; }

            /// <summary>群組欄位名稱</summary>
            public string Group { get; private set; }

            /// <summary>
            /// CalType:LCallType, 由分號分隔對應RST_LCALLTYPE五個欄位文字
            /// 其他:放在CASE WHEN之後的條件
            /// </summary>
            public string Condition { get; private set; }

            /// <summary>
            /// 統計欄位(CASE WHEN XXX THEN之後)
            /// 若Group == Value，則為小記欄位
            /// </summary>
            public string Value { get; private set; }
            public ncCalType CalType { get; private set; }

            //
            public bool IsSubTotal { get { return (this.Group == this.Value); } }

            public string GetSQLField()
            {
                if (CalType == ncCalType.LCallType)
                {
                    string[] ct = Condition.Split(';');
                    string cond = "";
                    for (int i = 0; i < ct.Length && i < 5; i++)
                        if (ct[i] != "")
                            cond += string.Format("{0}R.RST_LCALLTYPE{1}=N'{2}'", (cond == "" ? "" : " AND "), (i + 1).ToString(), ct[i]);
                    return string.Format("{0}=COUNT(DISTINCT CASE WHEN {1} AND R.RST_LDIALDTTM BETWEEN '{{0}} 00:00:00' AND '{{1}} 23:59:59' THEN {2} ELSE NULL END)", this.Key, cond, this.Value);
                }
                else if (CalType == ncCalType.Count)
                    return string.Format("{0}=COUNT(DISTINCT CASE WHEN {1} THEN {2} ELSE NULL END)", this.Key, this.Condition, this.Value);
                else if (CalType == ncCalType.Sum)
                    return string.Format("{0}=SUM(CASE WHEN {1} THEN {2} ELSE 0 END)", this.Key, this.Condition, this.Value);
                else return this.Key + "=-1";
            }
            public TermCodeItem(string Name, string Key, string Group, string Condition, string Value, ncCalType CalType)
            {
                this.Name = Name;
                this.Key = Key;
                this.Group = Group;
                this.Condition = Condition;
                this.Value = Value;
                this.CalType = CalType;
            }
        }

        // TermCode
        public List<TermCodeItem> TermCodeItems;
        public List<TermCodeItem> AppointmentItmes;
        public List<TermCodeItem> RejectItems;
        public List<TermCodeItem> Useless;

        #region old
        //Term_Code_A1=RST_LCALLTYPE1
        public string Term_Code1_A = RosterStatusType.getFieldComment(RosterStatusType.Useless);//"無效名單";
        public string Term_Code1_A2 = RosterStatusType.getFieldComment(RosterStatusType.Useless2);//"名單問題";
        public string Term_Code1_B = RosterStatusType.getFieldComment(RosterStatusType.Fail);//"行銷失敗";
        public string Term_Code1_B2 = RosterStatusType.getFieldComment(RosterStatusType.Fail2);//"客戶拒絕";
        public string Term_Code1_C = RosterStatusType.getFieldComment(RosterStatusType.ThinkAbout);//"考慮中";
        public string Term_Code1_D = RosterStatusType.getFieldComment(RosterStatusType.ContactAgain);//"再聯絡";
        public string Term_Code1_E = RosterStatusType.getFieldComment(RosterStatusType.Success);//"成功";
        public string Term_Code1_F = "未能接通";
        public string Term_Code1_G = "不願電銷";
        ////Term_Code_A5=RST_LCALLTYPE5
        public string Term_Code5_A_1 = "名單重覆";
        public string Term_Code5_A_2 = "年齡不合投保資格";
        public string Term_Code5_A_3 = "健康不合投保資格";
        public string Term_Code5_A_4 = "職業不合投保資料";
        public string Term_Code5_A_5 = "沒辦過信用卡";
        public string Term_Code5_A_6 = "未開卡";
        public string Term_Code5_A_7 = "已剪卡";
        public string Term_Code5_A_8 = "無此人";
        public string Term_Code5_A_9 = "離職、搬家、移民、出國";
        public string Term_Code5_A_10 = "期間內無法聯絡";
        public string Term_Code5_A_11 = "身故";
        public string Term_Code5_B_1 = "銷售過於頻繁";
        public string Term_Code5_B_2 = "銀行行員/保險業務員";
        public string Term_Code5_B_3 = "對銀行不滿意";
        public string Term_Code5_B_4 = "對產品不滿意";
        public string Term_Code5_B_5 = "強烈拒絕/不願電銷";
        public string Term_Code5_B_6 = "快速拒絕";
        public string Term_Code5_B_7 = "對保險公司不滿意";
        public string Term_Code5_B_8 = "已有專人服務/家人為同業";
        public string Term_Code5_B_9 = "家人親友反對";
        public string Term_Code5_B_10 = "需要其他產品";
        public string Term_Code5_B_11 = "沒需要沒預算/保險很多/其他";
        public string Term_Code5_B_12 = "不願電銷";
        public string Term_Code5_C_1 = "機會保單";
        public string Term_Code5_C_2 = "傳真/郵寄";
        public string Term_Code5_C_3 = "本人在忙";
        public string Term_Code5_C_4 = "考慮中";		
        public string Term_Code5_C_5 = "考慮中-A";
        public string Term_Code5_C_6 = "考慮中-B";
        public string Term_Code5_C_7 = "考慮中-C";		
        public string Term_Code5_C_8 = "A級客戶-傳真";
        public string Term_Code5_C_9 = "A級客戶-郵寄";
        public string Term_Code5_C_10 = "B級客戶-傳真";
        public string Term_Code5_C_11 = "B級客戶-郵寄";
        public string Term_Code5_C_12 = "C級客戶-傳真";
        public string Term_Code5_C_13 = "C級客戶-郵寄";
        public string Term_Code5_C_14 = "D級客戶-未說明保單內容";
        public string Term_Code5_D_1 = "客戶在忙";
        public string Term_Code5_D_2 = "非本人接聽";
        //public string Term_Code5_E_1 = "TMR-未核保";
        public string Term_Code5_F_1 = "忙線中";
        public string Term_Code5_F_2 = "無人接聽";
        public string Term_Code5_F_3 = "電話有誤";
        #endregion

        protected string getSQLFields(List<TermCodeItem> list)
        {
            string ret = "";
            for (int i = 0; i < list.Count; i++)
                if (list[i].Group != list[i].Value)
                    ret += ", " + list[i].GetSQLField();
            return ret;
        }

        #region Excel

        public string xlsColumnsWidth(List<TermCodeItem> list)
        {
            string ret = "";
            for (int i = 0; i < list.Count; i++)
            {
                int len = 60;
                if (list[i].Name.Length > 4)
                    len += (list[i].Name.Length - 4) * 6;
                ret += (string.Format(ExportXMLExcel.ColumnSetWidth, len.ToString()));
            }
            return ret;
        }

        public string xlsColumnsName(List<TermCodeItem> list, string format)
        {
            string ret = "";
            for (int i = 0; i < list.Count; i++)
                ret += string.Format(format, list[i].Name);
            return ret;
        }

        public string xlsColumnGroupsName(List<TermCodeItem> list, int startInd, string style)
        {
            string ret = "", group = "";
            int i = 0, merge = 0;
            while (i<list.Count)
            {
                if (group != list[i].Group)
                {
                    merge = 0;
                    group = list[i].Group;
                }
                else merge++;
                i++;
                if (i < list.Count ? list[i].Group != group : true)
                    ret += ExportXMLExcel.CellTag(merge, 0, startInd + i - 1 - merge, style, list[i - 1].Group);
            }
            return ret;
        }

        public int GetIndexByKey(List<TermCodeItem> list, string key)
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i].Key == key)
                    return i;
            return -1;
        }

        public int GetGroupIndex(List<TermCodeItem> list, string group)
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i].Group == list[i].Value && list[i].Group == group)
                    return i;
            return -1;
        }

        /// <summary>
        /// 不知道為甚麼在這邊不能用DataRow.Field<T>()
        /// </summary>
        /// <param name="list"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public int GetValue(List<TermCodeItem> list, int i)
        {
            if (list[i].Group == list[i].Value)
                return GetGroupValue(list, list[i].Group);
            string key = list[i].Key;
            foreach (DataColumn dc in DataObject.Tables[0].Columns)
            {
                if (dc.ColumnName == key)
                    return (int)CurrentDataRow[dc];
            }
            throw new Exception(string.Format("ExcelView.GetValue:column [{0}] not found.", key));
        }

        public int GetGroupValue(List<TermCodeItem> list, string group)
        {
            int ret = 0;
            for (int i = 0; i < list.Count;i++ )
            {
                if (list[i].Group == list[i].Value || list[i].Group != group) continue;

                foreach (DataColumn dc in DataObject.Tables[0].Columns)
                {
                    if (dc.ColumnName == list[i].Key)
                        ret += (int)CurrentDataRow[dc];
                }
            }
            return ret;
        }
        #endregion

        public ExcelView(IConnection AConn) : base(AConn) 
        {
            TermCodeItems = new List<TermCodeItem>();
            TermCodeItems.Add(new TermCodeItem("再聯絡", "Code1", "", "有此人;再聯絡", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            TermCodeItems.Add(new TermCodeItem("考慮中", "Code2", "", "有此人;考慮中", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            TermCodeItems.Add(new TermCodeItem("拒購", "Code3", "", "有此人;拒購", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            TermCodeItems.Add(new TermCodeItem("不適合銷售用", "Code4", "", "有此人;不適合銷售用", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            TermCodeItems.Add(new TermCodeItem("無此人", "Code5", "", "無此人", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            TermCodeItems.Add(new TermCodeItem("無人接聽", "Code6", "", "無人接聽", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            TermCodeItems.Add(new TermCodeItem("不願電銷", "Code7", "", "不願電銷", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            //TermCodeItems.Add(new TermCodeItem("同意投保", "TMR_NEW", "",
            //    "R.RST_STATUS = '" + RosterStatusType.Success + "' AND DB.DBG_ISDIALDEAL = '1' AND  DB.DBG_EFFDATE BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'",
            //    "DB.DBG_SERNO", TermCodeItem.ncCalType.Count));
            TermCodeItems.Add(new TermCodeItem("同意投保", "TMR_NEW", "",
                "R.RST_STATUS = '" + RosterStatusType.Success + "' AND R.RST_LDIALDTTM BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'",
                "R.RST_SERNO", TermCodeItem.ncCalType.Count));


            AppointmentItmes = new List<TermCodeItem>();
            AppointmentItmes.Add(new TermCodeItem("考慮中A(有望客戶)", "Code1_1", "考慮中", ";;;;考慮中A(有望客戶)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("考慮中B(有機客戶)", "Code1_2", "考慮中", ";;;;考慮中B(有機客戶)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("考慮中C(無望客戶,但尚未拒絕)", "Code1_3", "考慮中", ";;;;考慮中C(無望客戶,但尚未拒絕)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("TTL", "Code1", "考慮中", ";考慮中", "考慮中", TermCodeItem.ncCalType.LCallType));

            AppointmentItmes.Add(new TermCodeItem("忙碌(下一筆名單)", "Code2_1", "再聯絡", ";;;;忙碌(下一筆名單)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("忙碌(下一通電話)", "Code2_2", "再聯絡", ";;;;忙碌(下一通電話)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("忙線、不在、出國(下一筆名單)", "Code2_3", "再聯絡", ";;;;忙線、不在、出國(下一筆名單)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("忙線、不在、出國(下一通電話)", "Code2_4", "再聯絡", ";;;;忙線、不在、出國(下一通電話)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("TTL", "Code2", "再聯絡", ";再聯絡", "再聯絡", TermCodeItem.ncCalType.LCallType));

            RejectItems = new List<TermCodeItem>();
            RejectItems.Add(new TermCodeItem("保險太多", "Code1_1", "拒購", ";;;;保險太多", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("保險不需要", "Code1_2", "拒購", ";;;;保險不需要", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("經濟因素", "Code1_3", "拒購", ";;;;經濟因素", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("親友反對", "Code1_4", "拒購", ";;;;親友反對", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("不接受電銷", "Code1_5", "拒購", ";;;;不接受電銷", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("銷售過於頻繁", "Code1_6", "拒購", ";;;;銷售過於頻繁", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("其他", "Code1_7", "拒購", ";;;;其他", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("TTL", "Code1", "拒購", ";拒購", "拒購", TermCodeItem.ncCalType.LCallType));

            Useless = new List<TermCodeItem>();
            Useless.Add(new TermCodeItem("勿擾", "Code1_1", "不適合銷售用", ";;;;勿擾", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("核保問題件", "Code1_2", "不適合銷售用", ";;;;核保問題件-體況、財務、職業", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("同業", "Code1_3", "不適合銷售用", ";;;;同業", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("TTL", "Code1", "不適合銷售用", "", "不適合銷售用", TermCodeItem.ncCalType.LCallType));

            Useless.Add(new TermCodeItem("空號/錯誤", "Code2_1", "無此人", ";;;;空號/錯誤", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("死亡", "Code2_2", "無此人", ";;;;死亡", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("移民", "Code2_3", "無此人", ";;;;移民", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("TTL", "Code2", "無此人", "", "無此人", TermCodeItem.ncCalType.LCallType));

            Useless.Add(new TermCodeItem("無人接聽(下一筆名單)", "Code3_1", "無人接聽", ";;;;無人接聽(下一筆名單)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("無人接聽(下一通電話)", "Code3_2", "無人接聽", ";;;;無人接聽(下一通電話)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("TTL", "Code3", "無人接聽", "", "無人接聽", TermCodeItem.ncCalType.LCallType));
        }
    }
}
