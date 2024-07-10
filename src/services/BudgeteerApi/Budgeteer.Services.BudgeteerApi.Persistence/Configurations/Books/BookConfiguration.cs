using Budgeteer.Services.BudgeteerApi.Domain.Books;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeteer.Services.BudgeteerApi.Persistence.Configurations.Books;

internal class BookConfiguration : EntityConfiguration<Book>
{
    public override void Configure(
        EntityTypeBuilder<Book> builder
    )
    {
        base
            .Configure(
                builder
            );

        builder
            .HasMany(book =>
                book.Transactions
            );

        builder
            .Ignore(book =>
                book.Revenues
            );

        builder
            .Ignore(book =>
                book.Expenses
            );
    }
}
