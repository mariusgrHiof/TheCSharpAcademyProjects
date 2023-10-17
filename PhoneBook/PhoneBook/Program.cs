
using ConsoleTableExt;
using PhoneBook.Data;
using PhoneBook.Models;
using PhoneBook.Utils;

PhoneBookDbContext context = new PhoneBookDbContext();

PhoneBookRepository db = new PhoneBookRepository(context);


bool keepGoing = true;
while (keepGoing)
{
    Console.WriteLine("\nMain Menu");
    Console.WriteLine("---------\n");
    Console.WriteLine("What would you like to do?\n");
    Console.WriteLine("Type 1 to View all Contacts");
    Console.WriteLine("Type 2 to Insert Contacts");
    Console.WriteLine("Type 3 to Delete a Contact");
    Console.WriteLine("Type 4 to Update a Contact\n");
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
            GetAllContacts();
            break;
        case "2":
            InsertContact();
            break;
        case "3":
            DeleteContact();
            break;
        case "4":
            UpdateContact();
            break;
        default:
            Console.WriteLine("Invalid command.Try again.");
            break;
    }

}

void UpdateContact()
{
    Console.Write("Enter an id: ");
    string? input = Console.ReadLine();

    while (input == null)
    {
        Console.WriteLine("Invalid id.Try again.");
        Console.Write("Enter an id: ");
        input = Console.ReadLine();
    }


    while (!Validate.IsValidNumber(input))
    {
        Console.WriteLine("Invalid try again.");
        Console.Write("Enter an id: ");
        input = Console.ReadLine();
    }

    int id = int.Parse(input);



    Console.Write("Enter your name: ");
    string? name = Console.ReadLine()?.Trim();

    while (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Invalid name.Try again.");
        Console.Write("Enter your name: ");
        name = Console.ReadLine();
    }

    Console.Write("Enter your email: ");
    string? email = Console.ReadLine()?.Trim();

    while (string.IsNullOrWhiteSpace(email) || !Validate.IsValidEmail(email))
    {
        Console.WriteLine("Invalid name.Try again.");
        Console.Write("Enter your email: ");
        email = Console.ReadLine();
    }

    Console.Write("Enter your phone number: ");
    string? phoneNumber = Console.ReadLine()?.Trim();

    while (string.IsNullOrWhiteSpace(phoneNumber))
    {
        Console.WriteLine("Invalid phoneNumber.Try again.");
        Console.Write("Enter your phone number: ");
        phoneNumber = Console.ReadLine();
    }



    db.UpdateContact(id, new Contact
    {
        Id = id,
        Name = name,
        Email = email,
        PhoneNumber = phoneNumber
    });
}

void DeleteContact()
{
    Console.Write("Enter an id: ");
    string? input = Console.ReadLine();

    while (input == null)
    {
        Console.WriteLine("Invalid id.Try again.");
        Console.Write("Enter an id: ");
        input = Console.ReadLine();
    }


    while (!Validate.IsValidNumber(input))
    {
        Console.WriteLine("Invalid try again.");
        Console.Write("Enter an id: ");
        input = Console.ReadLine();
    }

    int id = int.Parse(input);

    var contact = db.GetContact(id);


    db.DeleteContact(id);

}

void InsertContact()
{
    Console.Write("Enter your name: ");
    string? name = Console.ReadLine()?.Trim();

    while (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Invalid name.Try again.");
        Console.Write("Enter your name: ");
        name = Console.ReadLine();
    }

    Console.Write("Enter your email: ");
    string? email = Console.ReadLine()?.Trim();

    while (string.IsNullOrWhiteSpace(email) || !Validate.IsValidEmail(email))
    {
        Console.WriteLine("Invalid name.Try again.");
        Console.Write("Enter your email: ");
        email = Console.ReadLine();
    }

    Console.Write("Enter your phone number: ");
    string? phoneNumber = Console.ReadLine()?.Trim();

    while (string.IsNullOrWhiteSpace(phoneNumber))
    {
        Console.WriteLine("Invalid phoneNumber.Try again.");
        Console.Write("Enter your phone number: ");
        phoneNumber = Console.ReadLine();
    }

    var insertRecord = db.AddContact(new PhoneBook.DTOs.ContactDTO
    {
        Email = email,
        PhoneNumber = phoneNumber,
        Name = name,

    });

    if (insertRecord == null)
    {
        Console.WriteLine("Fail to insert record to db");
    }
    else
    {

        Console.WriteLine("Record inserted to db");
    }


}

void GetAllContacts()
{
    var tableData = new List<List<object>>();
    var contacts = db.GetContacts();

    foreach (var contact in contacts)
    {
        tableData.Add(new List<object> { contact.Id, contact.Name, contact.Email, contact.PhoneNumber });
    }

    ConsoleTableBuilder
    .From(tableData)
    .WithColumn("Id", "Name", "Email", "Phone Number")
    .ExportAndWriteLine();
}