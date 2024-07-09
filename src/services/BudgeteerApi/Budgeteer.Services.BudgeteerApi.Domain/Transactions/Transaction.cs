using Budgeteer.Services.BudgeteerApi.Domain.Common;
using Budgeteer.Services.BudgeteerApi.Domain.Documents;
using Budgeteer.Services.BudgeteerApi.Domain.Tags;

namespace Budgeteer.Services.BudgeteerApi.Domain.Transactions;

public class Transaction : Entity
{
    private List<Document> _enclosedDocuments;
    private List<Tag> _tags;

    public string Name { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime DateOfTransaction { get; private set; }

    public IReadOnlyCollection<Document> EnclosedDocuments => _enclosedDocuments
        .AsReadOnly();

    public Transaction(
        string name,
        decimal amount,
        DateTime dateOfTransaction
    )
    {
        Name = Guard
            .Against
            .NullOrWhiteSpace(
                name,
                nameof(name)
            );

        Amount = Guard
            .Against
            .NegativeOrZero(
                amount,
                nameof(amount)
            );

        DateOfTransaction = Guard
            .Against
            .Null(
                dateOfTransaction,
                nameof(dateOfTransaction)
            );

        _enclosedDocuments = new();
        _tags = new();
    }

    public void Update(
        string name,
        decimal amount,
        DateTime dateOfTransaction
    )
    {
        UpdateName(
            name
        );

        UpdateAmount(
            amount
        );

        UpdateDateOfTransaction(
            dateOfTransaction
        );
    }

    private void UpdateName(
        string name    
    )
    {
        Name = Guard
            .Against
            .NullOrEmpty(
                name,
                nameof(name)
            );
    }

    private void UpdateAmount(
        decimal amount
    )
    {
        Amount = Guard
            .Against
            .NegativeOrZero(
                amount,
                nameof(amount)
            );
    }

    private void UpdateDateOfTransaction(
        DateTime dateOfTransaction
    )
    {
        DateOfTransaction = Guard
            .Against
            .Null(
                dateOfTransaction,
                nameof(dateOfTransaction)
            );
    }
}
