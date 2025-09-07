using System;
using Microsoft.OpenApi.Models;


namespace Kr.Backoffice.Api.Infra.Helpers;

public static class ApiHelpers
{
    public static OpenApiOperation GenerateOpenApiDoc(
        this OpenApiOperation operation,
        string summary,
        string description,
        string tagName,
        string tagDescription, bool includeSec = true)
    {
        OpenApiOperation doc = new(operation)
        {
            Summary = summary,
            Description = description,
            Tags = [
              new OpenApiTag{
                    Name = tagName,
                    Description = tagDescription
                }
          ]
        };

        if (includeSec)
            doc.Security = [new OpenApiSecurityRequirement { }];

        return doc;
    }

}
