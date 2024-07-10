using Budgeteer.Services.BudgeteerApi.Domain.Books;
using Budgeteer.Services.BudgeteerApi.Infrastructure.Mappers.Transactions;
using Budgeteer.Services.BudgeteerApi.Shared.Books;

namespace Budgeteer.Services.BudgeteerApi.Infrastructure.Mappers.Books;

public static class BookMapper
{
    public static Book ToDomain(
        this BookDto.Mutate model    
    )
    {
        Book book = new(
            model.Name
        );

        return book;
    }

    public static BookDto.Index ToIndex(
        this Book book
    )
    {
        BookDto.Index dto = new(
            book.Id,
            book.Name,
            book.CreatedAt
        );

        return dto;
    }

    public static BookDto.Detail ToDetail(
        this Book book    
    )
    {
        BookDto.Detail dto = new(
            book.Id,
            book.Name,
            book.CreatedAt,
            book.Revenues.Select(revenue =>
                revenue.ToIndex()
            )
            .ToList(),
            book.Expenses.Select(expense =>
                expense.ToIndex()
            )
            .ToList()
        );

        return dto;
    }
}
