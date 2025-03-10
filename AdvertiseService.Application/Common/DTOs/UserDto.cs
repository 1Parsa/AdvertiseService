using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Application.Common.DTOs
{

    public class UserDto
    {
        /// <summary>
        /// ایمیل کاربر (به عنوان نام کاربری استفاده می‌شود)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// نام کامل کاربر
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// رمز عبور کاربر
        /// </summary>
        public string Password { get; set; }
    }
}
