using System;
using Kr.Backoffice.Domain.Dto;

namespace Kr.Backoffice.Domain.Ports;

public interface ISampleFeature
{
    Task<SampleDto> Samples(string id);
}
