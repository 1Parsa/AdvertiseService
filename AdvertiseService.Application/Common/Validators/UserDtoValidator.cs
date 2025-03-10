using AdvertiseService.Application.Common.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Application.Common.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("ایمیل الزامی است.")
                .EmailAddress().WithMessage("فرمت ایمیل نامعتبر است.");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("نام کامل الزامی است.")
                .MaximumLength(100).WithMessage("نام کامل نمی‌تواند بیش از 100 کاراکتر باشد.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("رمز عبور الزامی است.")
                .MinimumLength(8).WithMessage("رمز عبور باید حداقل 8 کاراکتر باشد.");
        }
    }
}
