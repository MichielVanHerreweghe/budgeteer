using Budgeteer.Services.BudgeteerApi.Shared.Transactions;

namespace Budgeteer.Services.BudgeteerApi.Shared.Books;

public abstract class BookDto
{
    public record Mutate(
        string Name
    );

    public record Index(
        int Id,
        string Name,
        DateTime CreatedAt
    );

    public record Detail(
        int Id,
        string Name,
        DateTime CreatedAt,
        IReadOnlyCollection<TransactionDto.Index> Revenues,
        IReadOnlyCollection<TransactionDto.Index> Expenses
    );
}
