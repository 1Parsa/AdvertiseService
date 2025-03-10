using AdvertiseService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Domain.Entities
{
    /// <summary>
    /// تاریخچه تغییرات آگهی
    /// </summary>
    public class AdHistory

    {
        public int Id { get; set; }
        public int AdId { get; set; }
        public OperationType Operation { get; set; }
        public DateTime OperationDate { get; set; }
        public string Description { get; set; }

        // Navigation Property
        public virtual Ad Ad { get; set; }

        public AdHistory(int adId, OperationType operation, string description)
        {
            AdId = adId;
            Operation = operation;
            OperationDate = DateTime.UtcNow;
            Description = description;
        }
    }
}
