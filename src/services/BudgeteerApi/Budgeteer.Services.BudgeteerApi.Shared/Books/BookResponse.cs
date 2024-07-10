using Budgeteer.Services.BudgeteerApi.Shared.Transactions;

namespace Budgeteer.Services.BudgeteerApi.Shared.Books;

public abstract class BookResponse
{
    public record Create(
        int Id
    );

    public record Index(
        IReadOnlyCollection<BookDto.Index> Books
    );

    public record Detail(
        BookDto.Detail Book
    );

    public record CreateTransaction(
        int Id  
    );
}
