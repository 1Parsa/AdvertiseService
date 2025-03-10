using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Application.Common.DTOs
{
    /// <summary>
    /// مدل داده برای تاریخچه تغییرات
    /// </summary>
    public class AdHistoryDto
    {
        public DateTime OperationDate { get; set; }
        public string OperationType { get; set; }
        public string Description { get; set; }
    }
}
