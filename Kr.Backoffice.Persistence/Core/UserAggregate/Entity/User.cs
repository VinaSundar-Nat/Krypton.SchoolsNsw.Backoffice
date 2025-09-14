using Kr.Backoffice.Domain.Common;
using Kr.Backoffice.Persistence.UserAggregate.ValueObject;
using Kr.Common.Infrastructure.Datastore;

namespace Kr.Backoffice.Persistence.UserAggregate.Entity;

public sealed class User : BaseEntity<User>, IAggregateRoot
{
    public string? Name { get; set; }
    public Address? ResidentialAddress { get; set; }
}
