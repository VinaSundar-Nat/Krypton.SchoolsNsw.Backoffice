using Kr.Backoffice.Persistence.SchoolAggregate.Entity;
using Kr.Common.Infrastructure.Datastore;

namespace Kr.Backoffice.Persistence.SchoolAggregate.ValueObject;


public enum ContactType
{
    Phone,
    Email,
    Mobile,
    Fax
}

public sealed class Contact : BaseValueObject
{
    public required ContactType Type { get; set; }
    public required string Value { get; set; }

    public School? School { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Type;
        yield return Value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Contact other)
            return false;

        return Type == other.Type &&
               Value == other.Value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Type, Value);
    }
}
