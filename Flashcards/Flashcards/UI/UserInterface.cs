using Flashcards.Controllers;
using Spectre.Console;

namespace Flashcards.UI;

public class UserInterface
{
    private readonly StacksController _controller;

    public UserInterface(StacksController controller)
    {
        _controller = controller;
    }


    public void Run()
    {
        AnsiConsole.Write(
        new FigletText("Flashcards")
        .LeftJustified()
        .Color(Color.Blue));

        bool keepGoing = true;
        while (keepGoing)
        {
            ShowMainMenu();

            Console.Write("Enter a number: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Exit");
                    keepGoing = false;
                    break;
                case "2":
                    while (true)
                    {
                        ShowManageStacksMenu();
                        Console.WriteLine("Input a current stack name\n or input 0 to exit input.");
                        string stackNameInput = Console.ReadLine();
                        if (stackNameInput == "0")
                        {
                            break;
                        }
                        Console.WriteLine($"Input: {stackNameInput}");
                    }

                    break;
                case "3":
                    while (true)
                    {
                        ShowManageFlashcardsMenu();
                        Console.WriteLine("Choose a stack of flashcards to interact with: ");
                        Console.WriteLine("Input a current stack name\n or input 0 to exit input.");
                        string stackNameInput = Console.ReadLine();
                        if (stackNameInput == "0")
                        {
                            break;
                        }
                        Console.WriteLine($"Input: {stackNameInput}");
                    }
                    break;
                case "4":
                    Console.WriteLine("Study");
                    break;
                case "5":
                    Console.WriteLine("View study session data");
                    break;
                default:
                    Console.WriteLine("Invalid input.Try again.");
                    break;
            }
        }
    }



    private void ShowMainMenu()
    {
        var table = new Table();

        table.AddColumn("Main Menu");

        table.AddRow("1. Exit");
        table.AddRow("2. Manage stacks");
        table.AddRow("3. Manage flashcards");
        table.AddRow("4. Study");
        table.AddRow("5. View study session data");

        AnsiConsole.Write(table);
    }

    private void ShowManageStacksMenu()
    {
        var table = new Table();

        table.AddColumn("Manage stacks");

        table.AddRow("CSharp");
        table.AddRow("SQL");
        table.AddRow(".NET");
        table.AddRow("Azure");

        AnsiConsole.Write(table);
    }

    private void ShowManageFlashcardsMenu()
    {
        var table = new Table();

        table.AddColumn("Manage flashcards");

        table.AddRow("CSharp");
        table.AddRow("SQL");
        table.AddRow(".NET");
        table.AddRow("Azure");

        AnsiConsole.Write(table);
    }
}

