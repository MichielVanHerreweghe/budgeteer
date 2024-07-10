using Budgeteer.Services.BudgeteerApi.Domain.Transactions;
using Budgeteer.Services.BudgeteerApi.Shared.Transactions;
using Budgeteer.Services.BudgeteerApi.Infrastructure.Mappers.Documents;
using Budgeteer.Services.BudgeteerApi.Infrastructure.Mappers.Tags;

namespace Budgeteer.Services.BudgeteerApi.Infrastructure.Mappers.Transactions;

public static class TransactionMapper
{
    public static Revenue ToDomainRevenue(
        this TransactionDto.Mutate model
    )
    {
        Revenue transaction = new(
            model.Name,
            model.Amount,
            model.DateOfTransaction
        );

        return transaction;
    }

    public static Expense ToDomainExpense(
        this TransactionDto.Mutate model
    )
    {
        Expense transaction = new(
            model.Name,
            model.Amount,
            model.DateOfTransaction
        );

        return transaction;
    }

    public static TransactionDto.Index ToIndex(
        this Transaction transaction    
    )
    {
        TransactionDto.Index dto = new(
            transaction.Id,
            transaction.Name,
            transaction.Amount,
            transaction.DateOfTransaction,
            transaction.EnclosedDocuments.Select(document => 
                document.ToIndex()
            )
            .ToList(),
            transaction.Tags.Select(tag => 
                tag.ToIndex()
            )
            .ToList()
        );

        return dto;
    }
}
