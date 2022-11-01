using System.Threading.Tasks;

namespace AlEjazSMS.Data;

public interface IAlEjazSMSDbSchemaMigrator
{
    Task MigrateAsync();
}
