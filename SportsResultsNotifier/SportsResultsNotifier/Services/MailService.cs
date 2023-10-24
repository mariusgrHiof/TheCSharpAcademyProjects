using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace SportsResultsNotifier.Services;
public class MailService
{
    static ConfigurationManager _configurationManager = new ConfigurationManager();
    string smtpAddress = "smtp.gmail.com";
    int portNumber = 587;
    bool enableSSL = true;
    string emailFromAddress = "marius.gravningsmyhr@gmail.com"; //Sender Email Address  
    static string password = _configurationManager.GetSection("Password").Value; //Sender Password  
    string emailToAddress = "marius.gravningsmyhr@gmail.com"; //Receiver Email Address  
    string subject = "Hello";
    string body = "Hello, This is Email sending test using gmail.";




    public void SendEmail()
    {
        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress(emailFromAddress);
            mail.To.Add(emailToAddress);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
            using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            {
                smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                smtp.EnableSsl = enableSSL;
                smtp.Send(mail);
            }
        }
    }
}

