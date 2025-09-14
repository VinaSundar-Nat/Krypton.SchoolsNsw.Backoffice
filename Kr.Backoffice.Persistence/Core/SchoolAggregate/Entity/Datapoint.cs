using Kr.Backoffice.Domain.Dto;
using Kr.Common.Infrastructure.Datastore;

namespace Kr.Backoffice.Persistence.SchoolAggregate.Entity;

public sealed class Datapoint : BaseEntity<Datapoint>
{
    // Full-time equivalent (FTE) student enrolments as reported under 2024
    // the Australian Bureau of Statistics (ABS) National Schools Collection 
    // (NSSC).
    public int? FTEEnrolments { get; set; }

    // The percentage of students (headcount) who are from language backgrounds other than English (LBOTE).
    // A student is considered LBOTE if in their home a language other than English is spoken by the students,
    // parents or guardians. Data is suppressed where student numbers are equal to, or less than five, 
    // indicated by "np".
    public string? LBOTEPercentage { get; set; }

    // Index of Community Socio-Educational Advantage (ICSEA), sourced from ACARA. 
    // The ICSEA is a scale that represents levels of educational advantage. ICSEA values are on a scale, which has a mean of 1000 and a standard deviation of 100. 
    // ICSEA values range from around 500 (representing extremely disadvantaged backgrounds) to about 1300 (representing schools with students from very advantaged backgrounds). 
    public int? ICSEA { get; set; }


    public int? SchoolId { get; set; }
    public School? School { get; set; }

    public static Datapoint? CreateDatapoint(DatapointDto dto)
    {
        if (dto == null) return null;

        return new Datapoint
        {
            FTEEnrolments = dto.FTEEnrolments,
            LBOTEPercentage = dto.LBOTEPercentage,
            ICSEA = dto.ICSEA
        };
    }

}    
