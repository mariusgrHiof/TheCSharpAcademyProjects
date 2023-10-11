


using HabitLogger;

LogService logService = new LogService();

logService.SetupDatabase("Time");

UI ui = new UI(logService);
ui.Start();
