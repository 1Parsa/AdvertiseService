using AdvertiseService.Domain;
using AdvertiseService.Infrastructure.Data.Repositories;
using AdvertiseService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertiseService.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // ثبت سرویس‌های Infrastructure
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IAdRepository, AdRepository>();
        

        return services;
    }


    public static IServiceCollection AddApplicationServices(this IServiceCollection services)

    {

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        services.AddAutoMapper(typeof(Program));

        return services;

    }
}





















//namespace AdvertiseService.Presentation.Extensions
//{
//    /// <summary>
//    /// اکستنشن‌های ثبت سرویس‌ها
//    /// </summary>
//    public static class ServiceCollectionExtensions

//    {

//        public static IServiceCollection AddApplicationServices(this IServiceCollection services)

//        {

//            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//            services.AddAutoMapper(typeof(Program));

//            return services;

//        }

//    }
//}
