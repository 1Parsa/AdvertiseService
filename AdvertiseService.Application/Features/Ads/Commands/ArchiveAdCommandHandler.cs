using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertiseService.Application;
using AdvertiseService.Domain;
using MediatR;

namespace AdvertiseService.Application.Features.Ads.Commands;
public class ArchiveAdCommandHandler : IRequestHandler<ArchiveAdCommand, Unit>

{

    //private readonly IAdRepository _repository;

    //public ArchiveAdCommandHandler(IAdRepository repository)
    //{
    //    _repository = repository;
    //}

    //public async Task<Unit> Handle(ArchiveAdCommand request, CancellationToken ct)
    //{
    //    await _repository.ArchiveAsync(request.AdId);

    //}


    private readonly IAdRepository _repository;

    public ArchiveAdCommandHandler(IAdRepository repository)

    {

        _repository = repository;

    }
 
    public async Task<Unit> Handle(ArchiveAdCommand request, CancellationToken ct)
    {
        var ad = await _repository.GetByIdAsync(request.AdId);
        if (ad == null)
        {
            throw new Exception("آگهی یافت نشد.");
        }

        //ad.Archive();
        await _repository.ArchiveAsync(ad.Id);

        return Unit.Value;

    }

}
