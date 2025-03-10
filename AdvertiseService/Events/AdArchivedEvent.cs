using AdvertiseService.Domain.Contract;
 

namespace RealEstateAdService.Domain.Events;

/// <summary>

/// رویداد دامنه برای بایگانی شدن آگهی

/// </summary>

public class AdArchivedEvent : IDomainEvent

{

    public string AdId { get; }

    public DateTime ArchiveDate { get; }

    public AdArchivedEvent(string adId)

    {

        AdId = adId;

        ArchiveDate = DateTime.UtcNow;

    }

}
