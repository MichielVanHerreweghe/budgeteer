using Budgeteer.Services.BudgeteerApi.Infrastructure.Options;
using Budgeteer.Services.BudgeteerApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Budgeteer.Services.BudgeteerApi.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication AddApplicationMiddleware(
        this WebApplication app,
        IConfiguration configuration
    )
    {
        if (app.Environment.IsDevelopment())
            app
                .AddDevelopmentMiddleware();

        app
            .UseHttpsRedirection();

        app
            .AddAuthMiddleware();

        app
            .MapControllers();

        app
            .AddHealthCheckMiddleware(
                configuration
            );

        return app;
    }

    private static WebApplication AddDevelopmentMiddleware(
        this WebApplication app    
    )
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        using (var scope = app.Services.CreateScope())
        {
            BudgeteerDbContext dbContext = scope
                .ServiceProvider
                .GetRequiredService<BudgeteerDbContext>();

            dbContext
                .Database
                .EnsureDeleted();

            dbContext
                .Database
                .EnsureCreated();
        }

        return app;
    }

    // TODO: Use Options pattern
    private static WebApplication AddHealthCheckMiddleware(
        this WebApplication app,
        IConfiguration configuration
    )
    {
        app
            .MapHealthChecks(
                configuration
                    .GetValue<string>(
                        $"{HealthCheckOptions.HealthCheck}:{nameof(HealthCheckOptions.Endpoint)}"
                    )!
            );

        return app;
    }

    private static WebApplication AddAuthMiddleware(
        this WebApplication app    
    )
    {
        app
            .UseAuthorization();

        return app;
    }
}
