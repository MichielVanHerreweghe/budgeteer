namespace Budgeteer.Services.BudgeteerApi.Domain.Transactions;

/// <summary>
/// Used as a discriminator in EF Core for the transaction entity.
/// </summary>
public enum TransactionType
{
    Revenue,
    Expense
}
