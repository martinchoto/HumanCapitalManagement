using HumanCapitalManagement.Data.Models;
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
		public async Task<IActionResult> EditEmployee(int id, [FromBody] EditHRDTO editModel)
		{
			if (editModel == null)
			{
				return BadRequest("Invalid data submitted.");
			}

			var employee = await _employeeService.GetEmployeeById(id);
			if (employee == null)
			{
				return NotFound($"No employee found with ID {id}.");
			}

			await _employeeService.UpdateEmployeeAsync(employee, editModel);
			return Ok(new { message = "Employee updated successfully." });

		}
		[HttpPost("add")]
		public async Task<IActionResult> CreateEmployee([FromBody] EditHRDTO createModel)
		{
			if (createModel == null)
			{
				return BadRequest("Invalid data submitted.");
			}
			await _hrService.AddEmployee(createModel);
			return Ok(new { message = "Employee created successfully." });
		}
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteEmployee(int id)
		{
			Employee employee = await _employeeService.GetEmployeeById(id);
			if (employee == null)
			{
				return NotFound($"No employee found with ID {id}.");
			}
			await _hrService.DeleteEmployee(employee);
			return Ok(new { message = "Employee deleted successfully." });
		}
	}
}
