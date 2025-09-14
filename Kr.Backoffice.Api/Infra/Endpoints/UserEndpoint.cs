using Kr.Backoffice.Api.Infra.Helpers;
using Kr.Backoffice.Domain.Dto;
using Kr.Backoffice.Domain.Dto.User;
using Kr.Backoffice.Domain.Models.Handler;
using Kr.Common.Infrastructure.Http.Models;
using Microsoft.AspNetCore.Mvc;


namespace KR.Document.HB.Api;

public static partial class ApiEndpoints
{
    public static void UserEndpoints(this WebApplication app)
    {
        var userGroup = app.MapGroup("/api/v1/user");
        userGroup.MapGet("/{userId}", async ([AsParameters] ApiGetRequest request,
                HttpContext context,  [FromRoute] int userId,
                [FromServices] IRequestHandler<UserQuery, UserDto> userFeature,
                CancellationToken token = default) =>
        {
            var user = await userFeature.Handle(new UserQuery{UserId = userId}, token);
            return Results.Ok(new ApiGetSuccessResponse<UserDto> { StatusCode = 200, Url = context.Request.Path ,Data = user });
        }).WithOpenApi(operation =>
            operation.GenerateOpenApiDoc(
                "v1 user get.",
                "user get endpoint to test the api.",
                "User",
                "user details to support enterprise operations."
        ))
        .Produces<ApiGetResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError)
        .Produces(StatusCodes.Status400BadRequest);
    }
}
