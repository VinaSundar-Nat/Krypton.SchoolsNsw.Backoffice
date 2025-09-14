using Kr.Backoffice.Application.Feature.User.Query;
using Kr.Backoffice.Application.Feature.School.Query;
using Kr.Backoffice.Domain.Dto;
using Kr.Backoffice.Domain.Dto.School;
using Kr.Backoffice.Domain.Dto.User;
using Kr.Backoffice.Domain.Models.Handler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kr.Backoffice.Application;

public static class Startup
{
     public static void RegisterFeatures(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRequestHandler<SchoolQuery, SchoolDto>, SchoolQueryHandler>();
        services.AddScoped<IRequestHandler<UserQuery, UserDto>, UserQueryHandler>();
    }
}
