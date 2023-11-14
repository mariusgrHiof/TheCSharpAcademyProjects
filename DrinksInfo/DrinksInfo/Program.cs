using DrinksInfo;

string categoriesUrl = "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list";
string glassesUrl = "https://www.thecocktaildb.com/api/json/v1/1/list.php?g=list";
Dictionary<DrinkCategory, string> categoryMapping = new Dictionary<DrinkCategory, string>
{
    { DrinkCategory.OrdinaryDrink, "Ordinary_Drink" },
    { DrinkCategory.Cocktail, "Cocktail" },
    { DrinkCategory.HomemadeLiqueur, "Homemade_Liqueur" },
    { DrinkCategory.SoftDrink, "Soft_Drink" },
    { DrinkCategory.Beer, "Beer" },
    { DrinkCategory.OtherOrUnknow, "Other_/_Unknown" },
    { DrinkCategory.Cocoa, "Cocoa" },
    { DrinkCategory.CoffeeOrTea, "Coffee_/_Tea" },
    { DrinkCategory.Shot, "Shot" },
    { DrinkCategory.PunchOrPartyDrink, "Punch_/_Party_Drink" }
};

using HttpClient httpClient = new HttpClient();
Client client = new Client(httpClient);


var categoires = await client.GetData<ApiResponse<Category>>(categoriesUrl);

while (true)
{
    Console.WriteLine("Categories");
    Console.WriteLine("----------------------");
    foreach (var category in categoires.TName)
    {
        Console.WriteLine(category.CategoryName);
    }
    Console.WriteLine("----------------------");

    Console.Write("Enter a number(0 to quit): ");
    string userInput = Console.ReadLine();
    if (userInput == "0")
    {
        break;
    }

    DrinkCategory DrinkInputCategory = (DrinkCategory)Convert.ToInt32(userInput);

    try
    {
        await GetDrinkByCategory(categoryMapping.GetValueOrDefault(DrinkInputCategory));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}



async Task GetDrinkByCategory(string category)
{
    try
    {
        string url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={category}";
        var drinks = await client.GetData<ApiResponse<Drink>>(url);

        foreach (var drink in drinks.TName)
        {
            Console.WriteLine(drink.DrinkName);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
}