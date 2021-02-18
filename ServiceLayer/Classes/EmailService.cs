using Microsoft.Extensions.Options;
using ServiceLayer.Classes.Helpers;
using ServiceLayer.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Classes
{
    public class EmailService : IEmailService
    {
            private readonly MailSettings _mailSettings;
            public EmailService(IOptions<MailSettings> mailSettings)
            {
                _mailSettings = mailSettings.Value;
            }

            public async Task SendEmailAsync(MailRequest mailRequest)
            {
                await SendEmail(mailRequest, false);
            }

            public async Task SendEmailToMyselfAsync(MailRequest mailRequest)
            {
                await SendEmail(mailRequest, true);
            }

            private Task SendEmail(MailRequest mailRequest, bool toMyself)
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);

                if (toMyself)
                {
                    message.To.Add(new MailAddress(_mailSettings.Mail));
                }
                else
                {
                    message.To.Add(new MailAddress(mailRequest.ToEmail));
                }

                message.Subject = mailRequest.Subject;

                message.IsBodyHtml = true;
                message.Body = mailRequest.Body;
                smtp.Port = _mailSettings.Port;
                smtp.Host = _mailSettings.Host;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                return smtp.SendMailAsync(message);
            }
        }
}
