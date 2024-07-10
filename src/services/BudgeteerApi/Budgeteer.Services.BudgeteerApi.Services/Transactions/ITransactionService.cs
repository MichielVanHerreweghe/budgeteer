using Budgeteer.Services.BudgeteerApi.Domain.Documents;
using Budgeteer.Services.BudgeteerApi.Domain.Transactions;

namespace Budgeteer.Services.BudgeteerApi.Services.Transactions;

public interface ITransactionService
{
    Task UpdateAsync(
        int id,
        Transaction model,
        CancellationToken cancellationToken
    );

    Task DeleteAsync(
        int id,
        CancellationToken cancellationToken
    );

    Task CreateEnclosedDocument(
        int id,
        Document document,
        CancellationToken cancellationToken
    );
}