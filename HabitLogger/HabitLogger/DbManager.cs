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

                string queryString = "INSERT INTO log (Hours) VALUES(@Hours)";

                SqliteCommand command = new SqliteCommand(queryString, connection);
                command.Parameters.Add("Hours", SqliteType.Integer, hours).Value = hours;


                try
                {

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public CSharpLog Get(int id)
        {

            int hours = 0;
            using (SqliteConnection connection = new SqliteConnection($"Data Source=Time.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Hours " +
                    $"FROM log " +
                    $"WHERE Id = {id}";
                var result = command.ExecuteScalar();
                if (result is null) return null;

                try
                {
                    hours = Convert.ToInt32(result);
                }
                catch (FormatException ex)
                {

                    Console.WriteLine("Invalid format.");
                }


            }

            return new CSharpLog
            {
                Hours = hours,
                Id = id
            };
        }

        public List<CSharpLog> GetAll()
        {
            List<CSharpLog> logs = new List<CSharpLog>();
            using (SqliteConnection connection = new SqliteConnection($"Data Source=Time.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Hours " +
                    $"FROM log";

                try
                {

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var logId = Convert.ToInt32(reader.GetString(0));
                        var hours = Convert.ToInt32(reader.GetString(1));

                        logs.Add(new CSharpLog
                        {
                            Id = logId,
                            Hours = hours
                        });

                    }
                }
            }

            return logs;
        }

        public int Delete(int id)
        {
            int result = 0;
            using (var connection = new SqliteConnection("Data Source = Time.db"))
            {

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM log WHERE Id = {id}";


                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Fail to delete record.");
                }
            }

            return result;
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
