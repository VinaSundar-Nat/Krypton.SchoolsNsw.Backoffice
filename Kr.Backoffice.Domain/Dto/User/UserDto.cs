namespace Kr.Backoffice.Domain.Dto;

public abstract class Identifier
{
    public int Id { get; protected  set; }

    public abstract void SetIdentifier(int id);
}

public sealed class UserDto: Identifier
{
    public override void SetIdentifier(int id) => Id = id;
    public string Name { get; set; } = string.Empty;
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;


}

public record UserFavoriteDto(int UserId, int SchoolId, string SchoolName, DateTime CreatedAt);