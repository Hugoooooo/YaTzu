using System;
using System.Framework.DataLayer;
using System.Collections.Generic;
using System.Data;

namespace System.DataLayer.Base
{
    /// <summary>
    /// ExcelView ���K�n�y�z�C
    /// </summary>
    public class ExcelView : BaseView
    {
        public class TermCodeItem
        {
            public enum ncCalType { Count, Sum, LCallType }

            /// <summary>���W��</summary>
            public string Name { get; private set; }

            /// <summary>sql alias name</summary>
            public string Key { get; private set; }

            /// <summary>�s�����W��</summary>
            public string Group { get; private set; }

            /// <summary>
            /// CalType:LCallType, �Ѥ������j����RST_LCALLTYPE��������r
            /// ��L:��bCASE WHEN���᪺����
            /// </summary>
            public string Condition { get; private set; }

            /// <summary>
            /// �έp���(CASE WHEN XXX THEN����)
            /// �YGroup == Value�A�h���p�O���
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
        public string Term_Code1_A = RosterStatusType.getFieldComment(RosterStatusType.Useless);//"�L�ĦW��";
        public string Term_Code1_A2 = RosterStatusType.getFieldComment(RosterStatusType.Useless2);//"�W����D";
        public string Term_Code1_B = RosterStatusType.getFieldComment(RosterStatusType.Fail);//"��P����";
        public string Term_Code1_B2 = RosterStatusType.getFieldComment(RosterStatusType.Fail2);//"�Ȥ�ڵ�";
        public string Term_Code1_C = RosterStatusType.getFieldComment(RosterStatusType.ThinkAbout);//"�Ҽ{��";
        public string Term_Code1_D = RosterStatusType.getFieldComment(RosterStatusType.ContactAgain);//"�A�p��";
        public string Term_Code1_E = RosterStatusType.getFieldComment(RosterStatusType.Success);//"���\";
        public string Term_Code1_F = "���౵�q";
        public string Term_Code1_G = "���@�q�P";
        ////Term_Code_A5=RST_LCALLTYPE5
        public string Term_Code5_A_1 = "�W�歫��";
        public string Term_Code5_A_2 = "�~�֤��X��O���";
        public string Term_Code5_A_3 = "���d���X��O���";
        public string Term_Code5_A_4 = "¾�~���X��O���";
        public string Term_Code5_A_5 = "�S��L�H�Υd";
        public string Term_Code5_A_6 = "���}�d";
        public string Term_Code5_A_7 = "�w�ťd";
        public string Term_Code5_A_8 = "�L���H";
        public string Term_Code5_A_9 = "��¾�B�h�a�B�����B�X��";
        public string Term_Code5_A_10 = "�������L�k�p��";
        public string Term_Code5_A_11 = "���G";
        public string Term_Code5_B_1 = "�P��L���W�c";
        public string Term_Code5_B_2 = "�Ȧ���/�O�I�~�ȭ�";
        public string Term_Code5_B_3 = "��Ȧ椣���N";
        public string Term_Code5_B_4 = "�ﲣ�~�����N";
        public string Term_Code5_B_5 = "�j�P�ڵ�/���@�q�P";
        public string Term_Code5_B_6 = "�ֳt�ڵ�";
        public string Term_Code5_B_7 = "��O�I���q�����N";
        public string Term_Code5_B_8 = "�w���M�H�A��/�a�H���P�~";
        public string Term_Code5_B_9 = "�a�H�ˤͤϹ�";
        public string Term_Code5_B_10 = "�ݭn��L���~";
        public string Term_Code5_B_11 = "�S�ݭn�S�w��/�O�I�ܦh/��L";
        public string Term_Code5_B_12 = "���@�q�P";
        public string Term_Code5_C_1 = "���|�O��";
        public string Term_Code5_C_2 = "�ǯu/�l�H";
        public string Term_Code5_C_3 = "���H�b��";
        public string Term_Code5_C_4 = "�Ҽ{��";		
        public string Term_Code5_C_5 = "�Ҽ{��-A";
        public string Term_Code5_C_6 = "�Ҽ{��-B";
        public string Term_Code5_C_7 = "�Ҽ{��-C";		
        public string Term_Code5_C_8 = "A�ūȤ�-�ǯu";
        public string Term_Code5_C_9 = "A�ūȤ�-�l�H";
        public string Term_Code5_C_10 = "B�ūȤ�-�ǯu";
        public string Term_Code5_C_11 = "B�ūȤ�-�l�H";
        public string Term_Code5_C_12 = "C�ūȤ�-�ǯu";
        public string Term_Code5_C_13 = "C�ūȤ�-�l�H";
        public string Term_Code5_C_14 = "D�ūȤ�-�������O�椺�e";
        public string Term_Code5_D_1 = "�Ȥ�b��";
        public string Term_Code5_D_2 = "�D���H��ť";
        //public string Term_Code5_E_1 = "TMR-���֫O";
        public string Term_Code5_F_1 = "���u��";
        public string Term_Code5_F_2 = "�L�H��ť";
        public string Term_Code5_F_3 = "�q�ܦ��~";
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
        /// �����D���ƻ�b�o�䤣���DataRow.Field<T>()
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
            TermCodeItems.Add(new TermCodeItem("�A�p��", "Code1", "", "�����H;�A�p��", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            TermCodeItems.Add(new TermCodeItem("�Ҽ{��", "Code2", "", "�����H;�Ҽ{��", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            TermCodeItems.Add(new TermCodeItem("����", "Code3", "", "�����H;����", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            TermCodeItems.Add(new TermCodeItem("���A�X�P���", "Code4", "", "�����H;���A�X�P���", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            TermCodeItems.Add(new TermCodeItem("�L���H", "Code5", "", "�L���H", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            TermCodeItems.Add(new TermCodeItem("�L�H��ť", "Code6", "", "�L�H��ť", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            TermCodeItems.Add(new TermCodeItem("���@�q�P", "Code7", "", "���@�q�P", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            //TermCodeItems.Add(new TermCodeItem("�P�N��O", "TMR_NEW", "",
            //    "R.RST_STATUS = '" + RosterStatusType.Success + "' AND DB.DBG_ISDIALDEAL = '1' AND  DB.DBG_EFFDATE BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'",
            //    "DB.DBG_SERNO", TermCodeItem.ncCalType.Count));
            TermCodeItems.Add(new TermCodeItem("�P�N��O", "TMR_NEW", "",
                "R.RST_STATUS = '" + RosterStatusType.Success + "' AND R.RST_LDIALDTTM BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'",
                "R.RST_SERNO", TermCodeItem.ncCalType.Count));


            AppointmentItmes = new List<TermCodeItem>();
            AppointmentItmes.Add(new TermCodeItem("�Ҽ{��A(����Ȥ�)", "Code1_1", "�Ҽ{��", ";;;;�Ҽ{��A(����Ȥ�)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("�Ҽ{��B(�����Ȥ�)", "Code1_2", "�Ҽ{��", ";;;;�Ҽ{��B(�����Ȥ�)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("�Ҽ{��C(�L��Ȥ�,���|���ڵ�)", "Code1_3", "�Ҽ{��", ";;;;�Ҽ{��C(�L��Ȥ�,���|���ڵ�)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("TTL", "Code1", "�Ҽ{��", ";�Ҽ{��", "�Ҽ{��", TermCodeItem.ncCalType.LCallType));

            AppointmentItmes.Add(new TermCodeItem("���L(�U�@���W��)", "Code2_1", "�A�p��", ";;;;���L(�U�@���W��)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("���L(�U�@�q�q��)", "Code2_2", "�A�p��", ";;;;���L(�U�@�q�q��)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("���u�B���b�B�X��(�U�@���W��)", "Code2_3", "�A�p��", ";;;;���u�B���b�B�X��(�U�@���W��)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("���u�B���b�B�X��(�U�@�q�q��)", "Code2_4", "�A�p��", ";;;;���u�B���b�B�X��(�U�@�q�q��)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            AppointmentItmes.Add(new TermCodeItem("TTL", "Code2", "�A�p��", ";�A�p��", "�A�p��", TermCodeItem.ncCalType.LCallType));

            RejectItems = new List<TermCodeItem>();
            RejectItems.Add(new TermCodeItem("�O�I�Ӧh", "Code1_1", "����", ";;;;�O�I�Ӧh", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("�O�I���ݭn", "Code1_2", "����", ";;;;�O�I���ݭn", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("�g�٦]��", "Code1_3", "����", ";;;;�g�٦]��", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("�ˤͤϹ�", "Code1_4", "����", ";;;;�ˤͤϹ�", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("�������q�P", "Code1_5", "����", ";;;;�������q�P", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("�P��L���W�c", "Code1_6", "����", ";;;;�P��L���W�c", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("��L", "Code1_7", "����", ";;;;��L", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            RejectItems.Add(new TermCodeItem("TTL", "Code1", "����", ";����", "����", TermCodeItem.ncCalType.LCallType));

            Useless = new List<TermCodeItem>();
            Useless.Add(new TermCodeItem("���Z", "Code1_1", "���A�X�P���", ";;;;���Z", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("�֫O���D��", "Code1_2", "���A�X�P���", ";;;;�֫O���D��-��p�B�]�ȡB¾�~", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("�P�~", "Code1_3", "���A�X�P���", ";;;;�P�~", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("TTL", "Code1", "���A�X�P���", "", "���A�X�P���", TermCodeItem.ncCalType.LCallType));

            Useless.Add(new TermCodeItem("�Ÿ�/���~", "Code2_1", "�L���H", ";;;;�Ÿ�/���~", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("���`", "Code2_2", "�L���H", ";;;;���`", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("����", "Code2_3", "�L���H", ";;;;����", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("TTL", "Code2", "�L���H", "", "�L���H", TermCodeItem.ncCalType.LCallType));

            Useless.Add(new TermCodeItem("�L�H��ť(�U�@���W��)", "Code3_1", "�L�H��ť", ";;;;�L�H��ť(�U�@���W��)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("�L�H��ť(�U�@�q�q��)", "Code3_2", "�L�H��ť", ";;;;�L�H��ť(�U�@�q�q��)", "R.RST_SERNO", TermCodeItem.ncCalType.LCallType));
            Useless.Add(new TermCodeItem("TTL", "Code3", "�L�H��ť", "", "�L�H��ť", TermCodeItem.ncCalType.LCallType));
        }
    }
}
