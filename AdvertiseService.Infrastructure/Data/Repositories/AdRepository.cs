using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertiseService.Domain;
using AdvertiseService.Domain.Entities;
using AdvertiseService.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AdvertiseService.Infrastructure.Data.Repositories
{
    /// <summary>
    /// پیاده‌سازی ریپازیتوری برای مدیریت آگهی‌ها
    /// </summary>
    public class AdRepository : IAdRepository
    {
        private readonly ApplicationDbContext _context;

        public AdRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ad> GetByIdAsync(string id)
        {
            return await _context.Ads
                .Include(a => a.History)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Ad ad)
        {
            await _context.Ads.AddAsync(ad);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Ad ad)
        {
            throw new NotImplementedException();
        }

        public async Task ArchiveAsync(string id)
        {
             _context.Ads.First(x => x.Id == id).Status = AdStatus.Archived;

            await _context.SaveChangesAsync();
        }

        // پیاده‌سازی متد جدید
        public async Task<int> CleanupExpiredAdsAsync()
        {
            var expiredAds = await _context.Ads
                .Where(a => a.ExpirationDate < DateTime.UtcNow)
                .ToListAsync();

            foreach (var ad in expiredAds)
            {
                ad.Archive(); // یا هر منطق بایگانی/حذف
            }

            return await _context.SaveChangesAsync();
        }



        public void GetPaged(int pageNumber, int pageSize,out List<Ad> items,out int totalCount)
        {
            var query = _context.Ads
                .Include(a => a.Images)
                .Include(a => a.History)
                .AsNoTracking();

              totalCount =   query.Count();
              items =   query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

 
               
             
        }
    }
}
