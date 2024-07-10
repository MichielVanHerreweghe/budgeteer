using Budgeteer.Services.BudgeteerApi.Domain.Books;
using Budgeteer.Services.BudgeteerApi.Domain.Transactions;
using Budgeteer.Services.BudgeteerApi.Infrastructure.Mappers.Books;
using Budgeteer.Services.BudgeteerApi.Infrastructure.Mappers.Transactions;
using Budgeteer.Services.BudgeteerApi.Services.Books;
using Budgeteer.Services.BudgeteerApi.Shared.Books;
using Microsoft.AspNetCore.Mvc;

namespace Budgeteer.Services.BudgeteerApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(
        IBookService bookService
    )
    {
        _bookService = bookService;
    }

    [HttpPost]
    public async Task<BookResponse.Create> CreateAsync(
        [FromBody] BookRequest.Create request,
        CancellationToken cancellationToken = default!
    )
    {
        Book book = request
            .Model
            .ToDomain();

        int id = await _bookService
            .CreateAsync(
                book,
                cancellationToken
            );

        return new BookResponse.Create(
            id
        );
    }

    [HttpGet]
    public async Task<BookResponse.Index> GetIndexAsync(
        [FromQuery] BookRequest.Index request,
        CancellationToken cancellationToken = default!
    )
    {
        IEnumerable<Book> books = await _bookService
            .GetAsync(
                request.Name,
                request.Page,
                request.PageSize,
                cancellationToken
            );

        IReadOnlyCollection<BookDto.Index> dtos = books
            .Select(book =>
                book.ToIndex()
            )
            .ToList()
            .AsReadOnly();

        return new BookResponse.Index(
            dtos
        );
    }

    [HttpGet("{id}")]
    public async Task<BookResponse.Detail> GetDetailAsync(
        int id,
        CancellationToken cancellationToken = default!
    )
    {
        Book book = await _bookService
            .GetByIdAsync(
                id,
                cancellationToken
            );

        BookDto.Detail dto = book
            .ToDetail();

        return new BookResponse.Detail(
                dto
            );
    }

    [HttpPut("{id}")]
    public async Task UpdateAsync(
        int id,
        BookRequest.Update request,
        CancellationToken cancellationToken = default!
    )
    {
        Book book = request
            .Model
            .ToDomain();

        await _bookService
            .UpdateAsync(
                id,
                book,
                cancellationToken
            );
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default!
    )
    {
        await _bookService
            .DeleteByIdAsync(
                id,
                cancellationToken
            );
    }

    [HttpPost("{id}/revenue")]
    public async Task<BookResponse.CreateTransaction> CreateRevenueAsync(
        int id,
        BookRequest.CreateTransaction request,
        CancellationToken cancellationToken = default!
    )
    {
        Revenue revenue = request
            .Model
            .ToDomainRevenue();

        int transactionId = await _bookService
            .CreateTransactionAsync(
                id,
                revenue,
                cancellationToken
            );

        return new BookResponse.CreateTransaction(
            transactionId
        );
    }

    [HttpPost("{id}/expense")]
    public async Task<BookResponse.CreateTransaction> CreateExpenseAsync(
        int id,
        BookRequest.CreateTransaction request,
        CancellationToken cancellationToken = default!
    )
    {
        Expense expense = request
            .Model
            .ToDomainExpense();

        int transactionId = await _bookService
            .CreateTransactionAsync(
                id,
                expense,
                cancellationToken
            );

        return new BookResponse.CreateTransaction(
            transactionId
        );
    }
}
