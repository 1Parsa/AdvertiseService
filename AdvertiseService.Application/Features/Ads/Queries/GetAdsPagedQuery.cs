using MediatR;
using AdvertiseService.Application.Common.DTOs;
using AdvertiseService.Domain.Entities;


namespace AdvertiseService.Application.Features.Ads.Queries
{
    /// <summary>
    /// کوئری برای دریافت لیست صفحه‌بندی شده آگهی‌ها
    /// </summary>
    public class GetAdsPagedQuery : IRequest<PagedResultDto<Ad>>

    {

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

    }
}
