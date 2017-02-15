﻿using System;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace espaceNetSAV.Admin
{
    class EmailNotification
    {
        MailAddress to = new MailAddress("mohamedbaza16@gmail.com", "Mohammed BAZA");
        MailAddress from = new MailAddress("kingofmad16@gmail.com", "Salah BAZA");


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
                Credentials = new NetworkCredential(from.Address, "Bazaking16")
            };
            

            using (MailMessage message = new MailMessage(from, to) {
                IsBodyHtml = true,
                Subject = String.Format("Notification Instance N° {0}, Client: {1}", bonObject.id, bonObject.client.nom),
                Body = String.Format("Instance N°: {0} est validé<br>Client: <strong>{1}</strong><br>Contact: {2}<br>Prix: <strong>{3}</strong>", bonObject.id, bonObject.client.nom, bonObject.contact, bonObject.tech.price)
            })
            {
                try
                {
                    
                    client.Send(message);
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }
    }
}
