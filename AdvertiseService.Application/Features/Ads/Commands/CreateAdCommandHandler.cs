using AdvertiseService.Domain;
using AdvertiseService.Domain.Entities;
using AdvertiseService.Domain.Enums;
using AdvertiseService.Domain.ValueObjects;
using MediatR;

namespace AdvertiseService.Application.Features.Ads.Commands;

/// <summary>
/// هندلر کامند ایجاد آگهی
/// </summary>
public class CreateAdCommandHandler : IRequestHandler<CreateAdCommand, string>
{

    private readonly IAdRepository _repository;

    public CreateAdCommandHandler(IAdRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(CreateAdCommand request, CancellationToken ct)
    {
        var ad = new Ad{Id=Guid.NewGuid().ToString(),Title = request.Title, PriceAmount = request.Price,Floor = request.Floor };
        await _repository.AddAsync(ad);
        return ad.Id;
    }



    //private readonly IAdRepository _repository;

    //public CreateAdCommandHandler(IAdRepository repository)
    //{
    //    _repository = repository;
    //}

    //public async Task<int> Handle(CreateAdCommand request, CancellationToken ct)
    //{
    //    var ad = new Ad
    //    {
    //        Title = request.Title,
    //        PriceAmount = request.Price,
    //        Floor = request.Floor,
    //        CreationDate = DateTime.UtcNow,
    //        Status = AdStatus.Active
    //    };

    //    await _repository.AddAsync(ad);
    //    await _repository. SaveChangesAsync(ct);

    //    return ad.Id;
    //}
}