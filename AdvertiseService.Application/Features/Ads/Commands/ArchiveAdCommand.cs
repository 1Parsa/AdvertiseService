using MediatR;

namespace AdvertiseService.Application;

/// <summary>
/// کامند بایگانی آگهی
/// </summary>
public class ArchiveAdCommand : IRequest<Unit> // یا IRequest برای نسخه‌های قدیمی
{
    public string AdId { get; set; }
}





///// <summary>
///// کامند بایگانی آگهی
///// </summary>
//public class ArchiveAdCommand : IRequest<Unit>

//{

//    public int AdId { get; set; }

//}