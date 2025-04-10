using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddPostgres("db")
    .WithPgAdmin();

var dotnetstoreLandlordDb = db.AddDatabase("DotnetstoreLandlordDb");

var apiService = builder.AddProject<Dotnetstore_LandLord_WebApi>("apiService")
    .WithReference(dotnetstoreLandlordDb)
    .WaitFor(dotnetstoreLandlordDb);

var webUI = builder.AddProject<Dotnetstore_LandLord_WebUI>("webUI")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();