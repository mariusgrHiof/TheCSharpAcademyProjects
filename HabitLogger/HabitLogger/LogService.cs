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

        public LogLearningCSharp? Add(LogLearningCSharp newLog)
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

        //public LogLearningCSharp Update(int id, LogLearningCSharp updateLog)
        //{

        //}

        //public LogLearningCSharp GetAll()
        //{

        //}

        //public LogLearningCSharp Get(int id)
        //{

        //}

        //public LogLearningCSharp Delete(int id)
        //{

        //}
    }
}
