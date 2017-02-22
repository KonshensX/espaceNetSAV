using System;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace espaceNetSAV.Admin
{
    class EmailNotification
    {
        MailAddress to = new MailAddress("malik.benmakhlouf@gmail.com", "Malik Benmakhlouf");
        MailAddress from = new MailAddress("noreply.espacenet@gmail.com", "Espace Net Mailer");


        public EmailNotification(BonReception bonObject)
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
                Credentials = new NetworkCredential(from.Address, "E$p@ceNet1")
            };
            

            using (MailMessage message = new MailMessage(from, to) {
                IsBodyHtml = true,
                Subject = String.Format("Notification Instance N° {0}, Client: {1}", bonObject.id, bonObject.client.nom),
                Body = String.Format("<h1>Instance N°: {0} est validé<br>Client: {1}<br>Contact: {2}<br>Télephone: {3}<br>Fax: {4}<br>Prix: {5} DH<br>Désignation: {6}</h1>", bonObject.id, bonObject.client.nom, bonObject.contact, bonObject.client.tel, bonObject.client.fax, bonObject.tech.price, bonObject.designationReception.designation)
            })
            {
                try
                {
                    
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            }
        }
    }
}
