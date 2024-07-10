using Budgeteer.Services.BudgeteerApi.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeteer.Services.BudgeteerApi.Persistence.Configurations;

internal class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .ToTable(
                typeof(T).Name
            );

        builder
            .HasQueryFilter(x =>
                x.IsEnabled
            );

        builder
            .Property(x => 
                x.IsEnabled
            )
            .IsRequired()
            .HasDefaultValue(true)
            .ValueGeneratedNever();

        builder
            .Property(x => 
                x.CreatedAt
            )
            .HasDefaultValueSql(
                "GETUTCDATE()"
            );

        builder
            .Property(x => 
                x.UpdatedAt
            )
            .HasDefaultValueSql(
                "GETUTCDATE()"
            )
            .IsConcurrencyToken();
    }
}
