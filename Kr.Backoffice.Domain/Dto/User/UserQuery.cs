using System;
using Kr.Backoffice.Domain.Models.Handler;

namespace Kr.Backoffice.Domain.Dto.User;

public class UserQuery : IRequest<UserDto>
{
    public int UserId { get; set; }
    public string? Email { get; set; }
}
