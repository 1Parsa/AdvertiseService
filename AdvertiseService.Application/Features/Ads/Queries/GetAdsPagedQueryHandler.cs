using AdvertiseService.Application.Common.DTOs;
using AdvertiseService.Domain;
using AdvertiseService.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AdvertiseService.Application.Features.Ads.Queries
{
    public class GetAdsPagedQueryHandler : IRequestHandler<GetAdsPagedQuery, PagedResultDto<Ad>>

    {

        private readonly IAdRepository _repository; 

        public GetAdsPagedQueryHandler(IAdRepository repository )
        {
            _repository = repository; 
        }

        public async Task<PagedResultDto<Ad>> Handle(GetAdsPagedQuery request, CancellationToken ct)
        {
            int totalCount;
            List<Ad> items;
            _repository.GetPaged(request.PageNumber, request.PageSize, out items, out totalCount);
            
            return new PagedResultDto<Ad>()
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }


    //private readonly IAdRepository _repository;

    //private readonly IMapper _mapper;

    //public GetAdsPagedQueryHandler(IAdRepository repository, IMapper mapper)

    //{

    //    _repository = repository;

    //    _mapper = mapper;

    //}

    //public async Task<PagedResultDto<AdDto>> Handle(GetAdsPagedQuery request, CancellationToken ct)

    //{

    //    var result = await _repository.GetPagedAsync(request.PageNumber, request.PageSize);

    //    return _mapper.Map<PagedResultDto<AdDto>>(result);

    //}



}
