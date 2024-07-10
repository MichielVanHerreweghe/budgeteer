using Budgeteer.Services.BudgeteerApi.Domain.Books;
using Budgeteer.Services.BudgeteerApi.Domain.Transactions;
using Budgeteer.Services.BudgeteerApi.Infrastructure.Exceptions;
using Budgeteer.Services.BudgeteerApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Budgeteer.Services.BudgeteerApi.Services.Books;

public class BookService : IBookService
{
    private readonly BudgeteerDbContext _dbContext;

    public BookService(
        BudgeteerDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateAsync(
        Book book,
        CancellationToken cancellationToken
    )
    {
        _dbContext
            .Books
            .Add(
                book
            );

        await _dbContext
            .SaveChangesAsync(
                cancellationToken
            );

        return book
            .Id;
    }

    public async Task<IEnumerable<Book>> GetAsync(
        string? name,
        int page,
        int pageSize,
        CancellationToken cancellationToken
    )
    {
        IQueryable<Book> query = _dbContext
            .Books
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
            query = query
                .Where(book =>
                    book.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
                );

        IEnumerable<Book> books = await query
            .Skip(
                (page - 1) * pageSize
            )
            .Take(
                pageSize
            )
            .OrderByDescending(book =>
                book.CreatedAt
            )
            .ToListAsync(
                cancellationToken
            );

        return books;

    }

    public async Task<Book> GetByIdAsync(
        int id,
        CancellationToken cancellationToken
    )
    {
        Book? book = await _dbContext
            .Books
            .Include(book =>
                book.Transactions
            )
                .ThenInclude(transaction =>
                    transaction.EnclosedDocuments
                )
            .Include(book =>
                book.Transactions
            )
                .ThenInclude(transaction =>
                    transaction.Tags
                )
            .FirstOrDefaultAsync(book =>
                book.Id == id,
                cancellationToken
            );

        if (book is null)
            throw new EntityNotFoundException(
                nameof(Book),
                id
            );

        return book;
    }

    public async Task UpdateAsync(
        int id, 
        Book model,
        CancellationToken cancellationToken
    )
    {
        Book book = await GetByIdAsync(
            id,
            cancellationToken
        );

        book
            .Update(
                model.Name
            );

        await _dbContext
            .SaveChangesAsync(
                cancellationToken
            );
    }

    public async Task DeleteByIdAsync(
        int id,
        CancellationToken cancellationToken
    )
    {
        Book book = await GetByIdAsync(
            id,
            cancellationToken
        );

        book
            .Delete();

        await _dbContext
            .SaveChangesAsync(
                cancellationToken
            );
    }

    public async Task<int> CreateTransactionAsync(
        int id, 
        Transaction transaction,
        CancellationToken cancellationToken
    )
    {
        Book book = await GetByIdAsync(
            id,
            cancellationToken
        );

        book
            .AddTransaction(
                transaction
            );

        await _dbContext
            .SaveChangesAsync(
                cancellationToken
            );

        return transaction
            .Id;
    }
}
