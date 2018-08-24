using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Web;

using EASONTECH.Inbound.Entity;
using EASONTECH.Framework2.Data.FieldType;
using EASONTECH.Framework2.Data;

namespace EASONTECH.Inbound.Classes
{
    public class SMSObj
    {
        private IDataProvider _conn = null;
        public string MoblieType = "SMSCHTMoblie";
        public string HttpAddr = "http://imsp.emome.net:8008/imsp/sms/servlet/";
        public string UserName = "14525";
        public string Password = "14525";
        public string Rateplan = "";
        public string SrcAddr = "";

        public SMSObj(IDataProvider conn)
        {
            _conn = conn;
        }

        private bool IsLongSMS(string content)
        {
            return content.Length >= 70;
        }

        private string GetLongSMSBody(string content)
        {
            string header = "%05%00%03%C7%{0}%{1}";
            string ret = "";
            int smsCount = (int)Math.Floor(content.Length / 67.0) + 1;
            for (int i = 1; i < smsCount; i++)
            {
                ret += string.Format(header, smsCount.ToString("00"), i.ToString("00")) + content.Substring(0, 67);
                content = content.Substring(67);
            }
            return ret + string.Format(header, smsCount.ToString("00"), smsCount.ToString("00")) + content;
        }

        private void ErrorWriteSMSLog(string serno, string content, string status)
        {
            _conn.startTransaction();
            try
            {
                SMS entityS = new SMS(_conn);
                entityS.SMS_STATUS = status;
                entityS.SMS_DTTM = DateTime.Now;
                entityS.update(entityS.SMS_SERNO.cds_Equal(serno));

                SMSLog entitySL = new SMSLog(_conn);
                entitySL.SMS_SERNO = serno;
                entitySL.SLG_SERNO = EASONTECH.Framework2.Common.Utility.generateSerialNum();
                entitySL.SLG_CONTENT = content;
                entitySL.SLG_DTTM = DateTime.Now;
                entitySL.SLG_STATUS = "SysError";
                entitySL.SLG_MESSAGE = content;
                entitySL.insert();

                _conn.commitTransaction();

            }
            catch
            {
                _conn.rollbackTransaction();
            }
        }

        private string GetCHTRtnMessage(string content)
        {
            content = content.Replace("<html>", "").Replace("<header>", "").Replace("<header>", "").Replace("</header>", "").Replace("<body ", "").Replace("<body>", "").Replace("<br>", "").Replace("</body>", "").Replace("</html>", "");
            return content;
        }

        #region 發送
        public void Send()
        {
            SMS entSMS = new SMS(_conn);
            entSMS.query(null, entSMS.SMS_STATUS.cds_Equal(""), "");
            while (entSMS.read())
            {
                SendSMS(entSMS.SMS_SERNO, entSMS.SMS_ADDRESS, entSMS.SMS_CONTENT);
            }
        }

        private void SendSMS(string serno, string addr, string content)
        {
            try
            {                
                switch (MoblieType)
                {
                    case "SMSTaiwanMoblie":
                        SendTaiwanMoblie(serno, addr, content);
                        break;
                    case "SMSCHTMoblie":
                        SendCHTMoblie(serno, addr, content);
                        break;                        
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorWriteSMSLog(serno, ex.Message, "E");
            }
                
        }

        private void SendTaiwanMoblie(string serno, string addr, string content)
        { 
            //WebRequest request = null;
            //if (IsLongSMS(content))
            //{
            //    request = WebRequest.Create(string.Format(HttpAddr + "?username={1}&password={2}&rateplan={3}&srcaddr={4}&encoding={5}&smbody={6}"
            //            , "80"
            //            , UserName
            //            , Password
            //            , Rateplan
            //            , SrcAddr
            //            , "LBIG5"
            //            , HttpUtility.UrlEncode(GetLongSMSBody(content))
            //        ));
            //}
            //else
            //{
            //    request = WebRequest.Create(string.Format(HttpAddr + "?username={1}&password={2}&rateplan={3}&srcaddr={4}&encoding={5}&smbody={6}"
            //            , "80"
            //            , UserName
            //            , Password
            //            , Rateplan
            //            , SrcAddr
            //            , "BIG5"
            //            , HttpUtility.UrlEncode(content)
            //        ));
            //}

            //if (request == null)
            //    SendWriteSMSLog(serno, "request為空", "E");
            //else
            //{
            //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //    Stream data = response.GetResponseStream();
            //    StreamReader reader = new StreamReader(data);
            //    SendWriteSMSLog(serno, reader.ReadToEnd(), "S");

            //    reader.Close();
            //    data.Close();
            //    response.Close();
            //}
        }

        private void SendCHTMoblie(string serno, string addr, string content)
        {
            WebRequest request = null;

            if (!IsLongSMS(content))
            {
                //正式
                request = WebRequest.Create(string.Format(HttpAddr +
                                    "SubmitSM?account={0}&password={1}&from_addr_type={2}&from_addr={3}" +
                                    "&to_addr_type={4}&to_addr={5}" +
                                    "&msg_expire_time={6}&msg_type={7}&msg={8}"
                        , UserName
                        , Password
                        , "0"// 0 - 代碼為手機門號, 1- emome代碼, 2- 代表from_addr為帳號開頭的字串
                        , SrcAddr
                        , "0"// 0 - 代碼為手機門號, 1- emome代碼(系統內定為 0)
                        , addr
                        , "0"// 這通訊息的失效時間(分), 若不需要失效時間設為 0 或不填值
                        , "0"// 0 - 為一般通用簡訊, 1 - pop-up簡訊(跳出式簡訊), 2 - 應用程式(資料型態 : 文字), 3 - 應用程式(資料型態 : binary)
                        , HttpUtility.UrlEncode(Encoding.GetEncoding("big5").GetBytes(content))
                    ));

                ////測試用
                //request = WebRequest.Create(string.Format(HttpAddr +
                //                    "?account={0}&password={1}&from_addr_type={2}&from_addr={3}" +
                //                    "&to_addr_type={4}&to_addr={5}" +
                //                    "&msg_expire_time={6}&msg_type={7}&msg={8}"
                //        , UserName
                //        , Password
                //        , "0"// 0 - 代碼為手機門號, 1- emome代碼, 2- 代表from_addr為帳號開頭的字串
                //        , SrcAddr
                //        , "0"// 0 - 代碼為手機門號, 1- emome代碼(系統內定為 0)
                //        , addr
                //        , "0"// 這通訊息的失效時間(分), 若不需要失效時間設為 0 或不填值
                //        , "0"// 0 - 為一般通用簡訊, 1 - pop-up簡訊(跳出式簡訊), 2 - 應用程式(資料型態 : 文字), 3 - 應用程式(資料型態 : binary)
                //        , HttpUtility.UrlEncode(GetLongSMSBody(content))
                //    ));
            }

            if (request == null)
                ErrorWriteSMSLog(serno, "簡訊內容超過70個字", "E");
            else
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream data = response.GetResponseStream();
                StreamReader reader = new StreamReader(data);
                CHTSendWriteSMSLog(serno, reader.ReadToEnd());

                reader.Close();
                data.Close();
                response.Close();
            }

        }

        private void CHTSendWriteSMSLog(string serno, string content)
        {
            content = GetCHTRtnMessage(content);
            string[] MessageSet = content.Split('|');

            if (MessageSet.Length == 4)
            {
                _conn.startTransaction();
                try
                {
                    SMS entityS = new SMS(_conn);

                    switch (MessageSet[1])
                    {
                        case "-1":
                            entityS.SMS_STATUS = "";
                            break;
                        case "0":
                            entityS.SMS_STATUS = "S";
                            break;
                        default:
                            entityS.SMS_STATUS = "E";
                            break;
                    }
                    entityS.SMS_DTTM = DateTime.Now;
                    entityS.update(entityS.SMS_SERNO.cds_Equal(serno));

                    SMSLog entitySL = new SMSLog(_conn);
                    entitySL.SMS_SERNO = serno;
                    entitySL.SLG_SERNO = EASONTECH.Framework2.Common.Utility.generateSerialNum();
                    entitySL.SLG_CONTENT = content;
                    entitySL.SLG_DTTM = DateTime.Now;
                    entitySL.SLG_STATUS = MessageSet[1];
                    if (MessageSet[1] != "0")
                        entitySL.SLG_MESSAGE = MessageSet[3];

                    entitySL.insert();
                    _conn.commitTransaction();

                }
                catch
                {
                    _conn.rollbackTransaction();
                }
            }
        }
        #endregion

        #region 查詢
        public void Query()
        {
            try
            {
                SMSLog entityS = new SMSLog(_conn);
                StringBuilder Cndstring = new StringBuilder();

                Cndstring.Append(entityS.SLG_MESSAGE.cds_NotEqual("Successful"));
                Cndstring.Append(" and ");
                Cndstring.Append(entityS.SLG_DTTM.cds_BetweenDate(DateTime.Now.Date, DateTime.Now.Date));

                entityS.query(null, Cndstring.ToString(), "");

                while (entityS.read())
                {
                    switch (MoblieType)
                    {
                        case "SMSTaiwanMoblie":
                            //QueryTaiwanMoblie();
                            break;
                        case "SMSCHTMoblie":
                            QueryCHTMoblie(entityS.SLG_SERNO.ToString(), entityS.SLG_CONTENT.ToString());
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                string ErrMessage = ex.Message;
            }
        }

        private void QueryTaiwanMoblie()
        {
            //WebRequest request = null;
            //if (IsLongSMS(content))
            //{
            //    request = WebRequest.Create(string.Format(HttpAddr + "?username={1}&password={2}&rateplan={3}&srcaddr={4}&encoding={5}&smbody={6}"
            //            , "80"
            //            , UserName
            //            , Password
            //            , Rateplan
            //            , SrcAddr
            //            , "LBIG5"
            //            , HttpUtility.UrlEncode(GetLongSMSBody(content))
            //        ));
            //}
            //else
            //{
            //    request = WebRequest.Create(string.Format(HttpAddr + "?username={1}&password={2}&rateplan={3}&srcaddr={4}&encoding={5}&smbody={6}"
            //            , "80"
            //            , UserName
            //            , Password
            //            , Rateplan
            //            , SrcAddr
            //            , "BIG5"
            //            , HttpUtility.UrlEncode(content)
            //        ));
            //}

            //if (request == null)
            //    SendWriteSMSLog(serno, "request為空", "E");
            //else
            //{
            //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //    Stream data = response.GetResponseStream();
            //    StreamReader reader = new StreamReader(data);
            //    SendWriteSMSLog(serno, reader.ReadToEnd(), "S");

            //    reader.Close();
            //    data.Close();
            //    response.Close();
            //}
        }

        private void QueryCHTMoblie(string serno, string content)
        {
            string[] MessageSet = content.Split('|');

            if (MessageSet.Length == 4)
            {
                //正式
                WebRequest request = WebRequest.Create(string.Format(HttpAddr +
                            "QuerySM?account={0}&password={1}&to_addr_type={2}&to_addr={3}&messageid={4}"
                            , UserName
                            , Password
                            , "0"// 0 - 代碼為手機門號, 1- emome代碼(系統內定為 0)
                            , MessageSet[0].ToString().Trim()
                            , MessageSet[2].ToString().Trim()
                        ));
                
                //測試用
                //WebRequest request = WebRequest.Create(string.Format(HttpAddr +
                //            "?account={0}&password={1}&to_addr_type={2}&to_addr={3}&messageid={4}"
                //            , UserName
                //            , Password
                //            , "0"// 0 - 代碼為手機門號, 1- emome代碼(系統內定為 0)
                //            , MessageSet[0]
                //            , MessageSet[2]
                //        ));

                if (request != null)
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream data = response.GetResponseStream();
                    StreamReader reader = new StreamReader(data);
                    CHTQueryWriteSMSLog(serno, reader.ReadToEnd());

                    reader.Close();
                    data.Close();
                    response.Close();
                }
            }
        }

        private void CHTQueryWriteSMSLog(string serno, string content)
        {
            content = GetCHTRtnMessage(content);
            string[] MessageSet = content.Split('|');

            if (MessageSet.Length == 4)
            {
                SMSLog entitySL = new SMSLog(_conn);

                if (MessageSet[2] != "null")
                {
                    StringBuilder dt = new StringBuilder();
                    dt.Append(MessageSet[2].Substring(0, 4));
                    dt.Append("/");
                    dt.Append(MessageSet[2].Substring(4, 2));
                    dt.Append("/");
                    dt.Append(MessageSet[2].Substring(6, 2));
                    dt.Append(" ");
                    dt.Append(MessageSet[2].Substring(8, 2));
                    dt.Append(":");
                    dt.Append(MessageSet[2].Substring(10, 2));
                    dt.Append(":");
                    dt.Append(MessageSet[2].Substring(12, 2));
                    entitySL.SLG_DTTM = Convert.ToDateTime(dt.ToString());
                }

                entitySL.SLG_STATUS = MessageSet[1];
                entitySL.SLG_MESSAGE = MessageSet[3];
                entitySL.update(entitySL.SLG_SERNO.cds_Equal(serno));
            }
        }
        #endregion
    }
}
