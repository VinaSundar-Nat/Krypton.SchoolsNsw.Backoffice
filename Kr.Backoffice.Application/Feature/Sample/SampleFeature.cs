using System;
using Kr.Backoffice.Domain.Dto;
using Kr.Backoffice.Domain.Ports;

namespace Kr.Backoffice.Application.Feature.Sample;

public class SampleFeature(ISampleService SampleService) : ISampleFeature
{
    public async Task<SampleDto> Samples(string id)
    {
        return await SampleService.Get(id);
    }
}
