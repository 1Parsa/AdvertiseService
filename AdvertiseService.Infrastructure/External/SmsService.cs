using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Infrastructure.External
{
    public interface ISmsService

    {

        Task SendSms(string number, string message);

    }

    public class TwilioSmsService : ISmsService

    {

        public Task SendSms(string number, string message)

        {

            // پیاده‌سازی ارسال SMS
            // پیاده‌سازی با Twilio API
            return Task.CompletedTask;

        }

    }
}
