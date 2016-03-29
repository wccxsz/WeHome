using System.Net;
using System.Net.Mail;

namespace WeHome.Framework.Tools
{
    public static class Email
    {
        public static void SendEmail(string toEmail, string subject, string mailBody, string[] attachFiles)
        {
            var fromEmail = "wccx3123123123s12z@126.com";
            var message = new MailMessage(fromEmail, toEmail, subject, mailBody);
            foreach (var item in attachFiles)
            {
                message.Attachments.Add(new Attachment(item));
            }
            var client = new SmtpClient("smtp.126.com", 25)
            {
                Credentials = new NetworkCredential(fromEmail, "1123123123123"),
                EnableSsl = true
            };
            //client.SendCompleted += (s, e) =>
            //{
            //    client.Dispose();
            //    message.Dispose();
            //};
            client.Send(message);
        }
    }
}
