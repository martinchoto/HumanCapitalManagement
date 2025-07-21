using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs
{
	public class EditEmployeeDTO
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("fullName")]
		public string FullName { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("department_id")]
		public int DepartmentId { get; set; }
		[JsonProperty("jobTitle")]
		public string JobTitle { get; set; }
	}
}
