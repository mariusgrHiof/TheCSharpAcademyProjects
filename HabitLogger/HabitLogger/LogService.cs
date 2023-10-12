﻿namespace HabitLogger
{
    public class LogService
    {
        // DbManager 
        DbManager dbManager = new DbManager();

        public void SetupDatabase(string dbName)
        {
            dbManager.CreateDb(dbName);
        }

        public CSharpLog? AddLog(CSharpLog newLog)
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

        public CSharpLog Update(int id, CSharpLog updateLog)
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

        public CSharpLog GetLog(int id)
        {
            var log = dbManager.Get(id);
            if (log == null) return null;

            return log;
        }

        public List<CSharpLog> GetAll()
        {
            List<CSharpLog> logs = dbManager.GetAll();

            return logs;
        }


        public CSharpLog? DeleteLog(int id)
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
