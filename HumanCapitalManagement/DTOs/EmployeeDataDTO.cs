using HumanCapitalManagement.Services;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs
{
	public class EmployeeDataDTO : PersonalEmployeeDTO
	{
		[JsonProperty("roles")]
		public List<RoleDTO> Roles { get; set; } = new List<RoleDTO>();
	}
}
