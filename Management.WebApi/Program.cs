using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Management.WebApi.Mappings;
using Management.Persistence;
using Management.Application.Interfaces;
using Management.Persistence.Repositories;
using Management.Application;
using Management.WebApi.Middleware;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json.Serialization;
using Management.WebApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ManagementDbContext>(opts => {
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:ManagementConnection"]);
});

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddApplication();

builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IServiceCategoryRepository, ServiceCategoryRepository>();
builder.Services.AddTransient<ISpecializationRepository, SpecializationRepository>();


builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowAll", policy => 
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
});

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
    ConfigureSwaggerOptions>();

builder.Services.ConfigureAuthenticationHandler();


builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
});

builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    var provider = app.Services.GetService<IApiVersionDescriptionProvider>();
    if (provider is not null)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            config.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant()
                );
        }
    }
    config.RoutePrefix = String.Empty;
});

app.UseCustomExceptionHandler();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<ManagementDbContext>();
        DBInitializer.Initialize(context);
    } 
    catch (Exception exception)
    {
        // EXCEPTION
    }
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAll");
app.UseApiVersioning();
app.UseEndpoints(endpoints => 
{
    endpoints.MapControllers();
});

app.Run(async (context) =>
{
    app.Logger.LogInformation($"Processing request {context.Request.Path}");
});

app.Run();




