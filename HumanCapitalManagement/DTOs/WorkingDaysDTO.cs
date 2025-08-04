using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs
{
    public class WorkingDaysDTO
    {
        [JsonProperty("num_working_days")]  
        public int WorkingDays { get; set; }
    }
}
