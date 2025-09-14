using Kr.Common.Infrastructure.Datastore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Kr.Backoffice.Persistence.SchoolAggregate.Entity;
using Kr.Backoffice.Domain.Dto;

namespace Kr.Backoffice.Persistence.SchoolAggregate;

public interface ISchoolRepository
{
    Task<School> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IList<School>> GetAllAsync(CancellationToken cancellationToken = default);
}

public class SchoolRepository(ILogger<SchoolRepository> logger, DbContext context)
    : BaseRepository<School>(logger, context), ISchoolRepository
{
    public Task<IList<School>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<School> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(SchoolDto entity, CancellationToken cancellationToken = default)
    {
        var school = new School().Create(entity);
        base.Create(school, cancellationToken: cancellationToken);
        base.SaveAsync(cancellationToken);
        return Task.CompletedTask;
    }
}
