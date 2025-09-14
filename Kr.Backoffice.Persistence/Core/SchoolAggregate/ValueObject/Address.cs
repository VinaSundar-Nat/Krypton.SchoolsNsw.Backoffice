using NetTopologySuite.Geometries;
using Kr.Common.Infrastructure.Datastore;


namespace Kr.Backoffice.Persistence.SchoolAggregate.ValueObject;

public sealed class Address : BaseValueObject
{
    public required string Line1 { get; set; }
    public string? Line2 { get; set; }
    public required string Suburb { get; set; }
    public required string PostCode { get; set; }
    public Point? Cordinates { get; set; }

    public double? Latitude => Cordinates?.Y;
    public double? Longitude => Cordinates?.X;
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Line1;
        yield return Suburb;
        yield return PostCode;
        if (Cordinates is not null)
        {
            yield return Latitude!;
            yield return Longitude!;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Address other)
            return false;

        return Line1 == other.Line1 &&
               Line2 == other.Line2 &&
               Suburb == other.Suburb &&
               PostCode == other.PostCode &&
               Latitude is not null && other.Latitude is not null &&
               Longitude is not null && other.Longitude is not null &&
               Latitude.Equals(other.Latitude) == true &&
               Longitude.Equals(other.Longitude) == true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Line1, Line2, Suburb, PostCode, Latitude, Longitude);
    }
}
