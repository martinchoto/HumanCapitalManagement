using HumanCapitalManagement.DTOs.ContriesDTOs;

namespace HumanCapitalManagement.Services
{
    public class CountriesAPIService
    {
        private readonly HttpClient _httpClient;

        public CountriesAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string?> GetCountryIsoCodeAsync(string countryName)
        {
            if (string.IsNullOrWhiteSpace(countryName))
                return null;
            var result = await _httpClient.GetFromJsonAsync<List<CountryDTO>>(
                               $"https://restcountries.com/v3.1/name/{countryName}");

            return result?.FirstOrDefault()?.Cca2;
        }
    }
}
