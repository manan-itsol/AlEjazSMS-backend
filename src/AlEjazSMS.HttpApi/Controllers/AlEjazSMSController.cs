using AlEjazSMS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AlEjazSMS.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AlEjazSMSController : AbpControllerBase
{
    protected AlEjazSMSController()
    {
        LocalizationResource = typeof(AlEjazSMSResource);
    }
}
