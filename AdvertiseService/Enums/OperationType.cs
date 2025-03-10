using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertiseService.Domain.Enums
{
    /// <summary>
    /// انواع عملیات‌های ثبت شده در تاریخچه تغییرات
    /// </summary>
    public enum OperationType
    {
        Create = 1,
        Update = 2,
        Archive = 3,
        Publish = 4,
        Reject = 5
    }
}
