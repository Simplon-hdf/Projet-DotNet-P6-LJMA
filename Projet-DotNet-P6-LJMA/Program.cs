using Projet_DotNet_P6_LJMA.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

await app.InitializeDataAsync();

app.ConfigurePipeline();

app.Run();