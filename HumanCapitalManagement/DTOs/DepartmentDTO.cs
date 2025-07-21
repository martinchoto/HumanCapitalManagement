using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs
{
	public class DepartmentDTO
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; } = null!;
	}
}
