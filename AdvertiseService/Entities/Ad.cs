using AdvertiseService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAdService.Domain.Events;
using static System.Net.Mime.MediaTypeNames;
using AdvertiseService.Domain.Contract;

namespace AdvertiseService.Domain.Entities
{/// <summary>
 /// موجودیت اصلی آگهی ملک که به عنوان Aggregate Root عمل می‌کند
 /// </summary>
    public class Ad : IAggregateRoot
    {
        /// <summary>
        /// شناسه یکتای آگهی
        /// </summary>
        public string Id { get;  set; }

        /// <summary>
        /// عنوان آگهی - حداکثر 100 کاراکتر
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// تاریخ ایجاد آگهی - به صورت UTC ذخیره می‌شود
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// وضعیت فعلی آگهی (فعال، بایگانی شده، ...)
        /// </summary>
        public AdStatus Status { get; set; }

        /// <summary>
        /// لیست تصاویر آگهی - رابطه یک به چند با AdImage
        /// </summary>
        public virtual ICollection<AdImage> Images { get; set; } = new List<AdImage>();

        /// <summary>
        /// تاریخچه تغییرات آگهی - Lazy Loading فعال است
        /// </summary>
        public virtual ICollection<AdHistory> History { get; set; } = new List<AdHistory>();

        /// <summary>
        /// مبلغ آگهی به ریال - فقط مقادیر مثبت
        /// </summary>
        public decimal PriceAmount { get; set; }

        /// <summary>
        /// طبقه ملک - مقدار منفی مجاز نیست
        /// </summary>
        public int Floor { get; set; }

        /// <summary>
        /// تاریخ انقضای آگهی
        /// </summary>
        public DateTime ExpirationDate { get; private set; }

        public void SetExpiration(DateTime expiration)
        {
            ExpirationDate = expiration;
        }
        // در موجودیت Ad
        public void Archive()
        {
            Status = AdStatus.Archived;
            AddDomainEvent(new AdArchivedEvent(Id)); // ثبت رویداد دامنه
        }


        private readonly List<IDomainEvent> _domainEvents = new();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();


    }


}
