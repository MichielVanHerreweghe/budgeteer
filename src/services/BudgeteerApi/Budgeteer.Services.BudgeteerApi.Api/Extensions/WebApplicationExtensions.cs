using Budgeteer.Services.BudgeteerApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Budgeteer.Services.BudgeteerApi.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication AddApplicationMiddleware(
        this WebApplication app    
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

    private static WebApplication AddAuthMiddleware(
        this WebApplication app    
    )
    {
        app
            .UseAuthorization();

        return app;
    }
}
