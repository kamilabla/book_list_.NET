using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BookManager.Models;

namespace BookManager.Services
{
    public class CurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrencyRate> GetUsdRateAsync()
        {
            var response = await _httpClient.GetAsync("https://api.nbp.pl/api/exchangerates/rates/A/USD?format=json");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<CurrencyRate>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result;
            }
            return null;
        }
    }
}
