namespace Budgeteer.Services.BudgeteerApi.Shared.Tags;

public abstract class TagDto
{
    public record Mutate(
        string Name
    );

    public record Index(
        int Id,
        string Name
    );
}
