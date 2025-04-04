using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddPostgres("db")
    .WithPgAdmin();

var dotnetstoreLandlordDb = db.AddDatabase("DotnetstoreLandlordDb");

var apiService = builder.AddProject<Dotnetstore_LandLord_WebApi>("apiService")
    .WithReference(dotnetstoreLandlordDb);

builder.Build().Run();