namespace HabitLogger
{
    public class UI
    {
        private readonly LogService _logService;

        public UI(LogService logService)
        {
            _logService = logService;
        }


        public void Start()
        {
            bool keepGoing = true;
            while (keepGoing)
            {

                PrintMenu();

                string userInput = GetUserInput("Enter a number: ");

                switch (userInput)
                {
                    case "0":
                        Console.WriteLine("Closing app..");
                        keepGoing = false;
                        break;
                    case "1":
                        var logs = _logService.GetAll();
                        PrintAllLogs(logs);
                        break;
                    case "2":
                        var number = GetNumberInput("Enter hour: ");
                        _logService.AddLog(new CSharpLog
                        {
                            Hours = number,
                        });
                        break;
                    case "3":
                        int input = GetIdInput();
                        var log = _logService.GetLog(input);
                        if (log is null)
                        {
                            Console.WriteLine("No log found.");
                            break;
                        }
                        var update = GetNumberInput("Enter updated hour: ");
                        _logService.Update(log.Id, new CSharpLog
                        {
                            Hours = update
                        });
                        break;
                    case "4":
                        var deleteLogId = GetIdInput();
                        var deleteLog = _logService.GetLog(deleteLogId);
                        if (deleteLog is null)
                        {
                            Console.WriteLine("No log found.");
                            break;
                        }
                        _logService.DeleteLog(deleteLogId);
                        break;
                    default:
                        Console.WriteLine("Invalid number.Try again.");
                        break;
                }
            }




        }


        public void PrintAllLogs(List<CSharpLog> logs)
        {
            foreach (var log in logs)
            {
                Console.WriteLine($"Id: {log.Id} Hours: {log.Hours}");
            }
        }

        public void PrintLog(CSharpLog log)
        {
            Console.WriteLine($"Id: {log.Id} Hours: {log.Hours}");
        }



        string? GetUserInput(string message)
        {


            Console.Write(message);
            string userInput = Console.ReadLine();

            return userInput;
        }

        int GetNumberInput(string message)
        {
            int numberinput = 0;

            while (true)
            {
                try
                {
                    numberinput = Convert.ToInt32(GetUserInput(message));
                    break;
                }
                catch (FormatException ex)
                {

                    Console.WriteLine("Invalid number: Try again");
                }
            }

            return numberinput;
        }

        int GetIdInput()
        {
            int idInput = 0;

            while (true)
            {
                try
                {
                    idInput = Convert.ToInt32(GetUserInput("Enter id: "));
                    break;
                }
                catch (FormatException ex)
                {

                    Console.WriteLine("Invalid number: Try again");
                }
            }

            return idInput;
        }


        void PrintMenu()
        {

            Console.WriteLine(@"
What would you like to do?
    
Type 0 to Close Application.
Type 1 to View All Records.
Type 2 to Insert Record.
Type 3 to Update Record.
Type 4 to Delete Record");
        }
    }
}
