namespace Budgeteer.Services.BudgeteerApi.Api.Extensions;

public static class IHostEnvironmentExtensions
{
    public static bool IsLocal(this IHostEnvironment hostEnvironment)
    {
        return hostEnvironment
            .IsEnvironment("Local");
    }
}
