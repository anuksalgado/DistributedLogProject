using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Bumptech.Glide.Signature;
using Android.Net.Nsd;

public class purchaseService
{
    private readonly HttpClient _httpClient;

    public purchaseService()
    {
        _httpClient = new HttpClient(new HttpClientHandler())
        {
            BaseAddress = new Uri("http://10.0.2.2:5249/")
        };
    }

    public async Task<ReceiptStruct> PostReceipt(List<itemStruct> items)
    {
      try
      {

        var dto = new
        {
            cusName = "Test Customer",
            items = items
        };
          var response = await _httpClient.PostAsJsonAsync("api/receipt", dto);
          if (response.IsSuccessStatusCode)
        {
            var receipt = await response.Content.ReadFromJsonAsync<ReceiptStruct>();
            return receipt;
        }
        else
        {
            //Debug.WriteLine($"Server returned error: {response.StatusCode}");
            return null;
        }
      }
      catch (Exception ex)
      {
          Debug.WriteLine($"Exception: {ex.Message}");
          return null;
      }
    }

    public class ReceiptCreateDto
    {
        public string cusName { get; set; }
        public List<itemStruct> items { get; set; }
    }

}
