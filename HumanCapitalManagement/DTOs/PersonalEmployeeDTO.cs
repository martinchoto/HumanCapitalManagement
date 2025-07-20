using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs
{
	public class PersonalEmployeeDTO
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("fullName")]
		public object FullName { get; set; }
		[JsonProperty("email")]
		public object Email { get; set; }
		[JsonProperty("department")]
		public string Department { get; set; }
		[JsonProperty("jobTitle")]
		public string JobTitle { get; set; }
		[JsonProperty("salary")]
		public decimal Salary { get; set; }
	}
}
