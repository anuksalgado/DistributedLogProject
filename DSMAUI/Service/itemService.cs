using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;

public class ItemService
{
    private readonly HttpClient _httpClient;

    public ItemService()
    {
        _httpClient = new HttpClient(new HttpClientHandler())
        {
            BaseAddress = new Uri("http://10.0.2.2:5249/")
        };
    }

    public async Task<List<itemStruct>> GetItemsAsync()
{
    try
    {
        var response = await _httpClient.GetAsync("api/item");
        var json = await response.Content.ReadAsStringAsync();
        //Debug.WriteLine($"Raw JSON: {json}");

        var items = JsonSerializer.Deserialize<List<itemStruct>>(json);
        return items ?? new List<itemStruct>();
    }
    catch (Exception ex)
    {
        Debug.WriteLine($"Failed to fetch items: {ex.Message}");
        return new List<itemStruct>();
    }
}

}
