using Budgeteer.Services.BudgeteerApi.Shared.Documents;

namespace Budgeteer.Services.BudgeteerApi.Shared.Transactions;

public abstract class TransactionRequest
{
    public record Update(
        TransactionDto.Mutate Model
    );

    public record CreateEnclosedDocument(
        DocumentDto.Mutate Model  
    );
}
