using System;

namespace Kr.Backoffice.Domain.Dto;

public enum SchoolLevel
{
    Primary,
    Secondary,
    Community
}

public class SchoolDto()
{
    public string? Name { get; set; }
    public string? ACARAId { get; set; }
    public bool? OpportunityClass { get; set; }
    public string? SchoolSubtype { get; set; }
    public string? SchoolSpecialityType { get; set; }
    public bool PreSchoolIndicator { get; set; }
    public bool DistanceEducation { get; set; }
    public bool IntensiveEducation { get; set; }
    public string? SchoolGender { get; set; }
    public string? LGA { get; set; }
public SchoolLevel? SchoolLevel { get; set; }

// Converter for SchoolLevel


    public AddressDto? Address { get; set; }
    public List<ContactDto> Contacts { get; set; } = [];
    public DatapointDto? DataPoints { get; set; }
}   

public record DatapointDto(
    int? FTEEnrolments,
    string? LBOTEPercentage,
    int? ICSEA
);

public record AddressDto(
    string AddressLine1,
    string? AddressLine2,
    string Suburb,
    string PostalCode,
    string? Latitude,
    string? Longitude
);

public record ContactDto(
    string ContactType,
    string ContactValue
);
