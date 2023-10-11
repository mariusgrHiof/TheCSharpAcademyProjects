namespace HabitLogger
{
    public class UI
    {
        private readonly LogService _logService;

        public UI(LogService logService)
        {
            _logService = logService;
        }

        public void PrintAllLogs(List<LogLearningCSharp> logs)
        {
            foreach (var log in logs)
            {
                Console.WriteLine($"Id: {log.Id} Hours: {log.Hours}");
            }
        }

        public void PrintLog(LogLearningCSharp log)
        {
            Console.WriteLine($"Id: {log.Id} Hours: {log.Hours}");
        }

        public void Start()
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine(@"MAIN MENU

What would you like to do?
    
Type 0 to Close Application.
Type 1 to View All Records.
Type 2 to Insert Record.
Type 3 to Delete Record.
Type 4 to Update Record");

                int choice = 0;
                bool validInput = false;
                while (validInput == false)
                {
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        validInput = true;
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Enter a valid input");
                    }

                }


                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Closing Application...");
                        keepGoing = false;
                        break;
                    case 1:
                        var logs = _logService.GetAll();
                        PrintAllLogs(logs);
                        break;
                    case 2:
                        Console.Write("Enter log hours(0 to go back to main menu): ");
                        int hours = GetUserInput();
                        if (hours == 0)
                        {
                            continue;
                        }
                        _logService.AddLog(new LogLearningCSharp { Hours = hours });
                        break;
                    case 3:
                        while (true)
                        {
                            Console.Write("Enter id(0 to go back to main menu): ");
                            int id = GetUserInput();
                            if (id == 0)
                            {
                                continue;
                            }
                            var deleteLog = _logService.DeleteLog(id);
                            if (deleteLog == null)
                            {
                                Console.WriteLine("Enter a valid id.");
                            }
                            else
                            {
                                break;
                            }
                        }


                        break;
                    default:
                        break;
                }
            }

            int GetUserInput()
            {

                int hours = 0;
                bool keepGoing = true;

                while (keepGoing)
                {

                    string input = Console.ReadLine();
                    try
                    {
                        hours = Convert.ToInt32((input));
                        keepGoing = false;

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Enter a valid input");
                    }
                }



                return hours;
            }
        }
    }
}
