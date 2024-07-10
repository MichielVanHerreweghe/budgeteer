using Budgeteer.Services.BudgeteerApi.Domain.Documents;
using Budgeteer.Services.BudgeteerApi.Infrastructure.Exceptions;
using Budgeteer.Services.BudgeteerApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Budgeteer.Services.BudgeteerApi.Services.Documents;

public class DocumentService : IDocumentService
{
    private readonly BudgeteerDbContext _dbContext;

    public DocumentService(
        BudgeteerDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }

    public async Task UpdateAsync(
        int id,
        Document model,
        CancellationToken cancellationToken
    )
    {
        Document document = await GetByIdAsync(
            model.Id,
            cancellationToken
        );

        document
            .Update(
                model.Name,
                model.Url
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
        Document document = await GetByIdAsync(
            id,
            cancellationToken
        );

        document
            .Delete();

        await _dbContext
            .SaveChangesAsync(
                cancellationToken
            );
    }

    private async Task<Document> GetByIdAsync(
        int id,
        CancellationToken cancellationToken
    )
    {
        Document? document = await _dbContext
            .Document
            .FirstOrDefaultAsync(document =>
                document.Id == id,
                cancellationToken
            );

        if (document is null)
            throw new EntityNotFoundException(
                nameof(Document),
                id
            );

        return document;
    }
}
