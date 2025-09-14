using Kr.Common.Infrastructure.Datastore;


namespace Kr.Backoffice.Persistence.UserAggregate.ValueObject;

public sealed class Address : BaseValueObject
{
    public required string Line1 { get; set; }
    public string? Line2 { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string PostCode { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Line1;
        yield return City;
        yield return State;
        yield return PostCode;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Address other)
            return false;

        return Line1 == other.Line1 &&
               Line2 == other.Line2 &&
               City == other.City &&
               State == other.State &&
               PostCode == other.PostCode;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Line1, Line2, City, State, PostCode);
    }
}
