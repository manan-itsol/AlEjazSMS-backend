using AlEjazSMS.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AlEjazSMS;

[DependsOn(
    typeof(AlEjazSMSEntityFrameworkCoreTestModule)
    )]
public class AlEjazSMSDomainTestModule : AbpModule
{

}
