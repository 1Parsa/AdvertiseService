



using Microsoft.EntityFrameworkCore;
using AdvertiseService.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;
using AdvertiseService.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AdvertiseService.Infrastructure.Data
{
    /// <summary>
    /// پایگاه داده اصلی برنامه
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<string>, string>

    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Ad> Ads => Set<Ad>();
        public DbSet<AdHistory> AdHistories => Set<AdHistory>();
        // اضافه کردن DbSet برای IdentityRole
        public DbSet<IdentityRole> IdentityRoles => Set<IdentityRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

        }

    }
}
