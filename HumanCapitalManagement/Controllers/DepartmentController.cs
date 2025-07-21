using HumanCapitalManagement.Components.Account.Pages;
using HumanCapitalManagement.Components.Pages;
using HumanCapitalManagement.DTOs;
using HumanCapitalManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HumanCapitalManagement.Controllers
{
	[Authorize(Roles = "Manager")]
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IEmployeeService _employeeService;

		public DepartmentController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet("employees")]
		public async Task<IActionResult> GetDepartmentEmployees()
		{
			string managerId = GetUserId();

			var employees = await _employeeService.GetEmployeesByDepartmentAsync(managerId);
			return Ok(employees);
		}
		[HttpGet("all")]
		public async Task<IActionResult> AllDepartments()
		{
			var departments = await _employeeService.GetDepartments();
			if (!departments.Any())
				return Ok(new List<DepartmentDTO>());
			return Ok(departments);
		}
		[HttpGet("edit/{id}")]
		public async Task<IActionResult> EditMyEmployeeData(int id)
		{
			var employee = await _employeeService.GetEmployeeById(id);
			if (employee == null)
			{
				return BadRequest();
			}
			var employeeDto = await _employeeService.CreateEmployeeDTO(employee);
			var managedByManager = await _employeeService.GetEmployeesByDepartmentAsync(GetUserId());

			if (managedByManager == null || employeeDto == null)
				return Forbid();

			if (!managedByManager.Any(x => x.Department.Id == employeeDto.Department.Id))
				return Forbid();

			return Ok(employeeDto);
		}
		[HttpPut("edit/{id}")]
		public async Task<IActionResult> EditMyEmployeeData([FromBody] EditEmployeeDTO updatedDto, int id)
		{
			var employee = await _employeeService.GetEmployeeById(id);
			if (employee == null)
			{
				return BadRequest();
			}
			if (!ModelState.IsValid)
				return BadRequest("Invalid data.");


			await _employeeService.UpdateEmployeeAsync(employee, updatedDto);

			return Ok("Employee updated.");
		}
		private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
