using Kr.Backoffice.Persistence.Core;
using Kr.Common.Infrastructure.Datastore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kr.Backoffice.Persistence;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
         services.Configure<UserSettings>(configuration.GetSection("DataStore:User"));
         services.Configure<SchoolSettings>(configuration.GetSection("DataStore:School"));
         services.DbNpgContextPoolSettings<UserDbContext>(configuration, Constants.UserDataKey);
         services.DbNpgContextPoolSettings<SchoolDbContext>(configuration, Constants.SchoolDataKey);
    }
}
