using DrinksInfo.Api;
using DrinksInfo.Controllers;

HttpClient client = new HttpClient()
{
    BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/")
};
ApiClient apiClient = new ApiClient(client);

DrinksController drinksController = new DrinksController(apiClient);

var categories = await drinksController.GetCategoriesAsync();

Console.WriteLine("Categories");
Console.WriteLine("--------------------");
foreach (var category in categories)
{
    Console.WriteLine(category.CategoryName);
}
Console.WriteLine("--------------------");

Console.WriteLine("Drink detail id: 11007");
Console.WriteLine("--------------------");

var drink = await drinksController.GetDrinkByIdAsync("110071");
if (drink == null)
{
    Console.WriteLine("Drink not found");
    Console.WriteLine("--------------------");

}
else
{
    Console.WriteLine(drink.DrinkName);
    Console.WriteLine("--------------------");
}

var drinksByCategoryName = await drinksController.GetDrinksByCategoryAsync("Punch / Party Drink");

Console.WriteLine("Drinks by gatecory name: Punch / Party Drink");
Console.WriteLine("--------------------");

foreach (var drinkNyCategory in drinksByCategoryName)
{
    Console.WriteLine(drinkNyCategory.DrinkName);
}
Console.WriteLine("--------------------");