using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.DTOs;

namespace HumanCapitalManagement.Services.Interfaces
{
	public interface IHRService
	{
		Task<List<EmployeeDataDTO>> AllWorkers();
		Task<List<RoleDTO>> GetRoles();	
		Task<EditHRDTO> CreateEmployeeDTO(Employee employee);
	}
}
