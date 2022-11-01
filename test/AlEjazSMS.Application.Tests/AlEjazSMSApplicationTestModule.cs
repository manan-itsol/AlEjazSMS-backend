using Volo.Abp.Modularity;

namespace AlEjazSMS;

[DependsOn(
    typeof(AlEjazSMSApplicationModule),
    typeof(AlEjazSMSDomainTestModule)
    )]
public class AlEjazSMSApplicationTestModule : AbpModule
{

}
