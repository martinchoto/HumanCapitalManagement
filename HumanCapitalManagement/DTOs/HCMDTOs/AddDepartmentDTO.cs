using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs.HCMDTOs
{
	public class AddDepartmentDTO
	{
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
