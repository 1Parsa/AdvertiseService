using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Application.Common.DTOs
{
    /// <summary>
    /// نتیجه صفحه‌بندی شده برای لیست‌ها
    /// </summary>
    public class PagedResultDto<T>

    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        //public List<T> Items { get; set; }

        //public int TotalCount { get; set; }

        //public int PageNumber { get; set; }

        //public int PageSize { get; set; }

    }
}
