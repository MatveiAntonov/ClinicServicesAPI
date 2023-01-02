using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Management.WebApi
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                var apiVersion = description.ApiVersion.ToString();
                options.SwaggerDoc(description.GroupName,
                    new OpenApiInfo
                    {
                        Version = apiVersion,
                        Title = $"Management API {apiVersion}",
                        Contact = new OpenApiContact
                        {
                            Name = "Matvei",
                            Email = "matvei.antonov.work@gmail.com"
                        }
                    });

                options.CustomOperationIds(apiDescription =>
                apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)
                    ? methodInfo.Name
                    : null);
            }
        }
    }
}
