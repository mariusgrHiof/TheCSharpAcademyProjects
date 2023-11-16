using Flashcards.Models;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Data;

public class FlashcardsDbContext : DbContext
{
    public FlashcardsDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Stack> Stacks { get; set; }
}

