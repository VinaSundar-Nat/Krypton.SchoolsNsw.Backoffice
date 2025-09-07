using Kr.Backoffice.Adapter;
using Kr.Backoffice.Application.Feature.Sample;
using Kr.Backoffice.Domain.Ports;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kr.Backoffice.Application;

public static class Startup
{
     public static void RegisterFeatures(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterServices(configuration);
        services.AddScoped<ISampleFeature, SampleFeature>();
    }

}
