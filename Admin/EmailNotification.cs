using System;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace espaceNetSAV.Admin
{
    class EmailNotification
    {
        MailAddress from = new MailAddress("mohamedbaza16@gmail.com", "Mohammed BAZA");
        MailAddress to = new MailAddress("kingofmad16@gmail.com", "Salah BAZA");


        public EmailNotification(string content)
        {
            /*
            mail = new MailMessage(SENDER, RECIEVER);
            client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("mohamedbaza16@gmail.com", FileServices.readFile());
            client.EnableSsl = true;
            client.Host = "smtp.google.com";
            mail.Subject = "this is a test mail";
            mail.Body = "this is a test mail body";
            client.Send(mail);
            */
            /* ######## Second Method #########*/

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from.Address, "Bazaking16")
            };

            using (MailMessage message = new MailMessage(from, to) {
              Subject = "Subject goes here!",
              Body = "Body goes here!"
            })
            {
                client.Send(message);
            }
        }
    }
}
