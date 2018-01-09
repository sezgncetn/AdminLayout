using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AdminLayout.Services
{
    public class NetMessage : IMessage
    {
        //Mail olduğu için To 
        public string To { get; set; }

        public bool SendMessage(string subject, string message)
        {
            MailMessage ms = new MailMessage();
            ms.From = new MailAddress("yazilim16.net@gmail.com");
            ms.To.Add(To);
            ms.IsBodyHtml = true;
            ms.Body = message;
            ms.Subject = subject;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("yazilim16.net@gmail.com", "WissenYazilim16");

            try
            {
                smtp.Send(ms);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}