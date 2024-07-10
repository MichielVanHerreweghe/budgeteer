using Budgeteer.Services.BudgeteerApi.Domain.Documents;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeteer.Services.BudgeteerApi.Persistence.Configurations.Documents;

internal class DocumentConfiguration : EntityConfiguration<Document>
{
    public override void Configure(
        EntityTypeBuilder<Document> builder
    )
    {
        base
            .Configure(
                builder
            );
    }
}
