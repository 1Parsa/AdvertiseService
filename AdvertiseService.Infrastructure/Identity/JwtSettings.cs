using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Infrastructure.Identity
{

    /// <summary>
    /// تنظیمات JWT از appsettings.json
    /// </summary>
    public class JwtSettings
    {
        public string Secret { get; set; } = "YourSuperSecretKeyHereAtLeast32Characters";
        public string Issuer { get; set; } = "realestateadservice.com";
        public string Audience { get; set; } = "realestateadservice.com";
        public int ExpirationMinutes { get; set; } = 60;
    }
}
