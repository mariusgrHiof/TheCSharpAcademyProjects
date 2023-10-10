namespace HabitLogger
{
    public class LogService
    {
        // DbManager 
        DbManager dbManager = new DbManager();

        public void SetupDatabase(string dbName)
        {
            dbManager.CreateDb(dbName);
        }

        public LogLearningCSharp? AddLog(LogLearningCSharp newLog)
        {
            if (newLog != null && newLog.Hours > 0)
            {
                dbManager.Add(newLog.Hours);
            }
            else
            {
                return null;
            }

            return newLog;
        }

        public LogLearningCSharp Update(int id, LogLearningCSharp updateLog)
        {
            if (updateLog != null && updateLog.Hours > 0)
            {
                dbManager.Update(id, updateLog.Hours);
                Console.WriteLine("Log has been updated!");
            }
            else
            {
                return null;
            }



            return updateLog;
        }

        public void GetAll()
        {
            dbManager.GetAll();
        }

        public void GetLog()
        {
            bool keepGoing = true;

            while (keepGoing)
            {

                try
                {
                    Console.Write("Enter an id to get log(type 0 to quit):");
                    string input = Console.ReadLine();
                    int inputId = Convert.ToInt32(input);

                    if (inputId == 0)
                    {
                        keepGoing = false;
                        break;
                    }

                    dbManager.Get(inputId);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter a valid id");
                }

            }

        }

        public void DeleteLog()
        {
            bool keepGoing = true;

            while (keepGoing)
            {

                try
                {
                    Console.Write("Enter an id to delete(type 0 to quit):");
                    string input = Console.ReadLine();
                    int inputId = Convert.ToInt32(input);

                    if (inputId == 0)
                    {
                        keepGoing = false;
                        break;
                    }

                    dbManager.Delete(inputId);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter a valid id");
                }




            }
        }
    }
}
