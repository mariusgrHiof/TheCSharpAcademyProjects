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

        public void Get(int id)
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source=Time.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Hours " +
                    $"FROM log " +
                    $"WHERE Id = {id}";
                command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var logId = reader.GetString(0);
                        var hours = reader.GetString(1);

                        Console.WriteLine($"ID: {logId}, Hours: {hours}");
                    }
                }
            }
        }

        public void GetAll()
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source=Time.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Hours " +
                    $"FROM log";
                command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var logId = reader.GetString(0);
                        var hours = reader.GetString(1);

                        Console.WriteLine($"ID: {logId}, Hours: {hours}");
                    }
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqliteConnection("Data Source = Time.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM log WHERE Id = {id}";


                command.ExecuteNonQuery();
            }
        }


        public void Update(int id, int hours)
        {
            using (var connection = new SqliteConnection("Data Source = Time.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"UPDATE log " +
                    $"SET Hours = {hours} " +
                    $"WHERE Id = {id}";


                command.ExecuteNonQuery();
            }
        }
    }
}
