using AdvertiseService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Application.Common.DTOs
{
    /// <summary>
    ///(مدل داده برای انتقال اطلاعات آگهی(
    ///برای نمایش اطلاعات آگهی DTO  
    /// </summary>
    public class AdDto

    {

        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Floor { get; set; }
        public AdStatus Status { get; set; }

        public DateTime CreationDate { get; set; }

        public List<string> ImageUrls { get; set; }

    }
}
