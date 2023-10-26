using Microsoft.EntityFrameworkCore;
using WaterLogger.Models;

namespace WaterLogger.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<WaterLog> WaterLogs { get; set; }
}

