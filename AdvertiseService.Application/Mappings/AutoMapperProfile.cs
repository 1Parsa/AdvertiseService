using AutoMapper;

using AdvertiseService.Application.Common.DTOs;

using AdvertiseService.Domain.Entities;

namespace AdvertiseService.Application.Mappings
{
    public class AutoMapperProfile : Profile

    {

        public AutoMapperProfile()
        {
            CreateMap<Ad, AdDto>();
            CreateMap<AdHistory, AdHistoryDto>();
            //CreateMap<List<Ad>, List<AdDto>>();
        }
        //public AutoMapperProfile()

        //{

        //    CreateMap<Ad, AdDto>()

        //        .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));




        //    CreateMap<Ad, AdDto>()
        //        .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.Images.Select(i => i.Url)));

        //    CreateMap<AdHistory, AdHistoryDto>()
        //        .ForMember(dest => dest.OperationType, opt => opt.MapFrom(src => src.Operation.ToString()));
        //}

    }
}
