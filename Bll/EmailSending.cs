using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// add using
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Bll

{
    public class EmailSending
    {
        Model.HashavatAvedaEntities db = new Model.HashavatAvedaEntities();

        public void SendNewUSER(string emailTo)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "hashavat.aveda.0@gmail.com";
            string password = "ruty3857";
            string subject = "הרשמה לאתר 'מצאתי'";
            string body = "<h3>נרשמת בהצלחה לאתר 'מצאתי' האתר החברתי לאבידות ומציאות</h3>";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom, "מצאתי- האתר החברתי");
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                // attach file
                //string attachmentFilename = "c://file.pdf";
                // mail.Attachments.Add(new Attachment(attachmentFilename));
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }

        }
        public void SendDrishaL(string text, int id)
        {
            string emailTo = db.Users.FirstOrDefault(x => x.UserId == db.Losts.FirstOrDefault(y => y.LostId == id).UserId).UserMail;
            SendDrish(text, emailTo);
        }
        public void SendDrishaF(string text, int id)
        {
            string emailTo = db.Users.FirstOrDefault(x => x.UserId == db.Founds.FirstOrDefault(y => y.FoundId == id).UserId).UserMail;
            SendDrish(text, emailTo);
        }
        void SendDrish(string text, string emailTo)
        {
            //decimal  idu = db.Losts.FirstOrDefault(x => x.LostId == id).UserId;

            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "hashavat.aveda.0@gmail.com";
            string password = "ruty3857";
            string subject = "הרשמה לאתר 'מצאתי'";
            string body = "<h3>נ" + text + "</h3>";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom, "מצאתי- האתר החברתי");
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                // attach file
                //string attachmentFilename = "c://file.pdf";
                // mail.Attachments.Add(new Attachment(attachmentFilename));
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }

        }
    }

}
