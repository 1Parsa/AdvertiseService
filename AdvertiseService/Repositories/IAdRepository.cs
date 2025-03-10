using AdvertiseService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Domain
{
    /// <summary>
    /// (قرارداد ریپازیتوری برای مدیریت آگهی‌ها)
    ///  Ad قرارداد ریپازیتوری برای مدیریت موجودیت   
    /// </summary>
    public interface IAdRepository

    {

        Task<Ad> GetByIdAsync(string id);

        Task AddAsync(Ad ad);

        Task UpdateAsync(Ad ad);

        Task ArchiveAsync(string id);


        /// <summary>
        /// پاکسازی آگهی‌های منقضی شده
        /// </summary>
        Task<int> CleanupExpiredAdsAsync();


        /// <summary>
        /// دریافت لیست صفحه‌بندی شده آگهی‌ها
        /// </summary>
        /// <param name="pageNumber">شماره صفحه (از ۱ شروع می‌شود)</param>
        /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
        void GetPaged(int pageNumber, int pageSize, out List<Ad> items, out int totalCount);
    }
 
}
