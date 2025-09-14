using System;
using Kr.Backoffice.Domain.Dto;
using Kr.Backoffice.Domain.Dto.User;
using Kr.Backoffice.Domain.Models.Handler;

namespace Kr.Backoffice.Application.Feature.User.Query;

public class UserQueryHandler():IRequestHandler<UserQuery, UserDto>
{
    public Task<UserDto> Handle(UserQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

