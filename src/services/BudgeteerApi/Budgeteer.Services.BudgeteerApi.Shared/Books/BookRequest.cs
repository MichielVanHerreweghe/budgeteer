using Budgeteer.Services.BudgeteerApi.Shared.Transactions;

namespace Budgeteer.Services.BudgeteerApi.Shared.Books;

public abstract class BookRequest
{
    public record Create(
        BookDto.Mutate Model
    );

    public record Index(
        string? Name,
        int Page = 1,
        int PageSize = 25
    );

    public record Update(
        BookDto.Mutate Model
    );

    public record CreateTransaction(
        TransactionDto.Mutate Model
    );
}
