using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs.HCMDTOs
{
    public class AddEmployeeDTO : EditEmployeeDTO
    {
        [JsonProperty("salary")]
        public string Salary { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("iban")]
        public string IBAN { get; set; }
    }
}
