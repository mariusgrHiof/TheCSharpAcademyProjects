
using PhoneBook.Data;
using PhoneBook.Models;
using PhoneBook.Utils;

PhoneBookDbContext context = new PhoneBookDbContext();

PhoneBookRepository db = new PhoneBookRepository(context);

List<Contact> contacts = db.GetContacts();

foreach (var contact in contacts)
{
    Console.WriteLine(contact.Name);
}

string email = "update@gmail.com";

if (!Validate.IsValidEmail(email))
{
    Console.WriteLine("Invalid email");
}
else
{
    db.UpdateContact(5, new Contact
    {
        Id = 5,
        Name
        Email = email,
        PhoneNumber = "43908543895"
    });
}