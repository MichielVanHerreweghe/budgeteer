using Budgeteer.Services.BudgeteerApi.Domain.Documents;

namespace Budgeteer.Services.BudgeteerApi.Services.Documents;

public interface IDocumentService
{
    Task UpdateAsync(
        int id,
        Document model,
        CancellationToken cancellationToken
    );

    Task DeleteAsync(
        int id,
        CancellationToken cancellationToken
    );
}