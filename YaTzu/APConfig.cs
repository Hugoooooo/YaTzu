using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Framework.DataLayer;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Framework.Common;
using System.DataLayer;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using System.DataLayer.Views;
using System.Framework;
using System.Reflection;
using System.ComponentModel;

namespace YaTzu
{
    public class APConfig
    {
        private static readonly ILog TxtLog = LogManager.GetLogger(typeof(SQLConnection));

        public static string MSSQLConnStringFormat = @"packet size=4096;Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};connect timeout=240;Min Pool Size=5;Max Pool Size=200";

        public static IConnection Conn = null;

        public static readonly int PageCount = 30;

        public static Exception LastException = null;

        public static bool LoginCheck = false;

        public static string AccountName = "";

        public static bool Debug = false;

        public static void LoadConfig()
        {
            string DBHost = ConfigurationManager.AppSettings["DBHost"].ToString();
            string DBDatabase = ConfigurationManager.AppSettings["DBDatabase"].ToString();
            string DBUser = ConfigurationManager.AppSettings["DBUser"].ToString();
            string DBPassword = ConfigurationManager.AppSettings["DBPassword"].ToString();
            string DBCollate = ConfigurationManager.AppSettings["DBCollate"].ToString();

            Conn = new SQLConnection(string.Format(MSSQLConnStringFormat, DBHost, DBDatabase, DBUser, DBPassword), Debug);
        }

        public static bool SweetAlert(ShowBoxType type,string msg)
        {
            using (var form = new ShowBox(type,msg))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                    return true;
                else
                    return false;
            }
        }

        public static int getSelectIndex(ComboBox ddl, string selectTxt)
        {
            int index = 0;
            foreach (string item in ddl.Items)
            {
                if (item == selectTxt)
                    return index;
                else
                    index++;
            }
            return -1;
        }

        private static List<T> GetEnumList<T>()
        {
            T[] array = (T[])Enum.GetValues(typeof(T));
            List<T> list = new List<T>(array);
            return list;
        }

        public static ComboBox loadEnum<T>(ComboBox c,string selected="", bool isALL = false)
        {
            List<T> list = GetEnumList<T>();
            c.Items.Clear();
            if (isALL)
                c.Items.Add("全部");
            foreach (T item in list)
            {
                c.Items.Add(item.ToString());
            }
            if (string.IsNullOrEmpty(selected))
                c.SelectedIndex = 0;
            else
                c.SelectedIndex = getSelectIndex(c, selected);

            return c;
        }

        public static ComboBox loadPhrase(ComboBox c, string category,bool isALL=false)
        {
            c.Items.Clear();
            if (isALL)
                c.Items.Add("全部");
            PhraseInfo view = new PhraseInfo(APConfig.Conn);
            view.Conditions = " 1=1 ";
            view.Conditions += " AND " + view.getCondition(PhraseInfo.ncConditions.category.ToString(), category);
            view.load();
            while(!view.IsEof)
            {
                c.Items.Add(view.PHS_NAME);
                view.next();
            }
            return c;
        }

        public static string sqlArrayFormat(string param)
        {
            string[] items = param.Split(',');
            for (int index = 0; index < items.Length; index++)
            {
                items[index] = string.Format("'{0}'", items[index]);
            }
            return string.Join(",", items);
        }

        public static ComboBox loadPage(ComboBox c, int maxPage)
        {
            c.Items.Clear();
            for (int i = 1; i <= maxPage; i++)
            {
                c.Items.Add(i.ToString());
            }
            if(c.Items.Count>0)
                c.SelectedIndex = 0;
            else
                APConfig.SweetAlert(ShowBoxType.alert, "查無資料" );
            return c;
        }

        public static DataSet GoPage(string sqlCommend, int pageNum)
        {
            int start = (pageNum - 1) * PageCount;
            DataSet ds = APConfig.Conn.fillDataSet(sqlCommend, start < 0 ? 0 : start, PageCount);
            return ds;
        }

        /// <summary>
        /// 上一頁
        /// </summary>
        public static bool prevPage(ref ComboBox ddlPage)
        {
            if (ddlPage.Items.Count == 0 || ddlPage.SelectedIndex == -1 || ddlPage.SelectedIndex == 0) return false;
            ddlPage.SelectedIndex--;
            return true;
        }

        /// <summary>
        /// 下一頁
        /// </summary>
        public static bool nextPage(ref ComboBox ddlPage)
        {
            if (ddlPage.Items.Count == 0 || ddlPage.SelectedIndex == -1 || ddlPage.SelectedIndex == ddlPage.Items.Count - 1) return false;
            ddlPage.SelectedIndex++;
            return true;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }
    }
}
