using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Domain.Enums
{

    /// <summary>

    /// وضعیت‌های ممکن برای یک آگهی ملک

    /// </summary>

    public enum AdStatus

    {

        /// <summary>

        /// آگهی فعال و قابل نمایش

        /// </summary>

        Active = 1,

        /// <summary>

        /// آگهی بایگانی شده و غیرفعال

        /// </summary>

        Archived = 2,

        /// <summary>

        /// آگهی در حال بررسی توسط مدیر سیستم

        /// </summary>

        UnderReview = 3,

        /// <summary>

        /// آگهی رد شده توسط سیستم

        /// </summary>

        Rejected = 4

    }
}
