namespace MVCBudget.Data;


using Microsoft.EntityFrameworkCore;
using MVCBudget.Models;

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
            },
            new Category()
            {
                Id = 2,
                Name = "Electronic",
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
            },
            new Transaction()
            {
                Id = 3,
                Name = "Samsung TV",
                Amount = 10000,
                CategoryId = 2,
                Date = new DateTime(2021, 1, 24)
            }
            );
    }
}
