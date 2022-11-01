using System;
using System.Collections.Generic;
using System.Text;
using AlEjazSMS.Localization;
using Volo.Abp.Application.Services;

namespace AlEjazSMS;

/* Inherit your application services from this class.
 */
public abstract class AlEjazSMSAppService : ApplicationService
{
    protected AlEjazSMSAppService()
    {
        LocalizationResource = typeof(AlEjazSMSResource);
    }
}
