using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AdvertiseService.Application.Features.Ads.Commands
{
    /// <summary>
    /// کامند ایجاد آگهی جدید
    /// </summary>
    public class CreateAdCommand : IRequest<string>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Floor { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
