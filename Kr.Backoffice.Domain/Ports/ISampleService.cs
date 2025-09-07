using System;
using Kr.Backoffice.Domain.Dto;

namespace Kr.Backoffice.Domain.Ports;

public interface ISampleService
{
    Task<SampleDto> Get(string id);
}
