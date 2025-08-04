using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.DTOs;
using HumanCapitalManagement.DTOs.HCMDTOs;

namespace HumanCapitalManagement.Services.Interfaces
{
	public interface IHRService
	{
		Task<List<EmployeeDataDTO>> AllWorkers();
		Task<List<RoleDTO>> GetRoles();	
		Task<AddEmployeeDTO> CreateEmployeeDTO(Employee employee);

		Task AddEmployee(AddEmployeeDTO editHRDto);
		Task DeleteEmployee(Employee employee);
		Task<List<SalaryRecordDTO>> GetSalaryRecordDTOs(int employeeId);
		Task AddSalaryRecord(Employee employee, SalaryRecordDTO salaryRecordDto);
	}
}
