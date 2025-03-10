using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Infrastructure.Services
{
    public interface IEmailService

    {

        Task SendEmailAsync(string to, string subject, string body);

    }

    public class SmtpEmailService : IEmailService

    {

        public Task SendEmailAsync(string to, string subject, string body)

        {

            // پیاده‌سازی ارسال ایمیل
            // پیاده‌سازی با SMTP
            return Task.CompletedTask;

        }

    }
     
}
