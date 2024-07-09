using Budgeteer.Services.BudgeteerApi.Domain.Common;

namespace Budgeteer.Services.BudgeteerApi.Domain.Tags;

public sealed class Tag : Entity
{
    public string Name { get; private set; }

    public Tag(
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
