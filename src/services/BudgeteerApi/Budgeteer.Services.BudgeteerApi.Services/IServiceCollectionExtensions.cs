using Budgeteer.Services.BudgeteerApi.Services.Books;
using Budgeteer.Services.BudgeteerApi.Services.Documents;
using Budgeteer.Services.BudgeteerApi.Services.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace Budgeteer.Services.BudgeteerApi.Services;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddBudgeteerApiServices(
        this IServiceCollection services
    )
    {
        services
            .AddScoped<IBookService, BookService>();

        services
            .AddScoped<ITransactionService, TransactionService>();

        services
            .AddScoped<IDocumentService, DocumentService>();

        return services;
    }
}
