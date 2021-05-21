using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Web_HelpDesk.Data;

namespace Web_HelpDesk.MM_Utils
{
    public class EmailSender : IEmailSender
    {
        /// <summary>
        /// Send Email to Recipients. Pass multiple recipients into List of string type. Overload supports single email address as string.
        /// </summary>
        /// <param name="Recipients"></param>
        /// <param name="Subject"></param>
        /// <param name="MessageBody"></param>
        /// <returns></returns>
        public async Task MM_SendEmailAsync(List<string> Recipients, string Subject, string MessageBody)
        {
            MailMessage Msg = new MailMessage();
            Msg.Subject = Subject;
            Msg.From = new MailAddress(StaticData._smtpFromAddress, $"{Subject}");
            
            Msg.Body = MessageBody;

            foreach (var item in Recipients)
            {
                Msg.To.Add(item);
            }

            Msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = StaticData._smtpServer;
            smtp.Port = 25;
            smtp.EnableSsl = false;
            smtp.Credentials = new System.Net.NetworkCredential(StaticData._smtpServerLogin, StaticData._smtpServerPassword);
            await smtp.SendMailAsync(Msg);
        }

        /// <summary>
        /// Send Email to Recipient.
        /// </summary>
        /// <param name="Recipient"></param>
        /// <param name="Subject"></param>
        /// <param name="MessageBody"></param>
        /// <returns></returns>
        public async Task MM_SendEmailAsync(string Recipient, string Subject, string MessageBody)
        {
            MailMessage Msg = new MailMessage();
            Msg.Subject = Subject;
            Msg.From = new MailAddress(StaticData._smtpFromAddress, $"{Subject}");
            
            Msg.Body = MessageBody;
            Msg.To.Add(Recipient);            

            Msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = StaticData._smtpServer;
            smtp.Port = 25;
            smtp.EnableSsl = false;
            smtp.Credentials = new System.Net.NetworkCredential(StaticData._smtpServerLogin, StaticData._smtpServerPassword);
            await smtp.SendMailAsync(Msg);
        }

        // My Method implementation for IEmailSender interface from builtin Identities
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {            
            await this.MM_SendEmailAsync(email, subject, htmlMessage);
        }        
    }
}
