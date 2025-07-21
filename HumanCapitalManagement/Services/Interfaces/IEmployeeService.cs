using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.DTOs;

namespace HumanCapitalManagement.Services.Interfaces
{
	public interface IEmployeeService
	{
		Task<List<PersonalEmployeeDTO>> GetEmployeesByDepartmentAsync(string? managerId);
		Task<PersonalEmployeeDTO> GetPersonalDataAsync(string id);
		Task<List<DepartmentDTO>> GetDepartments();
		Task<EditEmployeeDTO> CreateEmployeeDTO(Employee employee);
		Task UpdateEmployeeAsync(Employee personalEmployeeDTO, EditEmployeeDTO editEmployeeDTO);
		Task<Employee> GetEmployeeById(int id);
	}
}
