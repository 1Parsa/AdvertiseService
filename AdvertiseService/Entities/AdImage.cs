using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Domain.Entities
{

    /// <summary>
    /// موجودیت تصویر مرتبط با آگهی
    /// </summary>
    public class AdImage
    {
        /// <summary>
        /// شناسه یکتای تصویر
        /// </summary>
        public int Id { get;set; }

        /// <summary>
        /// آدرس URL تصویر
        /// </summary>
        public string Url { get;set; }

        /// <summary>
        /// شناسه آگهی مرتبط
        /// </summary>
        public int AdId { get;set; }

        /// <summary>
        /// شیء آگهی مرتبط (Navigation Property)
        /// </summary>
        public virtual Ad Ad { get;set; }

        public AdImage(string url)
        {
            Url = url;
        }
    }
}
