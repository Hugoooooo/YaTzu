using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;
using System.Linq.Expressions;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Security;
using System.Runtime.InteropServices;

namespace System.Application.Common
{
    public class My
    {
        #region 檢查類
        public static bool IsNumber(string pNumberStr)
        {
            int n;
            bool result;
            if (Int32.TryParse(pNumberStr, out n))
                result = true;
            else result = false;
            return result;
        }
        /// <summary>
        /// 身分證字號檢查
        /// </summary>
        /// <param name="id">身分證ID Number</param>
        /// <returns>是否正確</returns>
        public static bool CheckIdentity(string id)
        {
            try
            {
                // 長度要等於１０
                if (id.Length != 10)
                    return false;
                char first = Convert.ToChar(id.ToUpper().Substring(0, 1));
                // 第一個字元要在A ~ Z之間
                if (first < 'A' || first > 'Z')
                    return false;
                char second = Convert.ToChar(id.Substring(1, 1));
                // 第二個字元必須為１或２
                if (second < '1' || second > '2')
                    return false;

                int[] multiplier = new int[10] { 1, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
                int[] member = new int[11] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                member[0] = convertFirstID(first) / 10;
                member[1] = convertFirstID(first) % 10;
                for (int i = 2; i < 11; i++)
                    member[i] = Convert.ToInt16(id.Substring(i - 1, 1));

                int sum = 0;
                for (int i = 0; i < 10; i++)
                    sum += multiplier[i] * member[i];
                return ((sum + member[10]) % 10 == 0);
            }
            catch
            {
                return false;
            }
        }

        private static int convertFirstID(char first)
        {
            int result = 0;
            switch (first)
            {
                case 'A':
                    result = 10;
                    break;
                case 'B':
                    result = 11;
                    break;
                case 'C':
                    result = 12;
                    break;
                case 'D':
                    result = 13;
                    break;
                case 'E':
                    result = 14;
                    break;
                case 'F':
                    result = 15;
                    break;
                case 'G':
                    result = 16;
                    break;
                case 'H':
                    result = 17;
                    break;
                case 'I':
                    result = 34;
                    break;
                case 'J':
                    result = 18;
                    break;
                case 'K':
                    result = 19;
                    break;
                case 'L':
                    result = 20;
                    break;
                case 'M':
                    result = 21;
                    break;
                case 'N':
                    result = 22;
                    break;
                case 'O':
                    result = 35;
                    break;
                case 'P':
                    result = 23;
                    break;
                case 'Q':
                    result = 24;
                    break;
                case 'R':
                    result = 25;
                    break;
                case 'S':
                    result = 26;
                    break;
                case 'T':
                    result = 27;
                    break;
                case 'U':
                    result = 28;
                    break;
                case 'V':
                    result = 29;
                    break;
                case 'W':
                    result = 32;
                    break;
                case 'X':
                    result = 30;
                    break;
                case 'Y':
                    result = 31;
                    break;
                case 'Z':
                    result = 33;
                    break;
            }
            return result;
        }
        #endregion

        #region 日期時間類
        /// <summary>
        /// 將日期時間轉換成字串
        /// </summary>
        /// <param name="dt">日期時間</param>
        /// <returns>回傳字串yyyy/mm/dd HH:MM:SS</returns>
        public static string DatetimeToDateTimeStr(DateTime dt)
        {
            return string.Format("{0}/{1}/{2} {3}:{4}:{5}",
                PatchZero(4, dt.Year),
                PatchZero(2, dt.Month),
                PatchZero(2, dt.Day),
                PatchZero(2, dt.Hour),
                PatchZero(2, dt.Minute),
                PatchZero(2, dt.Second));
        }
        public static string AMonthAgo()
        {
            return DatetimeToDateStr(DateTime.Now.AddMonths(-1));
        }
        public static string FirstDateOfCurrentMonth()
        {
            return DatetimeToDateStr(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1));
        }
        public static string LastDateOfCurrentMonth()
        {
            return DatetimeToDateStr(new DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month, 1).AddDays(-1));
        }

        public static string DatetimeToDateStr(DateTime dt)
        {
            return string.Format("{0}/{1}/{2}",
                PatchZero(4, dt.Year),
                PatchZero(2, dt.Month),
                PatchZero(2, dt.Day));
        }

        public static string DatetimeToTimeStr(DateTime dt)
        {
            return string.Format("{0}:{1}:{2}",
                PatchZero(2, dt.Hour),
                PatchZero(2, dt.Minute),
                PatchZero(2, dt.Second));
        }

        public static string DatetimeToDateWithoutSlashStr(DateTime dt)
        {
            return string.Format("{0}{1}{2}",
                PatchZero(4, dt.Year),
                PatchZero(2, dt.Month),
                PatchZero(2, dt.Day));
        }

        public static string DatetimeToChineseDateStr(DateTime dt)
        {
            return string.Format("{0}/{1}/{2}",
                PatchZero(3, dt.Year - 1911),
                PatchZero(2, dt.Month),
                PatchZero(2, dt.Day));
        }

        public static string DatetimeToChineseDateWithoutSlashStr(DateTime dt)
        {
            return string.Format("{0}{1}{2}",
                PatchZero(3, dt.Year - 1911),
                PatchZero(2, dt.Month),
                PatchZero(2, dt.Day));
        }

        /// <summary>
        /// 將日期轉換成民國年日期格式
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns>回傳民國年字串</returns>
        public static string ConvertDateToChineseFormatYear(DateTime dt)
        {
            return Convert.ToString(dt.Year - 1911);
        }
        //將日期轉成民國年月
        public static string ConvertDateToChineseYearMonth(DateTime dt)
        {
            string year = Convert.ToString(dt.Year - 1911);
            string month = PatchZero(2, dt.Month);

            return year + month;
        }
        //將日期轉成民國年月日
        public static string ConvertDateToChineseDate(DateTime dt)
        {
            string year = Convert.ToString(dt.Year - 1911);
            string month = PatchZero(2, dt.Month);
            string day = PatchZero(2, dt.Day);

            return year + month + day;
        }

        /// <summary>
        /// 將日期時間字串轉換成日期時間
        /// </summary>
        /// <param name="dt">日期時間字串</param>
        /// <returns>回傳日期時間字串</returns>
        public static DateTime DateTimeStrToDatetime(string dt)
        {
            DateTime datetime = DateTime.MinValue;
            if (dt.Length == 19)
                DateTime.TryParseExact(dt, "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime);
            else if (dt.Length == 10)
                DateTime.TryParseExact(dt, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime);

            return datetime;
        }

        public static string DayOfWeek(DateTime dt)
        {
            string dayOfWeek = dt.DayOfWeek.ToString();
            switch (dayOfWeek)
            {
                case "Monday":
                    dayOfWeek = "星期一";
                    break;
                case "Tuesday":
                    dayOfWeek = "星期二";
                    break;
                case "Wednesday":
                    dayOfWeek = "星期三";
                    break;
                case "Thursday":
                    dayOfWeek = "星期四";
                    break;
                case "Friday":
                    dayOfWeek = "星期五";
                    break;
                case "Saturday":
                    dayOfWeek = "星期六";
                    break;
                case "Sunday":
                    dayOfWeek = "星期日";
                    break;
            }
            return dayOfWeek;
        }
        #endregion

        #region 功能類
        public static string DESEncrypt(SecureString strText, string key = "27339379", string iv = "27339379")
        {
            byte[] byKey = null;
            byte[] IV = { 0xE2, 0x3F, 0xC6, 0xA8, 0x9D, 0x1B, 0xC9, 0xE0 };
            IntPtr intPtr = Marshal.SecureStringToBSTR(strText);

            byKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider(); //DESCryptoServiceProvider ==>TripleDESCryptoServiceProvider
            byte[] inputByteArray = Encoding.UTF8.GetBytes(Marshal.PtrToStringBSTR(intPtr));
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string DESDecrypt(SecureString strText, string key = "27339379", string iv = "27339379")
        {
            byte[] byKey = null;
            byte[] IV = { 0xE2, 0x3F, 0xC6, 0xA8, 0x9D, 0x1B, 0xC9, 0xE0 };
            byte[] inputByteArray = new Byte[strText.Length];

            IntPtr intPtr = Marshal.SecureStringToBSTR(strText);
            //fix Fortify Privacy Violation 2015/06/10
            //string PwdSecureString = SecureStringToString(strText);
            byKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider(); //DESCryptoServiceProvider ==>TripleDESCryptoServiceProvider
            inputByteArray = Convert.FromBase64String(Marshal.PtrToStringBSTR(intPtr));
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            Encoding encode = new System.Text.UTF8Encoding();
            return encode.GetString(ms.ToArray());
        }
        public static SecureString getPwdSecurity(string vstrPassword)
        {
            SecureString result = new SecureString();
            foreach (char c in vstrPassword)
                result.AppendChar(c);
            return result;
        }
        /// <summary>
        /// DES 加密字串
        /// </summary>
        /// <param name="original">原始字串</param>
        /// <param name="key">Key，長度必須為 8 個 ASCII 字元</param>
        /// <param name="iv">IV，長度必須為 8 個 ASCII 字元</param>
        /// <returns></returns>
        public static string EncryptByDES(string original, string key = "27339379", string iv = "27339379")
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = Encoding.ASCII.GetBytes(key);
                des.IV = Encoding.ASCII.GetBytes(iv);
                byte[] s = Encoding.ASCII.GetBytes(original);
                ICryptoTransform desencrypt = des.CreateEncryptor();
                return BitConverter.ToString(desencrypt.TransformFinalBlock(s, 0, s.Length)).Replace("-", string.Empty);
            }
            catch
            {
                return original;
            }
        }

        /// <summary>   
        /// DES 解密字串   
        /// </summary>   
        /// <param name="hexString">加密後 Hex String</param>   
        /// <param name="key">Key，長度必須為 8 個 ASCII 字元</param>   
        /// <param name="iv">IV，長度必須為 8 個 ASCII 字元</param>   
        /// <returns></returns>   
        public static string DecryptByDES(string hexString, string key = "27339379", string iv = "27339379")
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = Encoding.ASCII.GetBytes(key);
                des.IV = Encoding.ASCII.GetBytes(iv);

                byte[] s = new byte[hexString.Length / 2];
                int j = 0;
                for (int i = 0; i < hexString.Length / 2; i++)
                {
                    s[i] = Byte.Parse(hexString[j].ToString() + hexString[j + 1].ToString(), System.Globalization.NumberStyles.HexNumber);
                    j += 2;
                }
                ICryptoTransform desencrypt = des.CreateDecryptor();
                return Encoding.ASCII.GetString(desencrypt.TransformFinalBlock(s, 0, s.Length));
            }
            catch
            {
                return hexString;
            }
        }

        private static Rfc2898DeriveBytes generatorRfc(int bytes)
        {
            string SecurityKey = "27339379";
            byte[] salt = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            return new Rfc2898DeriveBytes(SecurityKey, salt, bytes);
        }
        /// <summary>
        /// 使用AES(base 256)演算法加密
        /// </summary>
        /// <param name="strText">要加密的字串</param>
        /// <returns></returns>
        public static string AESEncrypt(string strText)
        {
            if (strText == "") return "";
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.Key = generatorRfc(32).GetBytes(32);
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                byte[] s = Encoding.ASCII.GetBytes(strText);
                ICryptoTransform aesEncrypt = aes.CreateEncryptor();
                return Convert.ToBase64String(aesEncrypt.TransformFinalBlock(s, 0, s.Length));
            }
            catch (Exception ex)
            {
                //throw ex;
                return strText;
            }
        }
        /// <summary>
        /// 使用AES(base 256)演算法解密
        /// </summary>
        /// <param name="strText">要解密的字串</param>
        /// <returns></returns>
        public static string AESDecrypt(string strText)
        {
            if (strText == "") return "";
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.Key = generatorRfc(32).GetBytes(32);
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                byte[] s = Convert.FromBase64String(strText);
                ICryptoTransform aesDecrypt = aes.CreateDecryptor();
                byte[] resultArray = aesDecrypt.TransformFinalBlock(s, 0, s.Length);
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                return strText;
            }
        } 

        /// <summary>
        /// 地址分兩行
        /// </summary>
        /// <param name="addr">原始地址</param>
        /// <param name="addr1">地址行一</param>
        /// <param name="addr2">地址行二</param>
        /// <param name="addr2">地址行三</param>
        /// <returns></returns>
        public static bool CutAddress(string addr, out string addr1, out string addr2, out string addr3)
        {
            string[] breakpoint = new string[8] { "村", "里", "鄰", "路", "段", "街", "道", "場" };
            string[] breakpoint2 = new string[3] { "F", "樓", "號" };
            addr1 = addr;
            addr2 = "";
            addr3 = "";
            for (int i = 0; i < breakpoint.Length; i++)
            {
                for (int j = 0; j < addr.Length; j++)
                {
                    if (addr[j].ToString() == breakpoint[i].ToString())
                    {
                        addr1 = addr.Substring(0, j + 1);
                        addr2 = addr.Substring(j + 1, addr.Length - j - 1);
                        break;
                    }
                }
                if (addr2 != "") break;
            }
            if (addr1.Length > 12)
            {
                addr1 = addr.Substring(0, 12);
                addr2 = addr.Substring(12, addr.Length - 12);
            }
            if (addr2.Length > 12)
            {
                for (int i = 0; i < breakpoint2.Length; i++)
                {
                    for (int j = 0; j < addr2.Length; j++)
                    {
                        if (addr2[j].ToString() == breakpoint2[i].ToString())
                        {
                            addr3 = addr2.Substring(j + 1, addr2.Length - j - 1);
                            addr2 = addr2.Substring(0, j + 1);
                            break;
                        }
                    }
                    if (addr3 != "") break;
                }
            }
            return true;
        }
        /// <summary>
        /// 姓名分兩行
        /// </summary>
        /// <param name="name">原始姓名</param>
        /// <param name="name1">姓名行一</param>
        /// <param name="name2">姓名行二</param>
        public static bool CutName(string name, out string name1, out string name2)
        {
            name1 = "";
            name2 = "";
            if (name.Length > 8)
            {
                name1 = name.Substring(0, 8);
                name2 = name.Substring(8, name.Length - 8);
            }
            else name1 = name;
            return true;
        }

        public enum MoneyType
        {
            /// <summary>
            /// 表示新台幣。
            /// </summary>
            NTD,
            /// <summary>
            /// 表示人民幣。
            /// </summary>
            RMB
        }

        public static string GetChineseMoney(decimal d, MoneyType moneyType = MoneyType.NTD)
        {
            string o = d.ToString();
            string dq = "", dh = "";
            if (o.Contains("."))
            {
                dq = o.Split('.')[0];
                dh = o.Split('.')[1];
            }
            else dq = o;
            string ret = "";
            if (dh == "")
                ret = GetMoney(dq, true, "元", moneyType);
            else ret = GetMoney(dq, true, "元", moneyType) + GetMoney(dh, false, "", moneyType);
            return ret + "整";
        }

        private static string GetMoney(string number, bool left, string lastdw, MoneyType type)
        {
            string[] NTD = new string[10] { "零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖" };
            string[] DW = new string[8] { "厘", "分", "角", "", "拾", "佰", "仟", "萬" };
            int first = 4;
            string str = "";
            if (!left)
            {
                first = 1;
                if (number.Length == 1)
                    number += "00";
                else if (number.Length == 2)
                    number += "0";
                else number = number.Substring(0, 3);
            }
            else
            {
                if (number.Length >= 9)
                    return GetMoney(number.Substring(0, number.Length - 8), true, "億", type) + GetMoney(number.Substring(number.Length - 8, 8), true, "元", type);
                if (number.Length >= 5)
                    return GetMoney(number.Substring(0, number.Length - 4), true, "萬", type) + GetMoney(number.Substring(number.Length - 4, 4), true, "元", type);
            }
            bool has0 = false;
            for (int i = 0; i < number.Length; ++i)
            {
                int w = number.Length - i + first - 2;
                if (int.Parse(number[i].ToString()) == 0)
                {
                    has0 = true;
                    continue;
                }
                else
                {
                    if (has0)
                    {
                        str += "零";
                        has0 = false;
                    }
                }
                str += NTD[int.Parse(number[i].ToString())];
                str += DW[w];
            }
            if (left)
                str += lastdw;
            return str;
        }

        #region 星座
        private static string[] ConstellationName =
              {
              "白羊座", "金牛座", "雙子座","巨蟹座", "獅子座", "處女座",
              "天秤座", "天蠍座", "射手座","摩羯座", "水瓶座", "雙魚座"
              };
        /// <summary>
        /// 計算指定日期的星座序號
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns>星座序號</returns>
        private static int GetConstellation(DateTime dt)
        {
            int Y, M, D;
            Y = dt.Year;
            M = dt.Month;
            D = dt.Day;
            Y = M * 100 + D;
            if (((Y >= 321) && (Y <= 419))) { return 0; }
            else if ((Y >= 420) && (Y <= 520)) { return 1; }
            else if ((Y >= 521) && (Y <= 620)) { return 2; }
            else if ((Y >= 621) && (Y <= 722)) { return 3; }
            else if ((Y >= 723) && (Y <= 822)) { return 4; }
            else if ((Y >= 823) && (Y <= 922)) { return 5; }
            else if ((Y >= 923) && (Y <= 1022)) { return 6; }
            else if ((Y >= 1023) && (Y <= 1121)) { return 7; }
            else if ((Y >= 1122) && (Y <= 1221)) { return 8; }
            else if ((Y >= 1222) || (Y <= 119)) { return 9; }
            else if ((Y >= 120) && (Y <= 218)) { return 10; }
            else if ((Y >= 219) && (Y <= 320)) { return 11; }
            else { return -1; };
        }

        /// <summary>
        /// 計算指定日期的星座名稱
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns>星座</returns>
        public static string GetConstellationName(DateTime dt)
        {
            int Constellation;
            Constellation = GetConstellation(dt);
            if ((Constellation >= 0) && (Constellation <= 11))
            {
                return ConstellationName[Constellation];
            }
            else
            {
                return "";
            };
        }
        #endregion

        #region 農曆

        /// <summary>
        /// 取得農曆的日期
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public static string GetLunisolarDate(DateTime dt)
        {
            string lunisolarDate = "";
            TaiwanLunisolarCalendar tlc = new TaiwanLunisolarCalendar();

            if (tlc.IsLeapYear(tlc.GetYear(dt)) && tlc.GetMonth(dt) >= tlc.GetLeapMonth(tlc.GetYear(dt)))
            {
                lunisolarDate = FormatLunisolarYear(tlc.GetYear(dt)) +
                    FormatLunisolarMonth(tlc.GetMonth(dt) - 1) +
                    FormatLunisolarDay(tlc.GetDayOfMonth(dt));
            }
            else
            {
                lunisolarDate = FormatLunisolarYear(tlc.GetYear(dt)) +
                    FormatLunisolarMonth(tlc.GetMonth(dt)) +
                    FormatLunisolarDay(tlc.GetDayOfMonth(dt));
            }
            //return "農曆 " + lunisolarDate; 
            return lunisolarDate;
        }

        /// <summary>
        /// 把 year 年格式化成「天干記年法」表示的字串符號
        /// </summary>
        /// <param name="year">農曆年</param>
        /// <returns></returns>
        private static string FormatLunisolarYear(int year)
        {
            string strYear;
            string szText1 = "甲乙丙丁戊己庚辛壬癸";
            string szText2 = "子丑寅卯辰巳午未申酉戌亥";
            string szText3 = "鼠牛虎免龍蛇馬羊猴雞狗豬";
            //ushort iYear = (ushort)(year);
            //strYear = szText1.Substring((iYear - 4) % 10, 1);
            //strYear = strYear + szText2.Substring((iYear - 4) % 12, 1);
            //strYear = strYear + " ";
            strYear = szText1.Substring((year - 3) % 10, 1) + szText2.Substring((year - 1) % 12, 1);
            strYear += "(" + szText3.Substring((year - 1) % 12, 1) + ") ";
            //strYear += "年 ";
            return strYear;
        }
        /// <summary>
        /// 取回格式化後的月份名稱 ( 例如：一月 => 在農曆的格式叫做「正月」 )
        /// </summary>
        /// <param name="month">月份</param>
        /// <returns></returns>
        private static string FormatLunisolarMonth(int month)
        {
            string szText = "正二三四五六七八九十";
            string strMonth = "";

            if (month <= 10)
            {
                strMonth += szText.Substring(month - 1, 1);
            }
            else if (month == 11)
            {
                strMonth = "十一";
            }
            else
            {
                strMonth = "十二";
            }
            return strMonth + "月";
        }
        /// <summary>
        /// 取回格式化後的農曆日期名稱 ( 例如：一日 => 在農曆的格式叫做「初一」 )
        /// </summary>
        /// <param name="day">農曆的日期(「日」的部分)</param>
        /// <returns></returns>
        private static string FormatLunisolarDay(int day)
        {
            string szText1 = "初十廿三";
            string szText2 = "一二三四五六七八九十";
            string strDay;
            if ((day != 20) && (day != 30))
            {
                strDay = szText1.Substring((day - 1) / 10, 1);
                strDay += szText2.Substring((day - 1) % 10, 1);
            }
            else
            {
                strDay = szText2.Substring((day / 10) - 1, 1);
                strDay += "十";
            }
            return strDay;
        }
        #endregion

        #region 套印 Word Merge
        /// <summary>
        /// 組合套印字串, 偷偷告訴你動態組字串的話, StringBuilder效率比字串相加快N倍
        /// </summary>
        /// <param name="mergeContent"></param>
        /// <param name="mDictionary"></param>
        public static void MergeContentBuilder(ref string mergeContent, Dictionary<string, string> mDictionary)
        {
            StringBuilder stringBuilder = new StringBuilder(mergeContent);
            int index = 0;
            foreach (KeyValuePair<string, string> item in mDictionary)
            {
                if (index++ == 0)
                    stringBuilder.AppendFormat("{0}[::]{1}", item.Key, item.Value);
                else
                    stringBuilder.AppendFormat("[;;]{0}[::]{1}", item.Key, item.Value);
            }

            mergeContent = stringBuilder.ToString();
        }
        /// <summary>
        /// 與套印Service連接
        /// </summary>
        /// <param name="mergeDoc">套印文件</param>
        /// <param name="mergeContent">套印內容</param>
        /// <param name="zipDir">檔案下載路徑</param>
        /// <returns></returns>
        public static bool SocketConnection(string mergeDoc, string mergeContent,string action, out string fileDir)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6789);
            Socket server = null;

            try
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Connect(ipep);

                string sendContent = action + "[++]" + mergeDoc + "[++]" + mergeContent;
                byte[] data = Encoding.UTF8.GetBytes(sendContent);
                server.Send(data);

                byte[] receiveBytes = new byte[1024];
                int bytes = 0;
                string returnStr = string.Empty;
                while (true)
                {
                    bytes = server.Receive(receiveBytes);
                    returnStr = Encoding.UTF8.GetString(receiveBytes, 0, bytes);

                    if (returnStr == "PrintFail")
                        throw new Exception();
                    if (bytes < 1024 || bytes == 0)
                    {
                        break;
                    }
                }
                fileDir = returnStr;
            }
            catch (Exception ex)
            {
                fileDir = null;
                return false;
            }

            finally
            {
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }

            return true;
        }

        #endregion

        #endregion

        #region 工具類
        /// <summary>
        /// 產生序號(20Bytes)
        /// </summary>
        /// <returns>回傳Guid前8後12碼</returns>
        public static string GenSerNo()
        {
            string[] guid = Guid.NewGuid().ToString().Split('-');
            return guid[4];
        }

        /// <summary>
        /// 不滿N位數的數字前面補０
        /// </summary>
        /// <param name="Bits">N位數</param>
        /// <param name="Num">數值</param>
        /// <returns></returns>
        public static string PatchZero(int bits, int num)
        {
            string sNum = Convert.ToString(num);
            return PatchZero(bits, sNum);
        }

        public static string PatchZero(int bits, string data)
        {
            string sNum = data.Trim();
            string sZero = "";
            for (int i = 0; i < (bits - sNum.Length); i++)
                sZero += "0";
            return sZero + sNum;
        }

        /// <summary>
        /// 不滿N位數的字串前面補空白
        /// </summary>
        /// <param name="Bits">N位數</param>
        /// <param name="data">字串</param>
        /// <returns></returns>
        public static string PatchSpace(int bits, string data)
        {
            string sNum = data.Trim();
            string sSpace = "";
            for (int i = 0; i < (bits - sNum.Length); i++)
                sSpace += " ";
            return sSpace + sNum;
        }

        public static string GetSpace(int bit)
        {
            string space = "";
            for (int i = 0; i < bit; i++)
                space += " ";
            return space;
        }

        /// <summary>
        /// 產生屬性字串
        /// </summary>
        public static string NameOf<T>(Expression<Func<T>> expr)
        {
            return ((MemberExpression)expr.Body).Member.Name;
        }

        /// <summary>
        /// 分析內容轉換成套印格式
        /// </summary>
        /// <param name="inData">字串</param>
        /// <returns>部分字串</returns>
        public static string WordMergeFormat(string inData)
        {
            inData = Regex.Replace(inData, " ", "");                                    //過濾掉非編輯器的空白  
            string outData = Regex.Replace(inData, @"\r\n?|\n", "");                    //過濾掉非編輯器的換行
            outData = Regex.Replace(outData, @"<br>", "\n");                     //將編輯器的換行符號改成word格式
            outData = Regex.Replace(outData, "<[^>]*>", "", RegexOptions.IgnoreCase);   //過濾掉Html tag
            outData = Regex.Replace(outData, "&nbsp;", " ", RegexOptions.IgnoreCase);   //取代掉Html tag 空白
            return outData;
        }

        /// <summary>
        /// 字串轉號成貨幣格式
        /// </summary>
        /// <param name="AData">字串</param>
        /// <param name="ALen">取小數後幾位</param>
        /// <returns>部分字串</returns>
        public static string CurrencyFormat(string pData, int pLen = 0)
        {
            double tData = (string.IsNullOrEmpty(pData)) ? 0 : double.Parse(pData);
            string fData = string.Format("{0:N" + pLen + "}", tData);
            return fData;
        }

        /// <summary>
        /// 字串轉號成貨幣格式
        /// </summary>
        /// <param name="AData">字串</param>
        /// <param name="ALen">取小數後幾位</param>
        /// <returns>部分字串</returns>
        public static string PercentFormat(string pData , int pLen = 0)
        {
            double tData = (string.IsNullOrEmpty(pData)) ? 0 : double.Parse(pData);
            string fData = string.Format("{0:P" + pLen + "}", tData);
            return fData;
        }

        /// <summary>
        /// 計算稅率與手續費格式
        /// </summary>
        /// <param name="subData">字串(分子)</param>
        /// <param name="momData">字串(母)</param> 
        /// <param name="pLen">取小數後幾位</param>
        /// <returns>部分字串</returns>
        public static string TaxFormat(double subData, double momData, int pLen = 0)
        {
            double fData = Math.Round((subData / momData), pLen) * 100;
            return fData.ToString();
        }

        /// <summary>
        /// 取字串(從左取?位)
        /// </summary>
        /// <param name="AData">字串</param>
        /// <param name="ALen">取長度</param>
        /// <returns>部分字串</returns>
        public static string Take(string pData, int pLen)
        {
            if (pData.Length > pLen)
                return pData.Substring(0, pLen);
            else return pData;
        }

        public static string Commafy(string pData)
        {
            int i = 0;
            bool result = int.TryParse(pData, out i);
            if (result)
                return i.ToString("N0");
            else return pData;
        }
        public static string UnCommafy(string pData)
        {
            return pData.Replace(",", "");
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return ms.ToArray();
        }

        public static System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        /// <summary>
        /// server端接收input資料時要解碼
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UnEscape(string str)
        {
            if (str == null)
                return String.Empty;

            StringBuilder sb = new StringBuilder();
            int len = str.Length;
            int i = 0;
            while (i != len)
            {
                if (Uri.IsHexEncoding(str, i))
                    sb.Append(Uri.HexUnescape(str, ref i));
                else
                    sb.Append(str[i++]);
            }
            return sb.ToString();
        }
        #endregion
    }
}
