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
    public class SMSTaiwanMobileObj
    {
        private IDataProvider _conn = null;

        public string HttpAddr = "";
        public string UserName = "";
        public string Password = "";
        public string Rateplan = "";
        public string SrcAddr = "";

        public void Send()
        {
            SMS entSMS = new SMS(_conn);
            entSMS.query(null, entSMS.SMS_STATUS.cds_Equal(""), "", "");
            while (entSMS.read())
            {
                SendSMS(entSMS.SMS_SERNO, entSMS.SMS_ADDRESS, entSMS.SMS_CONTENT);
            }
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

        private void SendSMS(string serno, string addr, string content)
        {
            try
            {
                if (IsLongSMS(content))
                {
                    WebRequest request = WebRequest.Create(string.Format(HttpAddr + "?username={1}&password={2}&rateplan={3}&srcaddr={4}&encoding={5}&smbody={6}"
                            , "80"
                            , UserName
                            , Password
                            , Rateplan
                            , SrcAddr
                            , "LBIG5"
                            , HttpUtility.UrlEncode(GetLongSMSBody(content))
                        ));
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream data = response.GetResponseStream();
                    StreamReader reader = new StreamReader(data);
                    WriteSMSLog(serno, reader.ReadToEnd(), "S");

                    reader.Close();
                    data.Close();
                    response.Close();
                }
                else
                {
                    WebRequest request = WebRequest.Create(string.Format(HttpAddr + "?username={1}&password={2}&rateplan={3}&srcaddr={4}&encoding={5}&smbody={6}"
                            , "80"
                            , UserName
                            , Password
                            , Rateplan
                            , SrcAddr
                            , "BIG5"
                            , HttpUtility.UrlEncode(content)
                        ));
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream data = response.GetResponseStream();
                    StreamReader reader = new StreamReader(data);
                    WriteSMSLog(serno, reader.ReadToEnd(), "S");

                    reader.Close();
                    data.Close();
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                WriteSMSLog(serno, ex.Message, "E");
            }
        }

        private void WriteSMSLog(string serno, string content, string status)
        {
            SMS entity = new SMS(_conn);
            entity.query(null, entity.SMS_SERNO.cds_Equal(serno), "", 0, 1);
            if (entity.read())
            {
                entity.SMS_STATUS = status;
                entity.SMS_DTTM = DateTime.Now;
                entity.update(entity.SMS_SERNO.cds_Equal(serno));

                WriteSMSLog(serno, content);
            }
        }

        private void WriteSMSLog(string serno, string content)
        {
            SMSLog entity = new SMSLog(_conn);
            entity.SMS_SERNO = serno;
            entity.SLG_SERNO = EASONTECH.Framework2.Common.Utility.generateSerialNum();
            entity.SLG_CONTENT = content;
            entity.SLG_DTTM = DateTime.Now;

            entity.insert();
        }

        public SMSTaiwanMobileObj(IDataProvider conn)
        {
            _conn = conn;
        }
    }
}
