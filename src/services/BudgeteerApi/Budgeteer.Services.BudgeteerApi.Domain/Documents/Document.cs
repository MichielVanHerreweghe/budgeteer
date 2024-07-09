using Budgeteer.Services.BudgeteerApi.Domain.Common;

namespace Budgeteer.Services.BudgeteerApi.Domain.Documents;

public sealed class Document : Entity
{
    public string Name { get; private set; }
    public string Url { get; private set; }

    public Document(
        string name,
        string url
    )
    {
        Name = Guard
            .Against
            .NullOrWhiteSpace(
                name,
                nameof(name)
            );

        Url = Guard
            .Against
            .NullOrWhiteSpace(
                url,
                nameof(url)
            );
    }

    public void Update(
        string name,
        string url
    )
    {
        UpdateName(
            name
        );

        UpdateUrl
        (
            url
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

    private void UpdateUrl(
        string url
    )
    {
        Url = Guard
            .Against
            .NullOrWhiteSpace(
                url,
                nameof(url)
            );
    }
}
