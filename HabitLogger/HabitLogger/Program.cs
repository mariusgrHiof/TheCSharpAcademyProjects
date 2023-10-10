


using HabitLogger;


LogService logService = new LogService();

logService.SetupDatabase("Time");

//var result = logService.AddLog(new LogLearningCSharp
//{
//    Hours = 125,
//});

//if (result != null)
//{
//    Console.WriteLine($"{result.Hours} has been logged!");
//}

logService.Update(5, new LogLearningCSharp
{
    Hours = 3437,
});