using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs
{
	public class AddDepartmentDTO
	{
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
