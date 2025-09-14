using Kr.Backoffice.Persistence.SchoolAggregate.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NpgsqlExt = Microsoft.EntityFrameworkCore.NpgsqlPropertyBuilderExtensions;
//using SqlServerExt = Microsoft.EntityFrameworkCore.SqlServerPropertyBuilderExtensions;

namespace Kr.Backoffice.Persistence.Core.Configuration;

public sealed class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.ToTable("schools");
        NpgsqlExt.UseHiLo(
            builder.Property(a => a.Id).HasColumnName("Id").HasColumnType("integer"),
         "school_seq", "kr")
         .ValueGeneratedOnAdd();

        builder.HasKey(a => a.Id).HasName("pk_Samples_Id");
        builder.Property(a => a.VersionStamp).IsRowVersion();
        builder.Property(a => a.CreatedAt).HasColumnType("timestamp").HasColumnName("CreatedAt")
            .ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
        builder.Property(a => a.CreatedBy).HasColumnType("varchar(500)").HasColumnName("CreatedBy")
            .IsRequired(false);
        builder.Property(a => a.Name).IsRequired().HasColumnName("Name")
                .HasColumnType("varchar(500)").HasMaxLength(500);
        builder.Property(a => a.ACARAId).IsRequired(false).HasColumnName("ACARAId")
                .HasColumnType("varchar(50)").HasMaxLength(50);
        builder.Property(a => a.SchoolLevel).IsRequired(false).HasColumnName("SchoolLevel")
                .HasColumnType("integer");
        builder.Property(a => a.OpportunityClass).IsRequired(false).HasColumnName("OpportunityClass")
                .HasColumnType("boolean");
        builder.Property(a => a.SchoolSubtype).IsRequired(false).HasColumnName("SchoolSubtype")
                .HasColumnType("varchar(100)").HasMaxLength(100);
        builder.Property(a => a.SchoolSpecialityType).IsRequired(false).HasColumnName("SchoolSpecialityType")
                .HasColumnType("varchar(100)").HasMaxLength(100);
        builder.Property(a => a.PreSchoolIndicator).IsRequired().HasColumnName("PreSchoolIndicator")
                .HasColumnType("boolean");
        builder.Property(a => a.DistanceEducation).IsRequired().HasColumnName("DistanceEducation")
                .HasColumnType("boolean");
        builder.Property(a => a.IntensiveEducation).IsRequired().HasColumnName("IntensiveEducation")
                .HasColumnType("boolean");
        builder.Property(a => a.SchoolGender).IsRequired(false).HasColumnName("SchoolGender")
                .HasColumnType("varchar(50)").HasMaxLength(50);

        builder.OwnsOne(a => a.CommercialAddress, e =>
        {
            e.Property(a => a.Line1).IsRequired().HasColumnName("Line1")
                .HasColumnType("varchar(max)").HasMaxLength(-1);
            e.Property(a => a.Line2).IsRequired(false).HasColumnName("Line2")
                .HasColumnType("varchar(max)");
            e.Property(a => a.Suburb).IsRequired().HasColumnName("Suburb")
                .HasColumnType("varchar(100)").HasMaxLength(100);
            e.Property(a => a.PostCode).IsRequired().HasColumnName("PostCode")
                .HasColumnType("varchar(20)").HasMaxLength(20);
            e.Property(a => a.Cordinates).IsRequired().HasColumnName("Cordinates")
                .HasColumnType("geography(Point,4326)");
        });
        
        builder.OwnsMany(a => a.Contacts, e =>
        {
            e.ToTable("school_contacts", "kr");
            e.WithOwner(a => a.School).HasForeignKey("SchoolId");
            e.HasKey("Id").HasName("pk_SchoolContacts_Id");
            e.Property<int>("Id").HasColumnType("integer").ValueGeneratedOnAdd();
            
            // Map the actual Contact properties
            e.Property(a => a.Type).IsRequired().HasColumnName("Type")
                .HasColumnType("integer")
                .HasConversion<int>(); // Convert enum to int
                
            e.Property(a => a.Value).IsRequired().HasColumnName("Value")
                .HasColumnType("varchar(200)").HasMaxLength(200);
        }); 
    }
}
