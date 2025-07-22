using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs
{
	public class EditHRDTO : EditEmployeeDTO
	{
		[JsonProperty("salary")]
		public string Salary { get; set; }
		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
