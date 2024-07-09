using Budgeteer.Services.BudgeteerApi.Domain.Common;
using Budgeteer.Services.BudgeteerApi.Domain.Transactions;

namespace Budgeteer.Services.BudgeteerApi.Domain.Books;

public sealed class Book : Entity
{
    private List<Transaction> _transactions;

    public string Name { get; private set; }

    public IReadOnlyCollection<Transaction> Transactions => _transactions
        .AsReadOnly();

    public IReadOnlyCollection<Revenue> Revenues => _transactions
        .Where(transaction => 
            transaction.GetType() == typeof(Revenue)
        )
        .Select(transaction =>
            (Revenue)transaction
        )
        .ToList()
        .AsReadOnly();

    public IReadOnlyCollection<Expense> Expenses => _transactions
        .Where(transaction =>
            transaction.GetType() == typeof(Expense)
        )
        .Select(transaction =>
            (Expense)transaction
        )
        .ToList()
        .AsReadOnly();

    public decimal TotalAmountOfRevenues => Revenues
        .Sum(revenue =>
            revenue.Amount
        );

    public decimal TotalAmountOfExpenses => Expenses
        .Sum(expense =>
            expense.Amount
        );

    public decimal ResultAmount => TotalAmountOfRevenues - TotalAmountOfExpenses;

    public Book(
        string name
    )
    {
        Name = Guard
            .Against
            .NullOrWhiteSpace(
                name,
                nameof(name)
            );

        _transactions = new();
    }

    public void AddTransaction(
        Transaction transaction
    )
    {
        _transactions
            .Add(
                transaction
            );
    }

    /// <summary>
    /// Method to clear all transactions from the book.
    /// ONLY FOR TEST PURPOSES.
    /// </summary>
    public void ClearTransactions()
    {
        _transactions = new();
    }

    public void Update(
        string name    
    )
    {
        UpdateName(
            name
        );
    }

    private void UpdateName(
        string name
    )
    {
        Name = Guard
            .Against
            .NullOrWhiteSpace(
                name,
                nameof(name)
            );
    }
}
