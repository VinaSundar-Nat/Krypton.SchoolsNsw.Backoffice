using System;
using Kr.Common.Infrastructure.Datastore;


namespace Kr.Backoffice.Persistence.SampleAggregate.ValueObject;

public sealed class Price : BaseValueObject
{
    public required decimal Amount { get; set; }
    public required string Currency { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
