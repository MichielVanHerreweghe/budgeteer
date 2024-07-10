using Budgeteer.Services.BudgeteerApi.Shared.Documents;
using Budgeteer.Services.BudgeteerApi.Shared.Tags;

namespace Budgeteer.Services.BudgeteerApi.Shared.Transactions;

public abstract class TransactionDto
{
    public record Mutate(
        string Name,
        decimal Amount,
        DateTime DateOfTransaction
    );

    public record Index(
        int Id,
        string Name,
        decimal Amount,
        DateTime DateOfTransaction,
        IReadOnlyCollection<DocumentDto.Index> EnclosedDocuments,
        IReadOnlyCollection<TagDto.Index> Tags
    );
}
