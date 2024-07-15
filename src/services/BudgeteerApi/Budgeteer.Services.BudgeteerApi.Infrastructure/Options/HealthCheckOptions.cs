namespace Budgeteer.Services.BudgeteerApi.Infrastructure.Options;

public class HealthCheckOptions
{
    public const string HealthCheck = "HealthCheck";

    public string Endpoint { get; set; } = default!;
}
