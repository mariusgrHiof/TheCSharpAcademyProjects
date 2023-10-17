
using PhoneBook.Data;

PhoneBookDbContext context = new PhoneBookDbContext();

PhoneBookRepository db = new PhoneBookRepository(context);

var contact = db.GetContact(3);

if (contact == null)
{
    Console.WriteLine("Fail to get contact");
}
else
{
    Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}, Phone: {contact.PhoneNumber}");
}