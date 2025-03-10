using FluentValidation;

using AdvertiseService.Application.Features.Ads.Commands;

namespace AdvertiseService.Application;

/// <summary>
/// اعتبارسنجی برای کامند بایگانی آگهی
/// </summary>
public class ArchiveAdCommandValidator : AbstractValidator<ArchiveAdCommand>

{

    public ArchiveAdCommandValidator()

    {

        //RuleFor(x => x.AdId.ToString())
             
        //    .Equal("0").WithMessage("شناسه آگهی نامعتبر است");

    }

}
