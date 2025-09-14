using System;
using Kr.Backoffice.Domain.Common;
using Kr.Backoffice.Domain.Models.Handler;

namespace Kr.Backoffice.Domain.Dto.School;

public class SchoolQuery : IRequest<SchoolDto>
{
    [Map("Id")]
    public int? Id { get; set; }
    [Map("Name")]
    public string? Name { get; set; }
}
