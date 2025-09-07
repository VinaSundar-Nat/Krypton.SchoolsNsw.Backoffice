using System;
using System.Net;
using Kr.Backoffice.Adapter.Sample;
using Kr.Backoffice.Domain.Common;
using Kr.Backoffice.Domain.Ports;
using Kr.Common.Infrastructure.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kr.Backoffice.Adapter;

public static class Startup
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ServiceConfiguration>(configuration.GetSection("Service:SampleService"));
        RegisterClient(services, configuration);
    }

    private static void RegisterClient(IServiceCollection services, IConfiguration configuration)
    {
        var baseUrl = configuration.GetValue<string>("Service:SampleService:BaseUrl");

        if (string.IsNullOrEmpty(baseUrl))        
            throw new ArgumentException("BaseUrl for SampleService is not configured.");

        services.AddScoped<SampleAuthHandler>();
    
        services.AddHttpClient<ISampleService, SampleService>(a =>
        {
            a.BaseAddress = new Uri(baseUrl);
        })
        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            AllowAutoRedirect = false,
            AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
        })
        .AddHttpMessageHandler<SampleAuthHandler>()
        .GetRetryPolicy<SampleService>(3, 2);
    }
}
