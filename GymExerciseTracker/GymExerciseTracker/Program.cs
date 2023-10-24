using GymExerciseTracker.Controllers;
using GymExerciseTracker.Data;
using GymExerciseTracker.Repository;
using GymExerciseTracker.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        // Register your services here.
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer("Server=.;Database=GymTrackerDb;Trusted_Connection=True;TrustServerCertificate=True");
        });
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddScoped<IExerciseService, ExerciseService>();

    });

var host = builder.Build();

// Run your application here.
var serviceProvider = host.Services;

// Retrieve services from the DI container.
var exerciseService = serviceProvider.GetRequiredService<IExerciseService>();

ExerciseController controller = new ExerciseController(exerciseService);

/*var newSession = controller.AddGymSession(new GymExerciseTracker.Dtos.AddGymSessionDto
{
    Name = "Delete this",
    Sets = 5,
    Reps = 13,
    Comments = "tjaaa",
    StartDate = DateTime.Now,
    EndDate = DateTime.Now,
});

if (newSession == null)
{
    Console.WriteLine("Fail to add exercise.");
}
else
{
    Console.WriteLine($"{newSession.Name} has been added.");
}*/

/*var updateSession = controller.UpdateGymSession(2, new GymExerciseTracker.Dtos.UpdateGymSessionDto
{
    Id = 2,
    Name = "Hantler update",
    Sets = 7,
    Reps = 20,
    Comments = "Hardt å komme tilbake :)",
    StartDate = DateTime.Now,
    EndDate = DateTime.Now,
});

if (updateSession == null)
{
    Console.WriteLine("Fail to update exercise.");
}
else
{
    Console.WriteLine($"{updateSession.Name} has been updated.");
}*/


var deleteSession = controller.DeleteGymSession(3);

if (deleteSession == null)
{
    Console.WriteLine("Fail to delete exercise.");
}
else
{
    Console.WriteLine($"{deleteSession.Name} has been updated.");
}

var gymSessions = controller.GetAllGymSessions();

foreach (var session in gymSessions)
{
    Console.WriteLine(session.Name);
}

host.Run();