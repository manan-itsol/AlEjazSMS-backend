using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AlEjazSMS.Data;

/* This is used if database provider does't define
 * IAlEjazSMSDbSchemaMigrator implementation.
 */
public class NullAlEjazSMSDbSchemaMigrator : IAlEjazSMSDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
