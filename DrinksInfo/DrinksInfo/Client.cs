using System.Text.Json;

namespace DrinksInfo;

public class Client
{
    private readonly HttpClient _client;

    public Client(HttpClient client)
    {
        _client = client;
    }

    public async Task<T> GetData<T>(string url) where T : class
    {
        await using Stream stream = await _client.GetStreamAsync(url);

        var repositories = await JsonSerializer.DeserializeAsync<T>(stream);

        return repositories;
    }
}

