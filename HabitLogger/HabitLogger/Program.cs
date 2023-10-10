


using HabitLogger;


LogService logService = new LogService();

logService.SetupDatabase("Time");

var result = logService.Add(new LogLearningCSharp
{
    Hours = -12,
});

if (result != null)
{
    Console.WriteLine($"{result.Hours} has been logged!");
}