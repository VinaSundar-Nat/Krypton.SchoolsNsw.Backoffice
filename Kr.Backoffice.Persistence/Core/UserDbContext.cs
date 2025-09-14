
using Kr.Backoffice.Persistence.Core.Configuration;
using Kr.Backoffice.Persistence.UserAggregate.Entity;
using Kr.Common.Infrastructure.Datastore;
using Kr.Common.Infrastructure.Datastore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Kr.Backoffice.Persistence.Core;

public class UserDbContext(DbContextOptions<UserDbContext> options,
    IOptions<UserSettings> dbSettings) : BaseContext<UserDbContext>(options, dbSettings)
{
      public DbSet<User> Users { get; set; }

    public override Task NotifyChanges()
    {
        // Implement your change notification logic here
        return Task.CompletedTask;
    }
    
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("kr");
 
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasSequence<int>("user_seq", "kr")
          .StartsAt(1)
          .HasMax(30000)
          .IsCyclic()
          .IncrementsBy(1);

        modelBuilder.ApplyAllConfigurations(typeof(UserConfiguration));
    }
}
