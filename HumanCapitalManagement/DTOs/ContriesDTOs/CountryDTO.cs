using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs.ContriesDTOs
{
    public class CountryDTO
    {
        [JsonProperty("cca2")]
        public string Cca2 { get; set; }
        [JsonProperty("name")]
        public NameDTO Name { get; set; }
    }
}
