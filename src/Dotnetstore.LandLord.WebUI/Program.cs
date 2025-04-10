using Dotnetstore.LandLord.WebUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebUI();

var app = builder.Build();

app.AddWebUI();

app.Run();