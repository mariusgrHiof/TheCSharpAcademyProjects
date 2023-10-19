﻿using ConsoleTableExt;
using ShiftsLogger.API.DTOs.Shift;
using System.Net.Http.Json;
using System.Text.Json;

namespace ShiftsLogger.UI
{
    public static class UI
    {
        public static void Start()
        {
            HttpClient client = new HttpClient();


            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("\nMain Menu");
                Console.WriteLine("---------\n");
                Console.WriteLine("What would you like to do?\n");
                Console.WriteLine("Type 1 to View all Shifts");
                Console.WriteLine("Type 2 to Insert Shift");
                Console.WriteLine("Type 3 to Delete a Shift");
                Console.WriteLine("Type 4 to Update a Shift\n");
                Console.WriteLine("Type 0 to Close Application");
                Console.WriteLine("---------------------------\n");

                Console.Write(">");
                string? command = Console.ReadLine();

                switch (command)
                {
                    case "0":
                        keepGoing = false;
                        break;
                    case "1":
                        GetAllShifts();
                        break;
                    case "2":
                        InsertShift();
                        break;
                    case "3":
                        DeleteShift();
                        break;
                    case "4":
                        UpdateShift();
                        break;
                    default:
                        Console.WriteLine("Invalid command.Try again.");
                        break;
                }

            }

            void UpdateShift()
            {

                var endpoint = new Uri("https://localhost:7184/api/ShiftsLogger");
                string shiftId = GetShiftId();

                var result = client.GetAsync($"{endpoint}/{shiftId}").Result;

                while (!result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Invlaid id. Try again.");
                    shiftId = GetShiftId();

                    result = client.GetAsync($"{endpoint}/{shiftId}").Result;
                }

                var json = result.Content.ReadAsStringAsync().Result;

                UpdateShiftDTO? updateShift = JsonSerializer.Deserialize<UpdateShiftDTO>(json);

                string? startDate = GetStartDate();
                if (startDate == null) CloseApp();

                string? endDate = GetEndDate();

                while (!Validate.IsValidDateRange(DateTime.Parse(startDate), DateTime.Parse(endDate)))
                {
                    Console.WriteLine("Not a valid end date. Try again.");
                    endDate = GetEndDate();
                }

                string? workerId = GetWorkerId();

                updateShift.Id = int.Parse(shiftId);
                updateShift.Start = DateTime.Parse(startDate);
                updateShift.End = DateTime.Parse(endDate);
                updateShift.WorkerId = int.Parse(workerId);



                JsonContent content = JsonContent.Create(updateShift);

                var updatedContact = client.PutAsync($"{endpoint}/{shiftId}", content);

                if (updatedContact != null)
                {
                    Console.WriteLine("Record updated!");
                }
                else
                {
                    Console.WriteLine("Error: Fail to update record!");
                }
            }


            void DeleteShift()
            {
                var endpoint = new Uri("https://localhost:7184/api/ShiftsLogger");

                string? shiftId = GetShiftId();

                var result = client.GetAsync($"{endpoint}/{shiftId}").Result;

                while (!result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Invlaid id. Try again.");
                    shiftId = GetShiftId();

                    result = client.GetAsync($"{endpoint}/{shiftId}").Result;
                }




                var deleteContact = client.DeleteAsync($"{endpoint}/{shiftId}");

                if (deleteContact != null)
                {
                    Console.WriteLine("Record deleted!");
                }
                else
                {
                    Console.WriteLine("Error: Fail to delete record!");
                }

            }

            void InsertShift()
            {
                var endpoint = new Uri("https://localhost:7184/api/ShiftsLogger");

                string? startDate = GetStartDate();
                if (startDate == null) CloseApp();

                string? endDate = GetEndDate();

                while (!Validate.IsValidDateRange(DateTime.Parse(startDate), DateTime.Parse(endDate)))
                {
                    Console.WriteLine("Not a valid end date. Try again.");
                    endDate = GetEndDate();
                }

                string? workerId = GetWorkerId();


                var newShift = new AddShiftDTO
                {
                    Start = DateTime.Parse(startDate),
                    End = DateTime.Parse(endDate),
                    WorkerId = int.Parse(workerId)

                };

                JsonContent content = JsonContent.Create(newShift);

                var insertRecord = client.PostAsync($"{endpoint}", content);

                if (insertRecord == null)
                {
                    Console.WriteLine("Fail to insert record to db");
                }
                else
                {

                    Console.WriteLine("Record inserted to db");
                }


            }

            void GetAllShifts()
            {
                var tableData = new List<List<object>>();
                var endpoint = new Uri("https://localhost:7184/api/ShiftsLogger");
                var result = client.GetAsync(endpoint).Result;

                if (result.IsSuccessStatusCode)
                {
                    var json = result.Content.ReadAsStringAsync().Result;

                    List<UpdateShiftDTO>? shifts = JsonSerializer.Deserialize<List<UpdateShiftDTO>>(json);

                    if (shifts != null && shifts.Count > 0)
                    {
                        foreach (UpdateShiftDTO shift in shifts)
                        {
                            tableData.Add(new List<object> { shift.Start, shift.End, shift.WorkerId });
                        }

                    }

                    ConsoleTableBuilder
                    .From(tableData)
                    .WithColumn("Start Date", "End Date", "Worker Id")
                    .ExportAndWriteLine();
                }
            }

            string? GetStartDate()
            {
                Console.Write("Enter start date: ");
                string? startDate = Console.ReadLine()?.Trim();
                if (startDate == "0") return null;

                while (!Validate.IsValidateDate(startDate))
                {
                    Console.WriteLine("Invalid date.Try again.");
                    Console.Write("Enter your start date: ");
                    startDate = Console.ReadLine();
                }

                return startDate;
            }

            string? GetEndDate()
            {
                Console.Write("Enter end date: ");
                string? endDate = Console.ReadLine()?.Trim();
                if (endDate == "0") return null;

                while (!Validate.IsValidateDate(endDate))
                {
                    Console.WriteLine("Invalid date.Try again.");
                    Console.Write("Enter your end date: ");
                    endDate = Console.ReadLine();
                }

                return endDate;
            }

            string GetWorkerId()
            {
                Console.Write("Enter an id: ");
                string? input = Console.ReadLine();

                while (!Validate.IsValidString(input) || !Validate.IsValidWorkerId(input))
                {
                    Console.WriteLine("Invalid id.Try again.");
                    Console.Write("Enter an id: ");
                    input = Console.ReadLine();
                }

                return input;
            }

            string GetShiftId()
            {
                Console.Write("Enter a shift id: ");
                string? input = Console.ReadLine();

                while (!Validate.IsValidString(input) || !Validate.IsValidShiftId(input))
                {
                    Console.WriteLine("Invalid id.Try again.");
                    Console.Write("Enter an id: ");
                    input = Console.ReadLine();
                }

                return input;
            }

            void CloseApp()
            {
                keepGoing = false;

            }
        }
    }
}