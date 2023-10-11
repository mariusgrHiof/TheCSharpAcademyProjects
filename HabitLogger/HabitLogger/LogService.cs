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

        public List<LogLearningCSharp> GetAll()
        {
            List<LogLearningCSharp> logs = dbManager.GetAll();

            return logs;
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

        public LogLearningCSharp? DeleteLog(int id)
        {
            var log = dbManager.Get(id);
            if (log is null) return null;

            int result = dbManager.Delete(log.Id);
            if (result == 0)
            {
                Console.WriteLine("Failed to delete record.");
                return null;
            }

            return log;


        }
    }
}
