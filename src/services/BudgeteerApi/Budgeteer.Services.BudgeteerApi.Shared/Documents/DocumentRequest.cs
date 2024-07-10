namespace Budgeteer.Services.BudgeteerApi.Shared.Documents;

public abstract class DocumentRequest
{
    public record Update(
        DocumentDto.Mutate Model
    );
}
