using AdvertiseService.Application.Features.Ads.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AdvertiseService.Application.Common.Validators
{
    /// <summary>
    /// کلاس پایه برای ایجاد قوانین اعتبارسنجی با استفاده از کتابخانه FluentValidation
    /// این کلاس جنریک نوع مدلی که باید اعتبارسنجی شود را می‌پذیرد
    /// هر RuleFor یک قانون اعتبارسنجی را تعریف می‌کند
    /// </summary>
    /// <summary>
    /// اعتبارسنجی کامند ایجاد آگهی
    /// </summary>
    public class CreateAdCommandValidator : AbstractValidator<CreateAdCommand>
    {
        public CreateAdCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("عنوان نمی‌تواند خالی باشد")
                .MaximumLength(100).WithMessage("حداکثر طول عنوان 100 کاراکتر است");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("مبلغ باید بزرگتر از صفر باشد");
        }
    }
}
