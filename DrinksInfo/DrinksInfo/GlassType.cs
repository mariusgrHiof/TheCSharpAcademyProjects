using System.Text.Json.Serialization;

namespace DrinksInfo;

public class GlassType
{
    [JsonPropertyName("strGlass")]
    public string GlassName { get; set; } = string.Empty;
}

