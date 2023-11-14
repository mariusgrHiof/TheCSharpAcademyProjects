using System.Text.Json.Serialization;

namespace DrinksInfo;

public class Drink
{
    [JsonPropertyName("strDrink")]
    public string DrinkName { get; set; } = string.Empty;

    [JsonPropertyName("idDrink")]
    public string IdDrink { get; set; }
}

