using Kr.Backoffice.Domain.Common;
using Kr.Backoffice.Domain.Dto;
using Kr.Backoffice.Persistence.SchoolAggregate.ValueObject;
using Kr.Common.Infrastructure.Datastore;
using NetTopologySuite.Geometries;

namespace Kr.Backoffice.Persistence.SchoolAggregate.Entity;

public enum SchoolLevel
{
    Primary,
    Secondary,
    Community
}

public sealed class School : BaseEntity<School>, IAggregateRoot
{
    public string? Name { get; private set; }
    public string? ACARAId { get; private set; }

    public Datapoint? DataPoints { get; private set; }

    // Schooling level (or school type) flag. Options include: primary school,
    // secondary school, 
    // central/community school.
    public SchoolLevel? SchoolLevel { get; private set; }

    // Opportunity class flag. (Y) or (N) a school offers opportunity classes for 
    // highly achieving Year 5 and 6 
    // academically gifted students.
    public bool? OpportunityClass { get; private set; }

    // Further breakdown of a school level/type. Useful for differentiating junior secondary and senior secondary from standard 7-12 secondary schools. 
    // Also indicates the type of support provided in Schools for Specific Purposes.
    public string? SchoolSubtype { get; private set; }

    // School speciality flag. Most NSW public schools are comprehensive, 
    // however, some schools offer a specialty as well. 
    // Options include: technology, sports, language, 
    // and creative and performing arts.
    public string? SchoolSpecialityType { get; private set; }

    public bool PreSchoolIndicator { get; private set; }

    public bool DistanceEducation { get; private set; }

    public bool IntensiveEducation { get; private set; }

    public string? SchoolGender { get; private set; }

    public string? LGA { get; private set; }

    public Address? CommercialAddress { get; private set; }
    public List<Contact> Contacts { get; private set; } = [];

    public void CreateSchoolDetails(AddressDto commercialAddress, List<ContactDto> contacts)
    {
        double? Latitude = double.TryParse(commercialAddress.Latitude, out double lat) ? lat : null;
        double? Longitude = double.TryParse(commercialAddress.Longitude, out double lon) ? lon : null;

        CommercialAddress = new Address
        {
            Line1 = commercialAddress.AddressLine1 ,
            Line2 = commercialAddress.AddressLine2 ?? string.Empty ,
            Suburb = commercialAddress.Suburb ,
            PostCode = commercialAddress.PostalCode ,
            Cordinates = Latitude.HasValue && Longitude.HasValue ?
                            new Point(Longitude.Value, Latitude.Value) { SRID = 4326 } : null,          
        };

        Contacts = [.. contacts.Select(c => new Contact
        {
            Type = Enum.Parse<ContactType>(c.ContactType),
            Value = c.ContactValue,
        })];
    }
        
    public  School Create(SchoolDto schoolDto)
    {
        this.Name = schoolDto.Name;
        this.ACARAId = schoolDto.ACARAId;
        this.OpportunityClass = schoolDto.OpportunityClass;
        this.SchoolSubtype = schoolDto.SchoolSubtype;
        this.SchoolSpecialityType = schoolDto.SchoolSpecialityType;
        this.PreSchoolIndicator = schoolDto.PreSchoolIndicator;
        this.DistanceEducation = schoolDto.DistanceEducation;
        this.IntensiveEducation = schoolDto.IntensiveEducation;
        this.SchoolGender = schoolDto.SchoolGender;
        this.LGA = schoolDto.LGA;
        this.SchoolLevel = schoolDto.SchoolLevel.HasValue ?
                            (SchoolLevel?)schoolDto.SchoolLevel.Value : null;

        if (schoolDto.DataPoints != null)
            this.DataPoints = Datapoint.CreateDatapoint(schoolDto.DataPoints!);


        CreateSchoolDetails(schoolDto.Address, schoolDto.Contacts);
        return this;
    }
}
