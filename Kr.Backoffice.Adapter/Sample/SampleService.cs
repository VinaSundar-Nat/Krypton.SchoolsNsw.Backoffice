using System;
using Kr.Backoffice.Domain.Common;
using Kr.Backoffice.Domain.Dto;
using Kr.Backoffice.Domain.Ports;
using Microsoft.Extensions.Options;

namespace Kr.Backoffice.Adapter.Sample;

public class SampleService(IOptions<ServiceConfiguration> ServiceOptions) : ISampleService
{
    private readonly ServiceConfiguration _serviceConfiguration = ServiceOptions.Value;
    
    public async Task<SampleDto> Get(string id)
    {
        throw new NotImplementedException();
    }
}
