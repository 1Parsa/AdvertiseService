using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Domain.ValueObjects
{
    /// <summary>
    /// شیء ارزشی برای نمایش قیمت با واحد پولی
    /// </summary>
    public record Price
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; } = "IRR";

        public Price(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("مبلغ نمی‌تواند منفی باشد");

            Amount = amount;
        }
    }
}
