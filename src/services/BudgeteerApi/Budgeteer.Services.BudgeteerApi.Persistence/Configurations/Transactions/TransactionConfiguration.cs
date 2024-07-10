using Budgeteer.Services.BudgeteerApi.Domain.Transactions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeteer.Services.BudgeteerApi.Persistence.Configurations.Transactions;

internal class TransactionConfiguration : EntityConfiguration<Transaction>
{
    public override void Configure(
        EntityTypeBuilder<Transaction> builder
    )
    {
        base
            .Configure(
                builder
            );

        builder
            .HasDiscriminator<TransactionType>(
                nameof(TransactionType)
            )
            .HasValue<Revenue>(
                TransactionType.Revenue
            )
            .HasValue<Expense>(
                TransactionType.Expense
            );

        builder
            .HasMany(transaction =>
                transaction.EnclosedDocuments
            )
            .WithOne();

        builder
            .HasMany(transaction =>
                transaction.Tags
            )
            .WithMany();
    }
}
