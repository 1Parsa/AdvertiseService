using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Domain.Entities
{
    
    public interface IUser
    {
        public string Id { get; set; }
        /// <summary>
        /// ایمیل کاربر
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// نام کامل کاربر
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// نام  کاربری کاربر
        /// </summary>
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public string Role { get;  set; }


        public void SetPassword(string hashedPassword);
    }

    ///// <summary>
    ///// موجودیت کاربر سیستم
    ///// </summary>
    //public class User
    //{
    //    /// <summary>
    //    /// شناسه یکتای کاربر
    //    /// </summary>
    //    public string Id { get; set; }

    //    /// <summary>
    //    /// نام کامل کاربر
    //    /// </summary>
    //    public string FullName { get; set; }

    //    /// <summary>
    //    /// نقش کاربر در سیستم
    //    /// </summary>
    //    public string Role { get; set; }
    //}
}
