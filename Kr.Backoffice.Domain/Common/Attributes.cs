

namespace Kr.Backoffice.Domain.Common;

public class MapAttribute(string dbField) : Attribute
{
    public string DbField { get; } = dbField;
}
