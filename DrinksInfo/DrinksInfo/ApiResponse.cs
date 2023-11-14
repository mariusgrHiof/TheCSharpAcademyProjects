using System.Text.Json.Serialization;

namespace DrinksInfo;

public class ApiResponse<T> where T : class
{
    [JsonPropertyName("drinks")]
    public List<T>? TName { get; set; }

}

