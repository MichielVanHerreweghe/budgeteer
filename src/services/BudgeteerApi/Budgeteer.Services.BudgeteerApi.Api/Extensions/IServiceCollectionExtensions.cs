using Budgeteer.Services.BudgeteerApi.Infrastructure.Options;
using Budgeteer.Services.BudgeteerApi.Persistence;
using Budgeteer.Services.BudgeteerApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Budgeteer.Services.BudgeteerApi.Api.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddControllers();

        services
            .AddBudgeteerApiServices();

        services
            .AddDatabaseServices(
                configuration
            );

        services
            .AddSwaggerServices();

        return services;
    }

    private static IServiceCollection AddDatabaseServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddDbContext<BudgeteerDbContext>(options =>
            {
                options
                    .UseSqlServer(
                        configuration
                            .GetConnectionString(
                                DatabaseOptions.Database
                            )
                    );
            }
            );

        return services;
    }

    private static IServiceCollection AddSwaggerServices(
        this IServiceCollection services    
    )
    {
        services
            .AddEndpointsApiExplorer();

        services
            .AddSwaggerGen(options =>
                {
                    options.CustomSchemaIds(type => type.DeclaringType is null
                        ? $"{type.Name}"
                        : $"{type.DeclaringType?.Name}.{type.Name}");
                }
            );

        return services;
    }
}
