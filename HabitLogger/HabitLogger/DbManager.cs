using Microsoft.Data.Sqlite;

namespace HabitLogger
{
    public class DbManager
    {
        public void CreateDb(string dbName)
        {
            if (!string.IsNullOrEmpty(dbName))
            {
                using (SqliteConnection connection = new SqliteConnection($"Data Source={dbName}.db"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = @"CREATE TABLE IF NOT EXISTS log
                        (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                         Hours INT NOT NULL)";
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("Invlaid db name");
            }

        }

        public void Add(int hours)
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source=Time.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO log (Hours) VALUES({hours})";
                command.ExecuteNonQuery();
            }
        }
    }
}
