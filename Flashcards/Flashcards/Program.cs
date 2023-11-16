using Flashcards.Data;
using Flashcards.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

// Retrieve the connection string
string connectionString = configuration.GetConnectionString("DefaultConnection");

// Setup dependency injection
var serviceProvider = new ServiceCollection()
    .AddDbContext<FlashcardsDbContext>(options =>
        options.UseSqlServer(connectionString))
    .BuildServiceProvider();

// Resolve the DbContext from the service provider
var dbContext = serviceProvider.GetRequiredService<FlashcardsDbContext>();

dbContext.Database.EnsureCreated();

dbContext.Stacks.Add(new Stack
{
    Name = "Sql Database",
    Flashcards = new List<Flashcard>
    {
        new Flashcard
        {
            Question = "Db?",
            Answer = "Database"
        },
          new Flashcard
        {
            Question = "Stored procedure?",
            Answer = "SQL Instructions"
        },

    }
});

try
{
    dbContext.SaveChanges();
}
catch (Exception ex)
{
    Console.WriteLine("Fail to insert data. Details: ", ex.Message);

}

var stack = dbContext.Stacks
    .Include(s => s.Flashcards)
    .FirstOrDefault(s => s.Id == 3);

foreach (var flascard in stack.Flashcards)
{
    Console.WriteLine($"{flascard.Id} {flascard.Question} {flascard.Answer}");
}