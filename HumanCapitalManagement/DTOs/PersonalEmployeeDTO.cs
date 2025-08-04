using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs
{
	public class PersonalEmployeeDTO
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("fullName")]
		public string FullName { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("department")]
		public DepartmentDTO Department { get; set; }
		[JsonProperty("jobTitle")]
		public string JobTitle { get; set; }
		[JsonProperty("salary")]
		public decimal Salary { get; set; }
		[JsonProperty("country")]
        public string Country { get; set; }
		[JsonProperty("iban")]
        public string IBAN { get; set; }
    }
}
