using MailKit;
using Microsoft.Extensions.Configuration;
using ServiceLayer.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Classes.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task SendEmailToMyselfAsync(MailRequest mailRequest);
    }

}
