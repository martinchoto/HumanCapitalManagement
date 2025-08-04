using System.Text.Json;
using HumanCapitalManagement.DTOs;
using Newtonsoft.Json;

namespace HumanCapitalManagement.Services
{
    public class WorkingDaysAPIService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public WorkingDaysAPIService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<int?> GetWorkingDaysAsync(string country, int month)
        {

            string apiKey = _config["ApiNinjas:ApiKey"];
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://api.api-ninjas.com/v1/workingdays?country={country}&month={month}");

            request.Headers.Add("X-Api-Key", apiKey);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<WorkingDaysDTO>(json);

                return data?.WorkingDays;
            }

            return null;
        }
    }
}
