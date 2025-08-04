using HumanCapitalManagement.Services;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace HumanCapitalManagement.DTOs.HCMDTOs
{
	public class EmployeeDataDTO : PersonalEmployeeDTO
	{
		[JsonProperty("roles")]
		public List<RoleDTO> Roles { get; set; } = new List<RoleDTO>();
	}
}
