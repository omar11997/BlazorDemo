using SharedLibrary;
using System.Text.Json;

namespace WASM.App.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient;
        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
        public async Task<IEnumerable<Country>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
                 (await _httpClient.GetStreamAsync("/api/Country"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Country> GetById(int id)
        {
            return await JsonSerializer.DeserializeAsync<Country>
                 (await _httpClient.GetStreamAsync("/api/Country/" + id), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
