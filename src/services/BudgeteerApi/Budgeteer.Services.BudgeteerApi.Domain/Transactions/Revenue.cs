namespace Budgeteer.Services.BudgeteerApi.Domain.Transactions;

public sealed class Revenue : Transaction
{
    public Revenue(
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
