using Budgeteer.Services.BudgeteerApi.Domain.Tags;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeteer.Services.BudgeteerApi.Persistence.Configurations.Tags;

internal class TagConfiguration : EntityConfiguration<Tag>
{
    public override void Configure(
        EntityTypeBuilder<Tag> builder
    )
    {
        base
            .Configure(
                builder
            );
    }
}
