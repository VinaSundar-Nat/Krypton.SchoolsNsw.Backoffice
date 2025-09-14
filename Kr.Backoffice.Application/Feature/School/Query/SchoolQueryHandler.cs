using System;
using Kr.Backoffice.Domain.Common;
using Kr.Backoffice.Domain.Dto;
using Kr.Backoffice.Domain.Dto.School;
using Kr.Backoffice.Domain.Models.Handler;
using Kr.Backoffice.Persistence.SchoolAggregate;

namespace Kr.Backoffice.Application.Feature.School.Query;

public class SchoolQueryHandler(ISchoolRepository schoolRepository) : IRequestHandler<SchoolQuery, SchoolDto>
{
    public Task<SchoolDto> Handle(SchoolQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}


