namespace Budgeteer.Services.BudgeteerApi.Shared.Documents;

public abstract class DocumentDto
{
    public record Mutate(
        string Name,
        string Url
    );

    public record Index(
        int Id,
        string Name,
        string Url
    );
}
