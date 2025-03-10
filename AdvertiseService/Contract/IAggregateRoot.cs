using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Domain.Contract
{
    /// <summary>
    /// نشان‌دهنده ریشه Aggregate در DDD
    /// </summary>
    internal interface IAggregateRoot
    {
        public string Id { get; set; }
    }
}
