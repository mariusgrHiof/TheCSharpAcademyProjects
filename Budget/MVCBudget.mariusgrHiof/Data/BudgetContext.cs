using Microsoft.EntityFrameworkCore;
using MVCBudget.mariusgrHiof.Models;

namespace MVCBudget.mariusgrHiof.Data;

public class BudgetContext : DbContext
{
    public BudgetContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                Id = 1,
                Name = "Car Parts",
                Description = "Car parts",
            },
            new Category()
            {
                Id = 2,
                Name = "Car Parts",
                Description = "Car parts",
            }
            );

        modelBuilder.Entity<Transaction>().HasData(
            new Transaction()
            {
                Id = 1,
                Name = "Induction Kit",
                Amount = 2500,
                CategoryId = 1,
                Date = new DateTime(2023, 5, 4),
            },
            new Transaction()
            {
                Id = 2,
                Name = "Milltek Exhaust",
                Amount = 22500,
                CategoryId = 1,
                Date = new DateTime(2022, 5, 4),
            }
            );
    }
}
