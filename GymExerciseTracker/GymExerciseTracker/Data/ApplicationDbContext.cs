using GymExerciseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GymExerciseTracker.Data;
public class ApplicationDbContext : DbContext
{

    public DbSet<GymSession> GymSessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=GymTrackerDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}

