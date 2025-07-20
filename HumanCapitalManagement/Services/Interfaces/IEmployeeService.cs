using HumanCapitalManagement.DTOs;

namespace HumanCapitalManagement.Services.Interfaces
{
	public interface IEmployeeService
	{
		Task<PersonalEmployeeDTO> GetPersonalDataAsync(string id);
	}
}
