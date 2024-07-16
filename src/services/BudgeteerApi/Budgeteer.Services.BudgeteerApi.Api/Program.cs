using Budgeteer.Services.BudgeteerApi.Api.Extensions;

WebApplicationBuilder builder = WebApplication
    .CreateBuilder(
        args
    );

if (!builder.Environment.IsLocal())
    builder
        .AddHostConfigurations();

builder
    .Services
    .AddApplicationServices(
        builder.Configuration
    );


WebApplication app = builder
    .Build();

app
    .AddApplicationMiddleware(
        builder.Configuration
    );


app.Run();
