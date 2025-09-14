using Kr.Backoffice.Persistence.SchoolAggregate.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NpgsqlExt = Microsoft.EntityFrameworkCore.NpgsqlPropertyBuilderExtensions;
//using SqlServerExt = Microsoft.EntityFrameworkCore.SqlServerPropertyBuilderExtensions;

namespace Kr.Backoffice.Persistence.Core.Configuration;

public sealed class DatapointConfiguration : IEntityTypeConfiguration<Datapoint>
{
    public void Configure(EntityTypeBuilder<Datapoint> builder)
    {
        builder.ToTable("datapoints", "kr");
        NpgsqlExt.UseHiLo(
            builder.Property(a => a.Id).HasColumnName("Id").HasColumnType("integer"),
         "datapoint_seq", "kr")
         .ValueGeneratedOnAdd();

        builder.HasKey(a => a.Id).HasName("pk_Datapoints_Id");
        builder.Property(a => a.VersionStamp).IsRowVersion();
        builder.Property(a => a.CreatedAt).HasColumnType("timestamp").HasColumnName("CreatedAt")
            .ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
        builder.Property(a => a.CreatedBy).HasColumnType("varchar(500)").HasColumnName("CreatedBy")
            .IsRequired(false);

        builder.Property(a => a.FTEEnrolments).IsRequired(false).HasColumnName("FTEEnrolments")
            .HasColumnType("integer");
        builder.Property(a => a.LBOTEPercentage).IsRequired(false).HasColumnName("LBOTEPercentage")
            .HasColumnType("varchar(50)").HasMaxLength(50);
        builder.Property(a => a.ICSEA).IsRequired(false).HasColumnName("ICSEA")
            .HasColumnType("integer");

        builder.Property(a => a.SchoolId).IsRequired(false).HasColumnName("SchoolId")
            .HasColumnType("integer");

        builder.HasOne(a => a.School)
            .WithOne(s => s.DataPoints)
            .HasForeignKey<Datapoint>(a => a.SchoolId)
            .HasConstraintName("fk_Datapoints_SchoolId");
    }
}
