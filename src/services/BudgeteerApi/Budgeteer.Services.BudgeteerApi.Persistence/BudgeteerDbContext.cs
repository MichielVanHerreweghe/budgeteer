using Budgeteer.Services.BudgeteerApi.Domain.Books;
using Budgeteer.Services.BudgeteerApi.Domain.Documents;
using Budgeteer.Services.BudgeteerApi.Domain.Tags;
using Budgeteer.Services.BudgeteerApi.Domain.Transactions;
using Budgeteer.Services.BudgeteerApi.Persistence.Triggers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Budgeteer.Services.BudgeteerApi.Persistence;

public class BudgeteerDbContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Document> Document => Set<Document>();
    public DbSet<Tag> Tags => Set<Tag>();

    public BudgeteerDbContext(
        DbContextOptions<BudgeteerDbContext> options
    ) : base(options) 
    {

    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder
    )
    {
        base
            .OnConfiguring(
                optionsBuilder
            );

        optionsBuilder
            .EnableDetailedErrors();

        optionsBuilder
            .EnableSensitiveDataLogging();

        optionsBuilder
            .UseTriggers(options =>
                {
                    options
                        .AddTrigger<EntityBeforeSaveTrigger>();
                }
            );
    }

    protected override void ConfigureConventions(
        ModelConfigurationBuilder configurationBuilder
    )
    {
        configurationBuilder
            .Properties<decimal>()
            .HavePrecision(
                18, 
                2
            );

        configurationBuilder
            .Properties<string>()
            .HaveMaxLength(
                4_000
            );
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder
    )
    {
        base
            .OnModelCreating(
                modelBuilder
            );

        modelBuilder
            .ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
            );
    }
}