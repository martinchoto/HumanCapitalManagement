using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs.ContriesDTOs
{
    public class NameDTO
    {
        [JsonProperty("common")]
        public string Common { get; set; }
    }
}
