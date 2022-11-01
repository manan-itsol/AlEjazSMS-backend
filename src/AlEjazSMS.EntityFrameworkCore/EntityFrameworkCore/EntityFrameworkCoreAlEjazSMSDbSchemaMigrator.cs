using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AlEjazSMS.Data;
using Volo.Abp.DependencyInjection;

namespace AlEjazSMS.EntityFrameworkCore;

public class EntityFrameworkCoreAlEjazSMSDbSchemaMigrator
    : IAlEjazSMSDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAlEjazSMSDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AlEjazSMSDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AlEjazSMSDbContext>()
            .Database
            .MigrateAsync();
    }
}
