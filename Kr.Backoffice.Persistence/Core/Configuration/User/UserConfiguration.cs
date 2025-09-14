using Kr.Backoffice.Persistence.UserAggregate.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NpgsqlExt = Microsoft.EntityFrameworkCore.NpgsqlPropertyBuilderExtensions;
//using SqlServerExt = Microsoft.EntityFrameworkCore.SqlServerPropertyBuilderExtensions;


namespace Kr.Backoffice.Persistence.Core.Configuration;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        NpgsqlExt.UseHiLo(
            builder.Property(a => a.Id).HasColumnName("Id").HasColumnType("integer"),
         "user_seq", "kr")
         .ValueGeneratedOnAdd();

        builder.HasKey(a => a.Id).HasName("pk_Users_Id");
        builder.Property(a => a.VersionStamp).IsRowVersion();
        builder.Property(a => a.CreatedAt).HasColumnType("timestamp").HasColumnName("CreatedAt")
            .ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
        builder.Property(a => a.CreatedBy).HasColumnType("varchar(500)").HasColumnName("CreatedBy")
            .IsRequired(false);
        builder.Property(a => a.Name).IsRequired().HasColumnName("Name")
                .HasColumnType("varchar(500)").HasMaxLength(500);

        builder.OwnsOne(a => a.ResidentialAddress, e =>
        {
            e.Property(a => a.Line1).IsRequired().HasColumnName("Line1")
                .HasColumnType("varchar(max)").HasMaxLength(-1);
            e.Property(a => a.Line2).IsRequired(false).HasColumnName("Line2")
                .HasColumnType("varchar(max)");
            e.Property(a => a.City).IsRequired().HasColumnName("City")
                .HasColumnType("varchar(100)").HasMaxLength(100);
            e.Property(a => a.State).IsRequired().HasColumnName("State")
                .HasColumnType("varchar(100)").HasMaxLength(100);
            e.Property(a => a.PostCode).IsRequired().HasColumnName("PostCode")
                .HasColumnType("varchar(20)").HasMaxLength(20);
        });
    }
}
