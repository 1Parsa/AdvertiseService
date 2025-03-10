using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertiseService.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdvertiseService.Infrastructure.Services
{
    public class ExpiredAdsCleanupService : BackgroundService

    {

        //    private readonly IServiceProvider _services;

        //    public ExpiredAdsCleanupService(IServiceProvider services)

        //    {

        //        _services = services;

        //    }

        //    protected override async Task ExecuteAsync(CancellationToken stoppingToken)

        //    {

        //        while (!stoppingToken.IsCancellationRequested)

        //        {

        //            using var scope = _services.CreateScope();

        //            var repository = scope.ServiceProvider.GetRequiredService<IAdRepository>();

        //            await repository.CleanupExpiredAdsAsync();

        //            await Task.Delay(TimeSpan.FromHours(24), stoppingToken);

        //        }

        //    }


        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _period = TimeSpan.FromHours(24);

        public ExpiredAdsCleanupService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(_period);

            while (!stoppingToken.IsCancellationRequested &&
                   await timer.WaitForNextTickAsync(stoppingToken))
            {
                using var scope = _serviceProvider.CreateScope();
                var repository = scope.ServiceProvider.GetRequiredService<IAdRepository>();
                await repository.CleanupExpiredAdsAsync();
            }
        }


    }
}
