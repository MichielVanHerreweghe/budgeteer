using Budgeteer.Services.BudgeteerApi.Domain.Books;
using Budgeteer.Services.BudgeteerApi.Domain.Transactions;

namespace Budgeteer.Services.BudgeteerApi.Services.Books;

public interface IBookService
{
    Task<int> CreateAsync(
        Book book,
        CancellationToken cancellationToken
    );

    Task<IEnumerable<Book>> GetAsync(
        string? name,
        int page,
        int pageSize,
        CancellationToken cancellationToken
    );

    Task<Book> GetByIdAsync(
        int id,
        CancellationToken cancellationToken
    );

    Task UpdateAsync(
        int id,
        Book model,
        CancellationToken cancellationToken
    );

    Task DeleteByIdAsync(
        int id,
        CancellationToken cancellationToken
    );

    Task<int> CreateTransactionAsync(
        int id,
        Transaction transaction,
        CancellationToken cancellationToken
    );
}
