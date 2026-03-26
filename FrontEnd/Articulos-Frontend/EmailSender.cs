using System;
using System.Collections.Generic;
using System.Text;

namespace Articulos_Frontend
{
    public class EmailSender
    {
        private string smtpServer = "mthelmets-com.mail.protection.outlook.com";
        private int smtpPort = 25;
        private string smtpUser = "bot@mthelmets.com";
        private string smtpPassword = "";
        private bool enableSsl = true;

        public void SendEmail(string to, string subject, string body)
        {
            try
            {
                using (var client = new System.Net.Mail.SmtpClient(smtpServer, smtpPort))
                {
                    client.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPassword);
                    client.EnableSsl = enableSsl;
                    var mailMessage = new System.Net.Mail.MailMessage();
                    mailMessage.From = new System.Net.Mail.MailAddress(smtpUser);
                    mailMessage.To.Add(to);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    client.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar correo: " + ex.Message);
            }
        }

    }
}
