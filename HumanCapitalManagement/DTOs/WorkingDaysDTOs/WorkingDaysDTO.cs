using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs.WorkingDaysDTOs
{
    public class WorkingDaysDTO
    {
        [JsonProperty("num_working_days")]  
        public int WorkingDays { get; set; }
    }
}
