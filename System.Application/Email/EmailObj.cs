using System;
using System.IO;
using System.Collections;
using System.Text;

using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using EASONTECH.Inbound.View;
using EASONTECH.Inbound.Entity;
using EASONTECH.Framework2.Data.FieldType;
using EASONTECH.Framework2.Data;

namespace EASONTECH.Inbound.Classes
{
    public class EmailObj
    {
        public static string Message1 = "無主要收件人";

        private IDataProvider _conn = null;
        private Email _entEmail = null;
        private EmailReceiver _entReceiver = null;
        private EmailFile _entFile = null;
        private Hashtable _attachmentFile = null;

        public string Host = "ms.radium.com.tw";
        public string Account = "Customer";
        public string Passwd = "1234";
        public string UserName = "Customer@radium.com.tw";
        public string UserEmail = "Customer@radium.com.tw";

        /// <summary>
        /// 發送未寄郵件
        /// </summary>
        public void Send()
        {
            _entEmail = new Email(_conn);
            _entReceiver = new EmailReceiver(_conn);
            _entFile = new EmailFile(_conn);
            _entEmail.query(null, _entEmail.EML_STATUS.cds_Equal(""), "", "");
            SmtpClient client = new SmtpClient(Host);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(Account, Passwd);

            while (_entEmail.read())
            {
                _entReceiver.query(null, _entReceiver.EML_SERNO.cds_Equal(_entEmail.EML_SERNO), "", "");
                _entFile.query(null, _entFile.EML_SERNO.cds_Equal(_entEmail.EML_SERNO), "", "");

                SendMail(client);
            }
            client.ServicePoint.CloseConnectionGroup(client.ServicePoint.ConnectionName);
        }

        private void SendMail(SmtpClient client)
        {
            if (_entEmail == null || _entReceiver == null) return;
            if (_entEmail.EML_SERNO == "" || !_entReceiver.readFirst()) return;

            MailAddressCollection to = new MailAddressCollection(), cc = new MailAddressCollection();

            try
            {
                do
                {
                    if (_entReceiver.ERC_TYPE == "C")
                        cc.Add(new MailAddress(_entReceiver.ERC_EMAIL, _entReceiver.ERC_NAME));
                    else
                        to.Add(new MailAddress(_entReceiver.ERC_EMAIL, _entReceiver.ERC_NAME));
                }
                while (_entReceiver.read());

                if (to.Count == 0)
                {
                    WriteEmailLog(_entEmail.EML_SERNO, Message1, "E");
                    return;
                }

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(UserEmail, UserName);
                foreach (MailAddress m in to)
                    mail.To.Add(m);
                foreach (MailAddress m in cc)
                    mail.CC.Add(m);
                mail.Subject = _entEmail.EML_TITLE;
                mail.Body = _entEmail.EML_CONTENT;

                //attachment
                if (_entFile.readFirst())
                {
                    ArrayList s = new ArrayList();
                    do
                    {
                        if (_attachmentFile[_entFile.ULF_SERNO.Value] == null)
                        {
                            s.Add(_entFile.ULF_SERNO.Value);
                        }
                        else
                        {
                            mail.Attachments.Add((Attachment)_attachmentFile[_entFile.ULF_SERNO.Value]);
                        }

                    } while (_entFile.read());

                    if (s.Count > 0)
                    {
                        DocumentFile entDoc = new DocumentFile(_conn);
                        entDoc.query(null, entDoc.ULF_SERNO.cds_EqualIn((string[])s.ToArray(typeof(string))), "", "");
                        UploadFileObj fObj = new UploadFileObj(entDoc, entDoc.ULF_FILE);
                        Attachment att;
                        MemoryStream fs;
                        while (entDoc.read())
                        {
                            fs = new MemoryStream();
                            fObj.ToStream(fs);
                            att = new Attachment(fs, entDoc.ULF_FILENAME, MediaTypeNames.Application.Octet);
                            mail.Attachments.Add(att);
                            _attachmentFile[entDoc.ULF_SERNO.Value] = att;
                        }
                    }
                }

                client.Send(mail);

                WriteEmailLog(_entEmail.EML_SERNO, "郵件寄出", "S");
            }
            catch (Exception ex)
            {
                WriteEmailLog(_entEmail.EML_SERNO, ex.Message, "E");
                return;
            }
        }

        private void WriteEmailLog(string serno, string content, string status)
        {
            Email entity = new Email(_conn);
            entity.query(null, entity.EML_SERNO.cds_Equal(serno), "", 0, 1);
            if (entity.read())
            {
                entity.EML_STATUS = status;
                entity.EML_DTTM = DateTime.Now;
                entity.update(entity.EML_SERNO.cds_Equal(serno));

                WriteEmailLog(serno, content);
            }
        }

        private void WriteEmailLog(string serno, string content)
        {
            EmailLog entity = new EmailLog(_conn);
            entity.ELG_SERNO = EASONTECH.Framework2.Common.Utility.generateSerialNum();
            entity.EML_SERNO = serno;
            entity.ELG_CONTENT = content;
            entity.ELG_DTTM = DateTime.Now;
            entity.insert();
        }

        public EmailObj(IDataProvider conn)
        {
            _conn = conn;
            _attachmentFile = new Hashtable();
        }
    }
}
