using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertiseService.Domain.Entities;

namespace AdvertiseService.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<string>, IUser
    {  
        public string FullName { get; set; }
        public string HashedPassword { get; set; }
        public string Role { get; set; }
        /// <summary>
        /// لیست آگهی‌های ایجاد شده توسط کاربر
        /// </summary>
        public virtual ICollection<Ad> Ads { get; set; }



        public static ApplicationUser Create(string email, string fullName, string role)
        {
            return new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = email,
                FullName = fullName,
                Role = role
            };
        }

        public void SetPassword(string hashedPassword)
        {
            HashedPassword = hashedPassword;
        }
    }
}
