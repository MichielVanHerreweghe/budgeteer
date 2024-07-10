using Budgeteer.Services.BudgeteerApi.Domain.Documents;
using Budgeteer.Services.BudgeteerApi.Domain.Transactions;
using Budgeteer.Services.BudgeteerApi.Persistence;
using Budgeteer.Services.BudgeteerApi.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Budgeteer.Services.BudgeteerApi.Services.Transactions;

public class TransactionService : ITransactionService
{
    private readonly BudgeteerDbContext _dbContext;

    public TransactionService(
        BudgeteerDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }

    public async Task UpdateAsync(
        int id,
        Transaction model,
        CancellationToken cancellationToken
    )
    {
        Transaction transaction = await GetByIdAsync(
            id,
            cancellationToken
        );

        transaction
            .Update(
                model.Name,
                model.Amount,
                model.DateOfTransaction
            );

        await _dbContext
            .SaveChangesAsync(
                cancellationToken
            );
    }

    public async Task DeleteAsync(
        int id,
        CancellationToken cancellationToken
    )
    {
        Transaction transaction = await GetByIdAsync(
            id,
            cancellationToken
        );

        transaction
            .Delete();

        await _dbContext
            .SaveChangesAsync(
                cancellationToken
            );
    }

    public async Task<int> CreateEnclosedDocumentAsync(
        int id,
        Document document,
        CancellationToken cancellationToken
    )
    {
        Transaction transaction = await GetByIdAsync(
            id,
            cancellationToken
        );

        transaction
            .AddEnclosedDocument(
                document
            );

        await _dbContext
            .SaveChangesAsync(
                cancellationToken
            );

        return transaction.Id;
    }

    private async Task<Transaction> GetByIdAsync(
        int id,
        CancellationToken cancellationToken
    )
    {
        Transaction? transaction = await _dbContext
            .Transactions
            .FirstOrDefaultAsync(transaction =>
                transaction.Id == id,
                cancellationToken
            );

        if (transaction is null)
            throw new EntityNotFoundException(
                nameof(Transaction),
                id
            );

        return transaction;
    }
}
