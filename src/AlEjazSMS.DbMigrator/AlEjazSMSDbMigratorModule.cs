using AlEjazSMS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AlEjazSMS.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AlEjazSMSEntityFrameworkCoreModule),
    typeof(AlEjazSMSApplicationContractsModule)
    )]
public class AlEjazSMSDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
