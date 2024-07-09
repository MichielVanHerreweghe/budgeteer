using Budgeteer.Services.BudgeteerApi.Domain.Books;
using Budgeteer.Services.BudgeteerApi.Domain.Transactions;

namespace Budgeteer.Services.BudgeteerApi.Domain.Tests.Books;

public class Book_Should : IDisposable
{
    private Book _book;
    private List<Transaction> _transactions = new()
    {
        new Revenue(
            "Side hustle income",
            500M,
            DateTime.UtcNow
        ),
        new Expense(
            "Fire insurance",
            500M,
            DateTime.UtcNow
        ),
        new Expense(
            "Rent",
            250M,
            DateTime.UtcNow
        )
    };

    public Book_Should()
    {
        _book = new(
            "Test Book"
        );

        foreach (Transaction transaction in _transactions)
        {
            _book
                .AddTransaction(
                    transaction
                );
        }
    }

    public void Dispose()
    {
        _book.ClearTransactions();
    }

    [Fact]
    public void Add_revenue_transaction()
    {
        Revenue revenue = new(
            "Work income",
            2000M,
            DateTime.UtcNow
        );

        _book.AddTransaction(
            revenue
        );

        Transaction result = _book
            .Transactions
            .Last();

        result
            .ShouldBeOfType<Revenue>();
    }

    [Fact]
    public void Add_expense_transaction()
    {
        Expense expense = new(
            "Taxes",
            1000M,
            DateTime.UtcNow
        );

        _book.AddTransaction(
            expense
        );

        Transaction result = _book
            .Transactions
            .Last();

        result
            .ShouldBeOfType<Expense>();
    }

    [Fact]
    public void Only_retrieve_revenues()
    {
        IReadOnlyCollection<Revenue> result = _book
            .Revenues;

        result
            .Count
            .ShouldBe(1);
    }

    [Fact]
    public void Only_retrieve_expense()
    {
        IReadOnlyCollection<Expense> result = _book
            .Expenses;

        result
            .Count
            .ShouldBe(2);
    }
}
