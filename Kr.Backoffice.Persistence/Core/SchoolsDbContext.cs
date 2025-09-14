
using Kr.Backoffice.Persistence.Core.Configuration;
using Kr.Backoffice.Persistence.SchoolAggregate.Entity;
using Kr.Common.Infrastructure.Datastore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Kr.Backoffice.Persistence.Core;

public class SchoolDbContext(DbContextOptions<SchoolDbContext> options,
    IOptions<SchoolSettings> dbSettings) : BaseContext<SchoolDbContext>(options, dbSettings)
{
      public DbSet<School> Schools { get; set; }
      public DbSet<Datapoint> MyProperty { get; set; }

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

        modelBuilder.ApplyAllConfigurations(typeof(SchoolConfiguration));
    }
}
