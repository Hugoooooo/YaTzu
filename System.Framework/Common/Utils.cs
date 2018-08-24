using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using log4net;
using log4net.Config;
using System.Collections.Generic;

namespace System.Framework.Common
{
    /// <summary>
    /// Utils 的摘要描述。
    /// </summary>
    public class Utils
    {
        private static readonly ILog TxtLog = LogManager.GetLogger("TMPro");
        #region Security
        private static Rfc2898DeriveBytes generatorRfc(int bytes)
        {
            string SecurityKey = "27339379";
            byte[] salt = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            return new Rfc2898DeriveBytes(SecurityKey, salt, bytes);
        }

        private static Rfc2898DeriveBytes generatorRfc(int bytes, string symmetricKey)
        {
            byte[] salt = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            return new Rfc2898DeriveBytes(symmetricKey, salt, bytes);
        }

        /// <summary>
        /// 設置資料夾許可權，處理為Everyone擁有權限
        /// </summary>
        /// <param name="foldPath">資料夾路徑</param>
        public static void SetDirRole(string foldPath)
        {
            DirectorySecurity fsec = new DirectorySecurity();
            fsec.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl,
            InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            System.IO.Directory.SetAccessControl(foldPath, fsec);
        }

        /// <summary>
        /// 使用DES(base 64)演算法加密
        /// </summary>
        /// <param name="strText">要加密的字串</param>
        /// <returns></returns>
        public static string DESEncrypt(string strText) 
        {
            if (strText == "") return "";
            //licencecontrol.licencecontrolClass lic = new licencecontrol.licencecontrolClass();
            //return lic.LicEncodeStr(strText);
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = generatorRfc(8).GetBytes(8);
                des.IV = generatorRfc(8).GetBytes(8);
                byte[] s = Encoding.ASCII.GetBytes(strText);
                ICryptoTransform desEncrypt = des.CreateEncryptor();
                return BitConverter.ToString(desEncrypt.TransformFinalBlock(s, 0, s.Length)).Replace("-", string.Empty);
            }
            catch
            {
                return strText;
            }
        } 

        /// <summary>
        /// 使用DES(base 64)演算法解密
        /// </summary>
        /// <param name="strText">要解密的字串</param>
        /// <returns></returns>
        public static string DESDecrypt(string strText) 
        {
            if (strText == "") return "";
            //licencecontrol.licencecontrolClass lic = new licencecontrolClass();
            //return lic.LicDecodeStr(strText);
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = generatorRfc(8).GetBytes(8);
                des.IV = generatorRfc(8).GetBytes(8);
                byte[] s = new byte[strText.Length / 2];
                int j = 0;
                for (int i = 0; i < strText.Length / 2; i++)
                {
                    s[i] = Byte.Parse(strText[j].ToString() + strText[j + 1].ToString(), System.Globalization.NumberStyles.HexNumber);
                    j += 2;
                }
                ICryptoTransform desDecrypt = des.CreateDecryptor();
                return Encoding.ASCII.GetString(desDecrypt.TransformFinalBlock(s, 0, s.Length));
            }
            catch
            {
                return strText;
            }
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
            catch(Exception ex)
            {
                TxtLog.Debug("AESEncrypt()_Exception:" + ex.Message + ":" + ex.StackTrace);
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
            catch (Exception ex)
            {
                TxtLog.Debug("AESDecrypt()_Exception:" + ex.Message + ":" + ex.StackTrace);
                return strText;
            }
        }

        /// <summary>
        /// 使用AES(base 256)演算法加密
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="symmetricKey"></param>
        /// <returns></returns>
        public static string AESEncrypt(string strText, string symmetricKey)
        {
            if (strText == "") return "";
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.Key = generatorRfc(32, symmetricKey).GetBytes(32);
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                byte[] s = Encoding.Default.GetBytes(strText);
                ICryptoTransform aesEncrypt = aes.CreateEncryptor();
                return Convert.ToBase64String(aesEncrypt.TransformFinalBlock(s, 0, s.Length));
            }
            catch (Exception ex)
            {
                TxtLog.Debug("AESEncrypt(,)_Exception:" + ex.Message + ":" + ex.StackTrace);
                return strText;
            }
        }

        /// <summary>
        /// 使用AES(base 256)演算法解密
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="symmetricKey"></param>
        /// <returns></returns>
        public static string AESDecrypt(string strText, string symmetricKey)
        {
            if (strText == "") return "";
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.Key = generatorRfc(32, symmetricKey).GetBytes(32);
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                byte[] s = Convert.FromBase64String(strText);
                ICryptoTransform aesDecrypt = aes.CreateDecryptor();
                byte[] resultArray = aesDecrypt.TransformFinalBlock(s, 0, s.Length);
                return Encoding.Default.GetString(resultArray);
            }
            catch(Exception ex)
            {
                TxtLog.Debug("AESDecrypt(,)_Exception:" + ex.Message + ":" + ex.StackTrace);
                return strText;
            }
        }

        /// <summary>
        /// 使用SHA1演算法產生雜湊 (不可反解)
        /// </summary>
        /// <param name="code">要加密字串</param>
        /// <returns>雜湊字串</returns>
        public static string Encrypting(string code)
        {
            byte[] data = System.Text.Encoding.Unicode.GetBytes(code);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(data);
            
            return  Convert.ToBase64String(result);
        }
        #endregion

        #region Date & Time
        /// <summary>
        /// 驗證欄位值是否為日期格式
        /// </summary>
        /// <param name="txtDateTime"></param>
        /// <returns></returns>
        public static bool CheckDateTimeType(string txtDateTime) 
        {
            DateTime sd;
            if (String.IsNullOrEmpty(txtDateTime)) //日期空白
                return false;
            else if(!DateTime.TryParse(txtDateTime, out sd)) //日期格式錯誤
               return false;
            else if (sd.Year.ToString().Length < DateTime.Now.Year.ToString().Length) //年份少打
                return false;
            return true;
        }
        /// <summary>
        /// 將時間轉換成字串
        /// </summary>
        /// <param name="date">日期時間</param>
        /// <returns>回傳字串yyyy/mm/dd</returns>
        public static string DatetimeToShortDate(DateTime dt)
        {
            return string.Format("{0}/{1}/{2}", 
                repairZero(4, dt.Year) ,
                repairZero(2, dt.Month) ,
                repairZero(2, dt.Day));
        }
        public static string DatetimeToVCLogDateTime(DateTime dt)
        {
            return string.Format("{0}-{1}-{2} {3}:{4}",
                repairZero(4, dt.Year),
                repairZero(2, dt.Month),
                repairZero(2, dt.Day),
                repairZero(2, dt.Hour),
                repairZero(2, dt.Minute));
        }
        public static string DatetimeToDealListDateTime(DateTime dt)
        {
            return string.Format("{0}/{1}/{2} {3}:{4}",
                repairZero(4, dt.Year),
                repairZero(2, dt.Month),
                repairZero(2, dt.Day),
                repairZero(2, dt.Hour),
                repairZero(2, dt.Minute));
        }
        public static string DatetimeToVCLogFullDateTime(DateTime dt)
        {
            return string.Format("{0}-{1}-{2} {3}:{4}:{5}.000",
                repairZero(4, dt.Year),
                repairZero(2, dt.Month),
                repairZero(2, dt.Day),
                repairZero(2, dt.Hour),
                repairZero(2, dt.Minute),
                repairZero(2, dt.Second));
        }

        /// <summary>
        /// 將時間轉換成字串(外國版)
        /// </summary>
        /// <param name="date">日期時間</param>
        /// <returns>回傳字串yyyy/mm/dd</returns>
        public static string DatetimeToForeignDate(DateTime dt)
        {
            return string.Format("{0}{1}{2}", 
                repairZero(2, dt.Day) ,
                repairZero(2, dt.Month) ,
                repairZero(4, dt.Year));
        }

        /// <summary>
        /// 將時間轉換成字串
        /// </summary>
        /// <param name="date">日期時間</param>
        /// <returns>回傳字串yyyy.mm.dd</returns>
        public static string DatetimeToShortDateByDotSlash(DateTime dt)
        {
            return string.Format("{0}.{1}.{2}", 
                repairZero(4, dt.Year) ,
                repairZero(2, dt.Month) ,
                repairZero(2, dt.Day));
        }

        /// <summary>
        /// 將時間轉換成字串
        /// </summary>
        /// <param name="date">日期時間</param>
        /// <returns>回傳字串M月D日</returns>
        public static string DatetimeToChineseMonthDay(DateTime dt)
        {
            return string.Format("{0}月{1}日", 	dt.Month, dt.Day);
        }

        /// <summary>
        /// 將時間轉換成字串
        /// </summary>
        /// <param name="date">日期時間</param>
        /// <returns>回傳字串yyyy/mm/01</returns>
        public static string DatetimeToShortFirstDate(DateTime dt)
        {
            return string.Format("{0}/{1}/01", 
                repairZero(4, dt.Year) ,
                repairZero(2, dt.Month));
        }

        /// <summary>
        /// 將時間轉換成字串
        /// </summary>
        /// <param name="date">日期時間</param>
        /// <returns>回傳字串yyyymmdd</returns>
        public static string DatetimeToShortDateWithoutSlash(DateTime dt)
        {
            return string.Format("{0}{1}{2}", 
                repairZero(4, dt.Year) ,
                repairZero(2, dt.Month) ,
                repairZero(2, dt.Day));
        }

        public static string DatetimeToShortDateTimeWithoutSymbol(DateTime dt)
        {
            return string.Format("{0}{1}{2}{3}{4}{5}",
                repairZero(4, dt.Year),
                repairZero(2, dt.Month),
                repairZero(2, dt.Day),
                repairZero(2, dt.Hour),
                repairZero(2, dt.Minute),
                repairZero(2, dt.Second));
        }

        /// <summary>
        /// 將時間轉換成字串
        /// </summary>
        /// <param name="date">日期時間</param>
        /// <returns>回傳字串yyyymmdd</returns>
        public static string DatetimeToShortDateWithoutSlash(string dt)
        {
            string[] dtarray = Regex.Split(dt, "/");
            return string.Format("{0}{1}{2}", 
                repairZero(4, int.Parse(dtarray[0])) ,
                (dtarray.Length > 0) ? repairZero(2, int.Parse(dtarray[1])) : "  " ,
                (dtarray.Length > 1) ? repairZero(2, int.Parse(dtarray[2])) : "  "
                );
        }

        /// <summary>
        /// 將時間轉換成字串
        /// </summary>
        /// <param name="dt">日期時間</param>
        /// <returns>回傳字串yyyymmdd</returns>
        public static string DatetimeToSimpleDateTime(DateTime dt)
        {
            return string.Format("{0}{1}{2}{3}{4}{5}", 
                repairZero(4, dt.Year) ,
                repairZero(2, dt.Month),
                repairZero(2, dt.Day),
                repairZero(2, dt.Hour),
                repairZero(2, dt.Minute),
                repairZero(2, dt.Second)
                );
        }
        /// <summary>
        /// 將時間轉換成字串
        /// </summary>
        /// <param name="dt">日期時間</param>
        /// <returns>回傳字串yyyymmdd</returns>
        public static string DatetimeToMMDDYYYYDateTime(DateTime dt)
        {
            return string.Format("{0}{1}{2}",
                repairZero(2, dt.Month) , 
                repairZero(2, dt.Day),
                repairZero(4, dt.Year));
        }
        /// <summary>
        /// 將時間轉換成字串
        /// </summary>
        /// <param name="dt">日期時間</param>
        /// <returns>回傳字串yymmdd</returns>
        public static string DatetimeToSimpleShortYearDateTime(DateTime dt)
        {
            return string.Format("{0}{1}{2}", 
                repairZero(4, dt.Year).Substring(2,2) ,
                repairZero(2, dt.Month) ,
                repairZero(2, dt.Day));
        }

        /// <summary>
        /// 將時間轉換成字串
        /// </summary>
        /// <param name="date">日期時間</param>
        /// <returns>回傳字串HH:MM:SS</returns>
        public static string DatetimeToShortTime(DateTime dt)
        {
            return string.Format("{0}:{1}:{2}", 
                repairZero(2, dt.Hour) , 
                repairZero(2, dt.Minute), 
                repairZero(2, dt.Second));
        }

        /// <summary>
        /// 將時間轉換成字串
        /// </summary>
        /// <param name="dt">時間</param>
        /// <returns>回傳字串yyyy/mm/dd HH:MM:SS</returns>
        public static string DatetimeToShortDateTime(DateTime dt)
        {
            return string.Format("{0}/{1}/{2} {3}:{4}:{5}", 
                repairZero(4, dt.Year) ,
                repairZero(2, dt.Month) ,
                repairZero(2, dt.Day),
                repairZero(2, dt.Hour) , 
                repairZero(2, dt.Minute), 
                repairZero(2, dt.Second));
        }

        /// <summary>
        /// 將時間轉換成字串
        /// </summary>
        /// <param name="dt">時間</param>
        /// <returns>回傳字串yyyy/mm/dd HH:MM:SS.fff</returns>
        public static string DatetimeToDateTimeWithMillisecond(DateTime dt)
        {
            return string.Format("{0}{1}{2}{3}{4}{5}{6}",
                repairZero(4, dt.Year),
                repairZero(2, dt.Month),
                repairZero(2, dt.Day),
                repairZero(2, dt.Hour),
                repairZero(2, dt.Minute),
                repairZero(2, dt.Second),
                repairZero(3, dt.Millisecond));
        }
        #endregion

        #region Text
        /// <summary>
        /// 去除電話號碼特殊符號
        /// </summary>
        /// <param name="aTel">原始電話號碼</param>
        /// <returns></returns>
        public static string formatTel(string aTel)
        {
            string trimString = aTel.Trim();
            trimString = trimString.Replace("(", "");
            trimString = trimString.Replace(")", "");
            trimString = trimString.Replace("-", "");
            trimString = trimString.Replace("*", "");
            trimString = trimString.Replace(" ", "");
            trimString = trimString.Replace("ext", "");
            
            return trimString;
        }

        /// <summary>
        /// 格式化磁碟大小
        /// </summary>
        /// <param name="bytes">原始bytes</param>
        /// <returns></returns>
        public static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        /// <summary>
        /// 數字格式-千分位
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public static string formatMoney(double money)
        {
            return money.ToString("#,#", CultureInfo.InvariantCulture);
        }
        public static string formatMoney(decimal money)
        {
            return money.ToString("#,#", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 判斷是否是double byte字原
        /// </summary>
        /// <param name="aStr">原始字串</param>
        /// <returns></returns>
        public static bool isDoubleByte(string aStr)
        {
            /*
            Encoding ecode = Encoding.GetEncoding("UTF-8");
            int byteCount = ecode.GetByteCount(aStr);
            if (byteCount==2)
                return true;
            else
                return false;
            */
            char s = char.Parse(aStr);
            int ascii = (int)s;
            if (ascii>=256)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 計算文字長度
        /// </summary>
        /// <param name="aStr">原始字串</param>
        /// <returns></returns>
        public static int getTextLength(string aStr)
        {
            int nLength = 0;
            for (int i = 0; i < aStr.Length; i++)
            {
                if (isDoubleByte(aStr[i].ToString()))
                    nLength += 2;
                else
                    nLength++;
            }
            return nLength;
        }

        public static int getStrLenByByte(string aStr, int iByte)
        {
            int nLength = 0;
            for (int i = 0; i < aStr.Length; i++)
            {
                if (isDoubleByte(aStr[i].ToString()))
                    nLength += 2;
                else
                    nLength++;
                if (nLength > iByte) return i;
            }
            return aStr.Length;
        }

        /// <summary>
        /// 文字左靠右補空白(1 byte)
        /// </summary>
        /// <param name="aString">原始字串</param>
        /// <param name="aStringLength">補滿字元</param>	
        /// <param name="aStringLength">長度</param>		
        /// <returns></returns>
        public static string repairChar(string aString, string sTemp, int aLength)
        {
            string trimString = "";
            if (aString != null) trimString = aString.Trim();
            if (getTextLength(trimString) >= aLength)
                return trimString.Substring(0, getStrLenByByte(trimString, aLength));

            string sSpaces = "";
            for (int i=0; i < (aLength - getTextLength(trimString)); i++)
                sSpaces += sTemp;
            return trimString + sSpaces;
        }

        /// <summary>
        /// 文字左靠右補空白(1 byte)
        /// </summary>
        /// <param name="aString">原始字串</param>
        /// <param name="aStringLength">長度</param>		
        /// <returns></returns>
        public static string repairSpace(string aString, int aLength)
        {
            string trimString = "";
            if (aString != null)	trimString = aString.Trim();
            if (getTextLength(trimString) >= aLength)
                return trimString.Substring(0, getStrLenByByte(trimString, aLength));

            string sSpaces = "";
            for (int i=0; i < (aLength - getTextLength(trimString)); i++)
                sSpaces += " ";			
            return trimString + sSpaces;
        }

        /// <summary>
        /// 文字左靠右補空白(2 byte)
        /// </summary>
        /// <param name="aString">原始字串</param>
        /// <param name="aStringLength">長度</param>		
        /// <returns></returns>
        public static string repairHoloSpace(string aString, int aLength)
        {
            //先將字串裡的英文全部轉換成全形
            //char[] English = new char[]{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','/','(',')','1','2','3','4','5','6','7','8','9','0','.','[',']','{','}',',','-'};
            //char[] HoloEnglish = new char[] { 'Ａ', 'Ｂ', 'Ｃ', 'Ｄ', 'Ｅ', 'Ｆ', 'Ｇ', 'Ｈ', 'Ｉ', 'Ｊ', 'Ｋ', 'Ｌ', 'Ｍ', 'Ｎ', 'Ｏ', 'Ｐ', 'Ｑ', 'Ｒ', 'Ｓ', 'Ｔ', 'Ｕ', 'Ｖ', 'Ｗ', 'Ｘ', 'Ｙ', 'Ｚ', 'ａ', 'ｂ', 'ｃ', 'ｄ', 'ｅ', 'ｆ', 'ｇ', 'ｈ', 'ｉ', 'ｊ', 'ｋ', 'ｌ', 'ｍ', 'ｎ', 'ｏ', 'ｐ', 'ｑ', 'ｒ', 'ｓ', 'ｔ', 'ｕ', 'ｖ', 'ｗ', 'ｘ', 'ｙ', 'ｚ', '／', '（', '）', '１', '２', '３', '４', '５', '６', '７', '８', '９', '０', '．', '〔', '〕', '｛', '｝', '，', '－' };
            //for (int i = 0; i < English.Length; i++)
            //{
            //	if(aString.IndexOf(English[i]) != -1)
            //	{
            //		aString = aString.Replace(English[i], HoloEnglish[i]);
            //	}
            //}
            aString = aString.Replace("\r\n", " ");
            aString = Strings.StrConv(aString, VbStrConv.Wide, 1028);

            string trimString = "";
            string returnString = "";
            int iLen = 0;
            if (aString != null)
                trimString = aString.Trim();
            if (getTextLength(trimString) >= aLength)
            {
                for (int i=0; i < trimString.Length; i++)
                {
                    if (isDoubleByte(trimString[i].ToString()))
                        iLen += 2;
                    else iLen ++;
                    if (iLen > aLength)
                    {
                        if (getTextLength(returnString)<aLength)
                            returnString += " ";
                        break;
                    }
                    returnString += trimString[i];
                }
                return returnString;
            }

            string sSpaces = "";
            int iCount = aLength - getTextLength(trimString);
            if (iCount % 2 == 1)
            {
                iCount--;
                sSpaces = " ";
            }
            for (int i=0; i < iCount; i += 2)
                sSpaces += "　";
            return trimString + sSpaces;
        }
        /// <summary>
        /// 把全形數字轉為半形
        /// </summary>
        /// <param name="aString">原始字串</param>
        /// <param name="aStringLength">長度</param>		
        /// <returns></returns>
        public static string repairHoloNumber(string aString)
        {
            //char[] English = new char[]{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','/','(',')','1','2','3','4','5','6','7','8','9','0','.','[',']','{','}',',','-'};
            //char[] HoloEnglish = new char[] { 'Ａ', 'Ｂ', 'Ｃ', 'Ｄ', 'Ｅ', 'Ｆ', 'Ｇ', 'Ｈ', 'Ｉ', 'Ｊ', 'Ｋ', 'Ｌ', 'Ｍ', 'Ｎ', 'Ｏ', 'Ｐ', 'Ｑ', 'Ｒ', 'Ｓ', 'Ｔ', 'Ｕ', 'Ｖ', 'Ｗ', 'Ｘ', 'Ｙ', 'Ｚ', 'ａ', 'ｂ', 'ｃ', 'ｄ', 'ｅ', 'ｆ', 'ｇ', 'ｈ', 'ｉ', 'ｊ', 'ｋ', 'ｌ', 'ｍ', 'ｎ', 'ｏ', 'ｐ', 'ｑ', 'ｒ', 'ｓ', 'ｔ', 'ｕ', 'ｖ', 'ｗ', 'ｘ', 'ｙ', 'ｚ', '／', '（', '）', '１', '２', '３', '４', '５', '６', '７', '８', '９', '０', '．', '〔', '〕', '｛', '｝', '，', '－' };
            //for (int i = 0; i < HoloEnglish.Length; i++)
            //{
            //	if(aString.IndexOf(HoloEnglish[i]) != -1)
            //	{
            //		aString = aString.Replace(HoloEnglish[i], English[i]);
            //	}
            //}

            return Strings.StrConv(aString, VbStrConv.Narrow, 1028);
        }
        public static string turnHalf(string aString)
        {
            char[] English = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '/', '(', ')', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', '[', ']', '{', '}', ',', '-', '@' };
            char[] HoloEnglish = new char[] { 'Ａ', 'Ｂ', 'Ｃ', 'Ｄ', 'Ｅ', 'Ｆ', 'Ｇ', 'Ｈ', 'Ｉ', 'Ｊ', 'Ｋ', 'Ｌ', 'Ｍ', 'Ｎ', 'Ｏ', 'Ｐ', 'Ｑ', 'Ｒ', 'Ｓ', 'Ｔ', 'Ｕ', 'Ｖ', 'Ｗ', 'Ｘ', 'Ｙ', 'Ｚ', 'ａ', 'ｂ', 'ｃ', 'ｄ', 'ｅ', 'ｆ', 'ｇ', 'ｈ', 'ｉ', 'ｊ', 'ｋ', 'ｌ', 'ｍ', 'ｎ', 'ｏ', 'ｐ', 'ｑ', 'ｒ', 'ｓ', 'ｔ', 'ｕ', 'ｖ', 'ｗ', 'ｘ', 'ｙ', 'ｚ', '／', '（', '）', '１', '２', '３', '４', '５', '６', '７', '８', '９', '０', '．', '〔', '〕', '｛', '｝', '，', '－', '＠' };
            for (int i = 0; i < HoloEnglish.Length; i++)
            {
                if (aString.IndexOf(HoloEnglish[i]) != -1)
                {
                    aString = aString.Replace(HoloEnglish[i], English[i]);
                }
            }

            return aString;
        }

        public static string toWideChar(string aString)
        {
            string returnStr = string.Empty;
            string[] strList;
            if (aString.IndexOf("\r\n") > -1)
            {
                strList = Regex.Split(aString, @"\r\n");
                for (int i = 0; i < strList.Length; i++)
                {
                    if (string.IsNullOrEmpty(returnStr))
                        returnStr = Strings.StrConv(strList[i], VbStrConv.Wide, 1028);
                    else returnStr += @"<br/>" + Strings.StrConv(strList[i], VbStrConv.Wide, 1028);
                }
            }
            else returnStr = Strings.StrConv(aString, VbStrConv.Wide, 1028);

            return returnStr;
        }

        public static string toWideCharBySign(string aString)
        {
            char[] sign = new char[] { '/', '\\', '(', ')', '.', '[', ']', '{', '}', '<', '>', '*', '?', '&', '%', '$', '#', '@', '!', ',', ';', ':', '-', '\'', '\"' };
            for (int i = 0; i < sign.Length; i++)
            {
                if (aString.IndexOf(sign[i]) != -1)
                {
                    aString = aString.Replace(sign[i].ToString(), Strings.StrConv(sign[i].ToString(), VbStrConv.Wide, 1028));
                }
            }
            return aString;
        }
        /// <summary>
        /// 切地址字串
        /// </summary>
        /// <param name="aString">原始地址</param>
        /// <param name="aAdd1">地址1</param>
        /// <param name="aAdd1">地址2</param>
        /// <param name="aAdd1">地址3</param>		
        /// <returns></returns>
        public static void splitAddress(string aAddress, out string aAdd1, out string aAdd2, out string aAdd3)
        {
            aAdd1 = "";
            aAdd2 = "";
            aAdd3 = "";
            int j = 0;
            for (int i=0; i < aAddress.Length; i++)
            {				
                if (isDoubleByte(aAddress[i].ToString()))
                    j+=2;
                else	j++;
                if (j>64)
                    aAdd3 += aAddress[i];
                else if (j>32)
                        aAdd2 += aAddress[i];
                    else	aAdd1 += aAddress[i];
            }
        }

        /// <summary>
        /// 切地址字串2
        /// </summary>
        /// <param name="aString">原始地址</param>
        /// <param name="alArea">鄉、鎮、市、區</param>		
        /// <param name="alArea">縣、市</param>		
        /// <param name="aAdd1">地址1</param>
        /// <param name="aAdd1">地址2</param>
        /// <param name="aAdd1">地址3</param>		
        /// <returns></returns>
        public static void splitAddress2(string aAddress, ArrayList alArea, ArrayList alCity, out string aAdd1, out string aAdd2, out string aAdd3)
        {
            string tmpAddress = aAddress;
            aAdd1 = "";
            aAdd2 = "";
            aAdd3 = "";	
            bool bFindArea = false;
            for (int i=0; i<alArea.Count; i++)
            {
                if(tmpAddress.IndexOf(alArea[i].ToString())>-1)
                {
                    string[] slAddress1 = Regex.Split(tmpAddress, alArea[i].ToString());
                    aAdd1 = slAddress1[0] + alArea[i].ToString();
                    tmpAddress = slAddress1[1];
                    bFindArea = true;
                    break;
                }
            }
            if (!bFindArea)
            {
                for (int i=0; i<alCity.Count; i++)
                {
                    if(tmpAddress.IndexOf(alCity[i].ToString())>-1)
                    {
                        string[] slAddress1 = Regex.Split(tmpAddress, alCity[i].ToString());
                        aAdd1 = alCity[i].ToString();
                        tmpAddress = slAddress1[1];
                        break;
                    }
                }
            }

            if(tmpAddress.IndexOf("段")>-1)
            {
                string[] slAddress2 = Regex.Split(tmpAddress, "段");
                aAdd2 = slAddress2[0] + "段";
                aAdd3 = slAddress2[1];
            }
            else if(tmpAddress.IndexOf("街")>-1)
            {
                string[] slAddress2 = Regex.Split(tmpAddress, "街");
                aAdd2 = slAddress2[0] + "街";
                aAdd3 = slAddress2[1];
            }
            else if(tmpAddress.IndexOf("路")>-1)
            {
                string[] slAddress2 = Regex.Split(tmpAddress, "路");
                aAdd2 = slAddress2[0] + "路";
                aAdd3 = slAddress2[1];
            }
            else 
            {
                aAdd2 = "";
                aAdd3 = tmpAddress;
            }
        }

        /// <summary>
        /// 不滿N位數的前面補０
        /// </summary>
        /// <param name="Num">數值</param>
        /// <returns></returns>
        public static string repairZero(int Bits, int Num)
        {
            string sNum = Convert.ToString(Num);
            string sZero = "";
            for (int i=0; i<(Bits - sNum.Length); i++)
                sZero += "0";
            return sZero + sNum;
        }

        /// <summary>
        /// 有含前置字串
        /// </summary>
        /// <param name="PrevFix"></param>
        /// <param name="Bits"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
        public static string repairZero(string PrevFix, int Bits, int Num)
        {
            return PrevFix + repairZero(Bits, Num);
        }
        /// <summary>
        /// 產生序號
        /// </summary>
        /// <returns>回傳Guid後10碼</returns>
        public static string GenerateSerialNum()
        {
            return Guid.NewGuid().ToString().Substring(25, 10);
        }

        /// <summary>
        /// 產生序號(20 Bytes)
        /// </summary>
        /// <returns>回傳Guid前8後12碼</returns>
        public static string GenerateSerialNum20()
        {
            string[] guid = Guid.NewGuid().ToString().Split('-');
            return guid[0] + guid[4];
        }
        #endregion

        #region Others
        /// <summary>
        /// IP Address檢查
        /// </summary>
        /// <param name="ip">IP Address</param>
        /// <returns>是否正確</returns>
        public static bool IsIPAddress(string ip)
        {
            return Regex.IsMatch(ip, @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 地址格式檢查檢查
        /// </summary>
        /// <remarks>
        /// 1.地址中，若有出現「段、路、街」，其前一個字元必需為國字型態，或數值｢一～九｣國字型態字元
        /// 2.「巷」前的數字須以阿拉伯數字輸入
        /// 3.「鄰、弄、號、樓」前的數字須以阿拉伯數字輸入
        /// 4.地址中「x之y號」的之需輸入「—」，如５－３號
        /// 5.地址中「x號之y」的之需輸入國字「之」，如５號之３
        /// 6.地址中的樓需輸入國字不可為「F」，如５號４樓
        /// 7.地址中，若有出現「里」，其前一個字元必需為國字型態
        /// 48~57 = Halfwidth Number
        /// 65296~65305 = Fullwidth Number
        /// </remarks>
        /// <param name="address">IP Address</param>
        /// <returns>是否正確</returns>
        public static bool VerifyAddressFormat(string address, out string errorMessage)
        {
            errorMessage = string.Empty;

            char[] FullwidthNumber = new char[] { '０', '１', '２', '３', '４', '５', '６', '７', '８', '９' };
            char[] ChineseNumber = new char[] { '十', '一', '二', '三', '四', '五', '六', '七', '八', '九' };
            char[] addressChar = address.ToCharArray();
            foreach (char element in addressChar)
            {
                if ((int)element <= 127)
                {
                    errorMessage = "地址中輸入內容必須是全形字體!";
                    return false;
                }
            }

            Array.Reverse(addressChar);
            bool needCheckNumber = false;
            #region 1.地址中，若有出現「段、路、街」，其前一個字元必需為國字型態，或數值｢一～九｣國字型態字元
            foreach (char element in addressChar)
            {
                if (!needCheckNumber && (element == '段' || element == '路' || element == '街'))
                {
                    needCheckNumber = true;
                    continue;
                }
                if (needCheckNumber && Array.IndexOf(FullwidthNumber, element) > -1)
                {
                    errorMessage = "「段、路、街」前的數字須是國字型態";
                    return false;
                }
                else needCheckNumber = false;
            }
            #endregion
            #region 2,3 「巷、鄰、弄、號、樓」前的數字須以阿拉伯數字輸入
            foreach (char element in addressChar)
            {
                if(!needCheckNumber && (element == '巷' || element == '鄰' || element == '弄' || element == '號' || element == '樓'))
                {
                    needCheckNumber = true;
                    continue;
                }
                if(needCheckNumber && Array.IndexOf(ChineseNumber, element) > -1)
                {
                    errorMessage = "「巷、鄰、弄、號、樓」前的數字須以阿拉伯數字輸入";
                    return false;
                }
                else needCheckNumber = false;
            }
            #endregion
            #region 4.地址中「x之y號」的之需輸入「—」，如５－３號
            bool needCheckNoPre = false;
            foreach (char element in addressChar)
            {
                if (!needCheckNumber && element == '號')
                {
                    needCheckNumber = true;
                    continue;
                }
                if (needCheckNumber && Array.IndexOf(FullwidthNumber, element) > -1)
                {
                    needCheckNumber = true;
                    needCheckNoPre = true;
                    continue;
                }
                else if (needCheckNumber && needCheckNoPre && element == '之')
                {
                    errorMessage = "地址中「x之y號」的之需輸入「－」，如５－３號";
                    return false;
                }
                else needCheckNumber = false;
            }
            #endregion
            #region 5.地址中「x號之y」的之需輸入國字「之」，如５號之３
            foreach (char element in addressChar)
            {
                if (!needCheckNumber && element == '－')
                {
                    needCheckNumber = true;
                    continue;
                }
                if (needCheckNumber && element == '號')
                {
                    errorMessage = "地址中「x號之y」的之需輸入國字「之」，如５號之３";
                    return false;
                }
                else needCheckNumber = false;
            }
            #endregion
            #region 6.地址中的樓需輸入國字不可為「F」，如５號４樓
            foreach (char element in addressChar)
            {
                if (!needCheckNumber && element == 'Ｆ')
                {
                    needCheckNumber = true;
                    continue;
                }
                if (needCheckNumber && (Array.IndexOf(FullwidthNumber, element) > -1 || Array.IndexOf(ChineseNumber, element) > -1))
                {
                    errorMessage = "地址中的樓需輸入國字不可為「F」，如５號４樓";
                    return false;
                }
                else needCheckNumber = false;
            }
            #endregion
            #region 7.地址中，若有出現「里」，其前一個字元必需為國字型態
            foreach (char element in addressChar)
            {
                if (!needCheckNumber && element == '里')
                {
                    needCheckNumber = true;
                    continue;
                }
                if (needCheckNumber && (Array.IndexOf(FullwidthNumber, element) > -1))
                {
                    errorMessage = "地址中，若有出現「里」，其前一個字元必需為國字型態";
                    return false;
                }
                else needCheckNumber = false;
            }
            #endregion

            return true;
        }
        /// <summary>
        /// 身分證字號檢查
        /// </summary>
        /// <param name="id">身分證ID Number</param>
        /// <returns>是否正確</returns>
        public static bool VerifyIdentityNumber(string id)
        {
            try
            {
                // 長度要等於１０
                if (id.Length != 10)
                    return false;
                char first = Convert.ToChar(id.ToUpper().Substring(0,1));
                // 第一個字元要在A ~ Z之間
                if (first < 'A' || first > 'Z')
                    return false;
                char second = Convert.ToChar(id.Substring(1,1));
                // 第二個字元必須為１或２
                if (second < '1' || second > '2')
                    return false;
            
                int[] multiplier = new int[10] {1, 9 ,8, 7, 6, 5, 4, 3, 2, 1};
                int[] member = new int[11] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                member[0] = convertFirstID(first) / 10;
                member[1] = convertFirstID(first) % 10;
                for(int i = 2; i < 11;i++)
                    member[i] = Convert.ToInt16(id.Substring(i-1,1));

                int sum = 0;
                for(int i=0;i<10;i++)
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
            int result =0;
            switch (first)
            {
                case 'A' :
                    result = 10;
                    break;
                case 'B' :
                    result = 11;
                    break;
                case 'C' :
                    result = 12;
                    break;
                case 'D' :
                    result = 13;
                    break;
                case 'E' :
                    result = 14;
                    break;
                case 'F' :
                    result = 15;
                    break;
                case 'G' :
                    result = 16;
                    break;
                case 'H' :
                    result = 17;
                    break;
                case 'I' :
                    result = 34;
                    break;
                case 'J' :
                    result = 18;
                    break;
                case 'K' :
                    result = 19;
                    break;
                case 'L' :
                    result = 20;
                    break;
                case 'M' :
                    result = 21;
                    break;
                case 'N' :
                    result = 22;
                    break;
                case 'O' :
                    result = 35;
                    break;
                case 'P' :
                    result = 23;
                    break;
                case 'Q' :
                    result = 24;
                    break;
                case 'R' :
                    result = 25;
                    break;
                case 'S' :
                    result = 26;
                    break;
                case 'T' :
                    result = 27;
                    break;
                case 'U' :
                    result = 28;
                    break;
                case 'V' :
                    result = 29;
                    break;
                case 'W' :
                    result = 32;
                    break;
                case 'X' :
                    result = 30;
                    break;
                case 'Y' :
                    result = 31;
                    break;
                case 'Z' :
                    result = 33;
                    break;
            }
            return result;
        }

        /// <summary>
        /// 取整數
        /// </summary>
        /// <param name="AValue">浮點數</param>
        /// <returns>整數</returns>
        public static int Int(double AValue)
        {
            string sValue = AValue.ToString();
            if (sValue.IndexOf(".") > -1)
                sValue = sValue.Substring(0, sValue.IndexOf("."));
            
            return int.Parse(sValue);
        }

        /// <summary>
        /// 四捨五入
        /// </summary>
        /// <param name="AValue">浮點數</param>
        /// <param name="ANum">取到小數第幾位</param>
        /// <returns>整數</returns>
        public static double Round(double AValue, int ANum)
        {
            double dValue = AValue;
            int iNumValue = 1;
            for (int i=0; i<ANum; i++)
                iNumValue = iNumValue * 10;

            return double.Parse((Utils.Int((AValue * iNumValue)+0.5)).ToString()+".0") / iNumValue;
        }		

        /// <summary>
        /// 包含中文字和字串長度,將中文字識為2個字元
        /// </summary>
        /// <param name="strSource">要計算長度的中文字</param>
        /// <returns>長度</returns>
        public static int GetLength(string strSource)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            int nLength = strSource.Length;

            for(int i=0; i<strSource.Length; i++)
            {
                if (regex.IsMatch(strSource.Substring(i,1))) 
                {
                    nLength++;
                }
            }

            return nLength;
        }

        /// <summary>
        /// 將字串轉換成Color Object
        /// </summary>
        /// <param name="strColor">#??????</param>
        /// <returns>回傳Color Object</returns>
        public static Color ConvertFromString(string strColor)
        {
            ColorConverter wcc = new ColorConverter();
            return (Color)wcc.ConvertFromString(strColor);
        }

        /// <summary>
        /// 將日期轉換成民國日期格式
        /// </summary>
        /// <param name="dt">日期</param>
        /// <param name="Separate">分隔字串</param>
        /// <returns>回傳日期字串</returns>
        public static string ConvertDatetoChineseFormatAll(DateTime dt,string Separate)
        {
            return string.Format("{0}{3}{1}{3}{2}", ConvertDatetoChineseFormatYear(dt), repairZero(2, dt.Month), repairZero(2, dt.Day), Separate);
        }

        /// <summary>
        /// 將日期轉換成民國年日期格式
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns>回傳民國年字串</returns>
        public static string ConvertDatetoChineseFormatYear(DateTime dt)
        {
            return Convert.ToString(dt.Year - 1911);
        }
        //將日期轉成民國年月日
        public static string ConvertDateToChineseDate(DateTime dt)
        {
            string year = Convert.ToString(dt.Year - 1911);
            string month = repairZero(2, dt.Month);
            string day = repairZero(2, dt.Day);
            
            return year+month+day;
        }

        public static string ConvertDatetoChineseFormatYear(DateTime dt, int bit)
        {
            return repairZero(bit, dt.Year - 1911);
        }

        /// <summary>
        /// 計算年金終值
        /// </summary>
        /// <param name="period">期數(月)</param>
        /// <param name="rate">期數(月)之利率</param>
        /// <returns></returns>
        //***************************************************************
        //				 ( 1 + 利率 ) ^ 期數 - 1
        //	年金終值 = ----------------------------
        //						  i 
        //***************************************************************
        public static double EndValueOfTheAnnuity(int period , double rate)
        {
            try
            {
                return (Math.Pow(1 + rate / 12 / 100 , Convert.ToDouble(period)) - 1 ) / (rate / 12 / 100);
            }
            catch {return 0;}
        }

        /// <summary>
        /// 計算月付款
        /// </summary>
        /// <param name="total">貸款總金額</param>
        /// <param name="period">期數(月)</param>
        /// <param name="rate">期數(月)之利率</param>
        /// <returns>月付款金額</returns>
        public static double GetPayByMonth(double total,double period, double rate)
        {
            try
            {
                return  Math.Floor((Math.Round(- Financial.Pmt(rate / 12 / 100 , period ,total , 0 , DueDate.EndOfPeriod) , 0) +9 ) / 10 ) * 10;
            }
            catch 
            {return 0;}
        }

        /// <summary>
        /// 計算年百分率
        /// </summary>
        /// <param name="total">貸款總金額</param>
        /// <param name="fee">總費用</param>
        /// <param name="period">期數(月)</param>
        /// <param name="rate">年利率</param>
        /// <returns>年百分率</returns>
        public static double GetAnnualPercentage(double total, double fee, double period, double rate)
        {
            try
            {
                double pmt = Financial.Pmt(rate , period , total + fee, 0, DueDate.EndOfPeriod);
                return Financial.Rate(period , pmt , total , 0 , DueDate.EndOfPeriod, 0) * 12 * 100;
            }
            catch {return 0;}
        }

        /// <summary>
        /// 計算年利率
        /// </summary>
        /// <param name="total">貸款總金額</param>
        /// <param name="period">期數(月)</param>
        /// <param name="month">月付款</param>
        /// <returns>年利率</returns>
        public static double GetRatePerAnnum(double total, double period , double monthpay)
        {
            try
            {
                return Financial.Rate(period , -monthpay ,total , 0 , DueDate.EndOfPeriod , 0) * 12 * 100;
            }
            catch {return 0;}
        }

        /// <summary>
        /// 計算期數
        /// </summary>
        /// <param name="rate">年利率</param>
        /// <param name="monthpay">月付款</param>
        /// <param name="total">貸款金額</param>
        /// <returns>期數(月)</returns>
        public static double GetMonthPeriod(double rate , double monthpay , double total)
        {
            try
            {
                return Financial.NPer(rate / 12 / 100 , -monthpay ,total , 0 , DueDate.EndOfPeriod);
            }
            catch {return 0;}
        }

        /// <summary>
        /// 計算貸款金額
        /// </summary>
        /// <param name="rate">年利率</param>
        /// <param name="period">期數(月)</param>
        /// <param name="monthpay">月付款</param>
        /// <returns>貸款金額</returns>
        public static double GetAnnuityCurrentValue(double rate , double period , double monthpay)
        {
            try
            {
                return Financial.PV(rate / 12 / 100 , period ,-monthpay , 0 , DueDate.EndOfPeriod);
            }
            catch {return 0;}
        }

        /// <summary>
        /// 比較兩個日期的時間(用於計算年齡)
        /// </summary>
        /// <param name="first"></param>
        /// <param name="secord"></param>
        /// <returns>回傳相差年數</returns>
        public static double GetCompareToYear(DateTime first , DateTime secord)
        {
            int yearofmonth = ((first.Year - secord.Year) * 12) + first.Month - secord.Month;
            return (yearofmonth < 0 ? 0 : Round((yearofmonth / 12) , 1));
        }

        /// <summary>
        /// 比較兩個日期的時間(用於計算天數)
        /// </summary>
        /// <param name="first"></param>
        /// <param name="secord"></param>
        /// <returns>回傳相差天數</returns>
        public static double GetCompareToDay(DateTime first , DateTime secord)
        {
            return Math.Round((first.Ticks - secord.Ticks) / 864000000000.0 , 2);
        }

        /// <summary>
        /// 取得日期的DateCode 
        /// 年度 + 當年度第幾週
        /// ex, 200903
        /// </summary>
        /// <param name="dNow"></param>
        /// <returns></returns>
        public static string GetDateCode(DateTime dNow)
        {
            CultureInfo myCI = new CultureInfo("zh-TW");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = DayOfWeek.Monday;
            int wd = myCal.GetWeekOfYear(dNow, myCWR, myFirstDOW);

            return Utils.DatetimeToShortDate(dNow).Substring(0,4) + Utils.repairZero(2 , wd);
        }

        /// <summary>
        /// 取得日期的週區間 , 一週起迄為星期一至星期日
        /// ex, 1/5 ~ 1/11
        /// </summary>
        /// <param name="dNow"></param> 
        /// <returns></returns>
        public static string GetWeekBetween(DateTime dNow)
        {
            int iDiff = Convert.ToInt16(dNow.DayOfWeek) == 0 ? -6 : 1 - Convert.ToInt16(dNow.DayOfWeek);
            DateTime sDate = dNow.AddDays(iDiff);   // 開始日期
            DateTime eDate = sDate.AddDays(6);       // 結束日期

            if (sDate.Year != dNow.Year)
                sDate = Convert.ToDateTime(dNow.Year.ToString() +"/1/1");
            if (eDate.Year != dNow.Year)
                eDate = Convert.ToDateTime(dNow.Year.ToString() + "/12/31");

            return string.Format("{0}/{1} ~ {2}/{3}", sDate.Month, sDate.Day, eDate.Month, eDate.Day);
        }

        public static string DeleteNumber(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            return Regex.Replace(str, "[0-9]", ""); ;
        }

        public static bool IsNatural_Number(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9]+$");
            return reg.IsMatch(str);
        }

        public static bool IsChinese(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            return reg.IsMatch(str);
        }

        public static string CallOutPhoneNo(string phone)
        {
            string vclogPhone = phone.Replace(" ", "").Replace("(", "").Replace(")", "");
            if (vclogPhone.IndexOf("-") > -1)
                vclogPhone = vclogPhone.Substring(0, vclogPhone.IndexOf("-"));
            if (vclogPhone.IndexOf("#") > -1)
                vclogPhone = vclogPhone.Substring(0, vclogPhone.IndexOf("#"));
            return vclogPhone;
        }

        public static string Right(string inputStr, int len)
        {
            string result = inputStr.Trim();
            if (result.Length < len)
                return result;
            else return result.Substring(result.Length - len);
        }

        /// <summary>
        /// 檢查檔名是否符合可替代文字格式
        /// </summary>
        /// <param name="fileName">檔案名稱</param>
        /// <param name="importFileName">可替代文字檔名</param>
        /// <param name="mark">可替代文字字元</param>
        /// <returns></returns>
        public static bool IsNLIPFileNameCoincide(string fileName, string importFileName, string mark)
        {
            //去掉副檔名
            fileName = System.IO.Path.GetFileNameWithoutExtension(fileName);
            bool result = true;
            for (int index = 0; index < importFileName.Length; index++)
            {
                if (importFileName.Substring(index, 1).Equals(mark))
                {
                    if (!Utils.IsNatural_Number(fileName.Substring(index, 1)) &&
                        !Utils.IsChinese(fileName.Substring(index, 1)))
                    {
                        result = false;
                        break;
                    }
                }
                else
                {
                    if (!importFileName.Substring(index, 1).Equals(fileName.Substring(index, 1)))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 取得可替代文字部分的字串，用來檢查檔名和匯入的檔名是否完全一致
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="importFileName"></param>
        /// <param name="mark"></param>
        /// <returns></returns>
        public static string GetCharsOfMark(string fileName, string importFileName, string mark)
        {
            string result = string.Empty;

            if (Utils.IsNLIPFileNameCoincide(fileName, importFileName, mark))
                for (int index = 0; index < importFileName.Length; index++)
                    if (importFileName.Substring(index, 1).Equals(mark))
                        result += fileName.Substring(index, 1);

            return result;
        }
        #endregion
    }
}
