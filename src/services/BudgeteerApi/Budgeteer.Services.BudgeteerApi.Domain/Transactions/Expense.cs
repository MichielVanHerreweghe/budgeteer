namespace Budgeteer.Services.BudgeteerApi.Domain.Transactions;

public sealed class Expense : Transaction
{
    public Expense(
        string name,
        decimal amount,
        DateTime dateOfTransaction
    ) : base(
        name,
        amount,
        dateOfTransaction
    )
    {

    }
}
