using Login.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Login.Helpers
{
    public class EmailAccount
    {
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Request { get; set; }
    }

    public static class EmailHelper
    {
        private const string Email = "baim.powiadomienia@baim.pl";
        private const string Password = "losowanez9slow";
        private const string Smtp = "smtp.iq.pl";

        public static void SendEmail(EmailAccount emailAccount)
        {
            using (var smtpClient = new SmtpClient())
            {
                var basicCredential = new NetworkCredential(Email, Password);
                var fromAddress = new MailAddress(Email);
                //smtpClient.Host = Smtp;
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                var message = new MailMessage();
                message.From = fromAddress;
                message.Subject = emailAccount.Subject;                
                message.Body = emailAccount.Request;
                message.IsBodyHtml = true;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.To.Add(emailAccount.Email);
                smtpClient.Send(message);
            }
        }

        public static string GetNewAccountCreatedMessage(RegisterAccountViewModel viewModel)
        {
            return string.Format("Witam, <br/><br/>" +
                                 "Na prośbę użytkownika <b>{0} {1}</b> utworzono nowe konto do aplikacji. <br/>" +
                                 "Login: <b>{2}</b> <br/>" +
                                 "Hasło: <b>{3}</b> <br/>" +
                                 "Jeśli nie składałeś prośby o utworzenie konta proszę zignoruj tę wiadomość.<br/><br/>" +
                                 "Pozdrawiam, <br/>" +
                                 "Administrator aplikacji \"Bank BAIM\" <br/><br/>" +
                                 "Odpowiedź wygenerowano automatycznie, proszę na nią nie odpowiadać.",
                viewModel.FirstName, viewModel.LastName, viewModel.Login, viewModel.Password);
        }
    }
}