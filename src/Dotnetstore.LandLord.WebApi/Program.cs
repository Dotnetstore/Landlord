using Dotnetstore.LandLord.WebApi.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

var connectionName = builder.Configuration.GetValue<string>("ConnectionName");
ArgumentException.ThrowIfNullOrWhiteSpace(connectionName);

builder.AddWebApi(connectionName);

var app = builder.Build();

app
    .UseFastEndpoints()
    .UseSwaggerGen();

app.Run();

namespace Dotnetstore.LandLord.WebApi
{
    public partial class Program;
}