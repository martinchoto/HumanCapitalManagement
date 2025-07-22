using HumanCapitalManagement.DTOs;
using HumanCapitalManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanCapitalManagement.Controllers
{
	[Authorize(Roles = "HR Admin")]
	[Route("api/[controller]")]
	[ApiController]
	public class HRController : ControllerBase
	{
		private IHRService _hrService;
		private IEmployeeService _employeeService;
		public HRController(IHRService hrService, IEmployeeService employeeService)
		{
			_hrService = hrService;
			_employeeService = employeeService;
		}
		[HttpGet("roles/all")]
		public async Task<List<RoleDTO>> AllRoles()
		{
			return await _hrService.GetRoles();
		}
		[HttpGet("all")]
		public async Task<List<EmployeeDataDTO>> GetAllWorkers()
		{
			return await _hrService.AllWorkers();
		}
		[HttpPut("edit/{id}")]
		public async Task<EditHRDTO> EditEmployee(int id)
		{
			var employee = await _employeeService.GetEmployeeById(id);
			return await _hrService.CreateEmployeeDTO(employee);
		}
	}
}
