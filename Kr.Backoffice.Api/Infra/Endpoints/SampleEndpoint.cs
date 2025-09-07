using Kr.Backoffice.Api.Infra.Helpers;
using Kr.Backoffice.Domain.Dto;
using Kr.Backoffice.Domain.Ports;
using Kr.Common.Infrastructure.Http.Models;
using Microsoft.AspNetCore.Mvc;


namespace KR.Document.HB.Api;

public static partial class ApiEndpoints
{
    public static void SampleEndpoints(this WebApplication app)
    {
        var sampleGroup = app.MapGroup("/api/doc/sample/v1");
        sampleGroup.MapGet("/", async ([AsParameters] ApiGetRequest request,
                HttpContext context,
                [FromServices] ISampleFeature sampleFeature,
                CancellationToken token = default) =>
        {
            var sample = await sampleFeature.Samples("TEST");
            return Results.Ok(new ApiGetSuccessResponse<SampleDto> { StatusCode = 200, Url = context.Request.Path ,Data = sample });
        }).WithOpenApi(operation =>
            operation.GenerateOpenApiDoc(
                "v1 sample get.",
                "sample get endpoint to test the api.",
                "Sample",
                "File opertaions to support enterprise operations."
        ))
        .Produces<ApiGetResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError)
        .Produces(StatusCodes.Status400BadRequest);
    }
}
