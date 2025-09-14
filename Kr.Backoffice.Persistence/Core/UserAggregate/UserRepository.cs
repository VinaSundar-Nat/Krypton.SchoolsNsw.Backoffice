using System;
using Kr.Backoffice.Persistence.UserAggregate.Entity;
using Kr.Common.Infrastructure.Datastore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kr.Backoffice.Persistence.UserAggregate;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IList<User>> GetAllAsync(CancellationToken cancellationToken = default);
}

public class UserRepository(ILogger<UserRepository> logger, DbContext context) 
    : BaseRepository<User>(logger, context), IUserRepository
{
    public Task<IList<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
