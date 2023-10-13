﻿using CodingTracker.Models;
using Microsoft.Data.Sqlite;
using System.Configuration;

namespace CodingTracker.Data
{
    public class DbManager
    {
        private readonly string? _connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");


        public void CreateDb()
        {

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS log
                        (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                         StartTime TEXT NOT NULL,
                         EndTime TEXT NOT NULL)";

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

        public CodingSession Add(CodingSession session)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var queryString = "INSERT INTO log (StartTime, EndTime) VALUES(@StartTime,@EndTime)";

                var command = new SqliteCommand(queryString, connection);

                command.Parameters.Add("StartTime", SqliteType.Text).Value = session.StartTime;
                command.Parameters.Add("EndTime", SqliteType.Text).Value = session.EndTime;


                try
                {

                    command.ExecuteNonQuery();

                    return new CodingSession(session.StartTime, session.EndTime);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }


            }
        }

        public CodingSession? Update(int id, CodingSession session)
        {

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var queryString = "UPDATE log SET StartTime = @StartTime, EndTime = @EndTime WHERE Id = @Id";

                var command = new SqliteCommand(queryString, connection);
                command.Parameters.Add("Id", SqliteType.Integer).Value = id;
                command.Parameters.Add("StartTime", SqliteType.Text).Value = session.StartTime;
                command.Parameters.Add("EndTime", SqliteType.Text).Value = session.EndTime;


                try
                {

                    command.ExecuteNonQuery();

                    return new CodingSession(session.StartTime, session.EndTime);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }


            }


        }

        public CodingSession? Get(int id)
        {
            string startTime = string.Empty;
            string endTime = string.Empty;

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var queryString = "SELECT Id, StartTime, EndTime FROM log WHERE Id = @Id";

                var command = new SqliteCommand(queryString, connection);
                command.Parameters.Add("Id", SqliteType.Integer).Value = id;



                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows == false) return null;
                    while (reader.Read())
                    {
                        startTime = reader.GetString(1);
                        endTime = reader.GetString(2);


                    }
                }

            }

            return new CodingSession(startTime, endTime);



        }
        public List<CodingSession> GetAll()
        {
            string startTime = string.Empty;
            string endTime = string.Empty;
            List<CodingSession> sessions = new List<CodingSession>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var queryString = "SELECT Id, StartTime, EndTime FROM log";

                var command = new SqliteCommand(queryString, connection);




                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows == false) return null;
                    while (reader.Read())
                    {
                        startTime = reader.GetString(1);
                        endTime = reader.GetString(2);

                        sessions.Add(new CodingSession(startTime, endTime));


                    }
                }
            }

            return sessions;
        }

        public CodingSession? Delete(int id)
        {
            string startTime = string.Empty;
            string endTime = string.Empty;

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var session = Get(id);
                if (session == null) return null;

                var queryString = "DELETE FROM log WHERE Id = @Id";

                var command = new SqliteCommand(queryString, connection);
                command.Parameters.Add("Id", SqliteType.Integer).Value = id;


                try
                {

                    command.ExecuteNonQuery();

                    return new CodingSession(session.StartTime, session.EndTime);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }


            }

        }
    }
}
