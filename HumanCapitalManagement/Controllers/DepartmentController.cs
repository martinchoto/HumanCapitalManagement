using HumanCapitalManagement.Components.Account.Pages;
using HumanCapitalManagement.Components.Pages;
using HumanCapitalManagement.Data.Models;
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
	[Authorize(Roles = "Manager,HR Admin")]
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

			List<PersonalEmployeeDTO> employees = await _employeeService.GetEmployeesByDepartmentAsync(managerId);
			return Ok(employees);
		}
		[HttpGet("all")]
		public async Task<IActionResult> AllDepartments()
		{
			List<DepartmentDTO> departments = await _employeeService.GetDepartments();
			if (!departments.Any())
				return Ok(new List<DepartmentDTO>());
			return Ok(departments);
		}
		[HttpGet("edit/{id}")]
		public async Task<IActionResult> EditMyEmployeeData(int id)
		{
			Employee employee = await _employeeService.GetEmployeeById(id);
			if (employee == null)
			{
				return BadRequest();
			}
			EditEmployeeDTO employeeDto = await _employeeService.CreateEmployeeDTO(employee);


			if (employeeDto == null ||
				(!User.IsInRole("HR Admin") && !User.IsInRole("Manager")))
				return Forbid();

			return Ok(employeeDto);
		}
		[HttpPut("edit/{id}")]
		public async Task<IActionResult> SaveEdit(int id, [FromBody]EditEmployeeDTO editModel)
		{
			Employee employee = await _employeeService.GetEmployeeById(id);
			if (employee == null)
			{
				return BadRequest();
			}
			if (!ModelState.IsValid)
				return BadRequest("Invalid data.");
			await _employeeService.UpdateEmployeeAsync(employee, editModel);

			return Ok("Employee updated.");
		}
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteDepartment(int id)
		{
			Department department = await _employeeService.GetDepartmentById(id);
			if (department == null)
			{
				return BadRequest("Department not found.");
			}
			await _employeeService.DeleteDepartmentAsync(department);
			return Ok("Department deleted.");
		}
		[HttpPost("create")]
		public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDTO departmentDTO)
		{ 
			if (departmentDTO == null || string.IsNullOrWhiteSpace(departmentDTO.Name))
			{
				return BadRequest("Invalid department data.");
			}
			List<DepartmentDTO> departments = await _employeeService.GetDepartments();

			if (departments.Any(x => x.Name.Equals(departmentDTO.Name, StringComparison.OrdinalIgnoreCase)))
			{
				return Conflict("Department already exists.");
			}
			await _employeeService.CreateDepartment(departmentDTO);
			return Ok("Department created successfully.");
		}
		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentDTO departmentDTO)
		{
			if (departmentDTO == null || string.IsNullOrWhiteSpace(departmentDTO.Name))
			{
				return BadRequest("Invalid department data.");
			}
			Department existingDepartment = await _employeeService.GetDepartmentById(id);
			if (existingDepartment == null)
			{
				return NotFound("Department not found.");
			}
			List<DepartmentDTO> departments = await _employeeService.GetDepartments();
			if (departments.Any(x => x.Name.Equals(departmentDTO.Name, StringComparison.OrdinalIgnoreCase) && x.Id != id))
			{
				return Conflict("Department with this name already exists.");
			}
			await _employeeService.UpdateDepartmentAsync(existingDepartment, departmentDTO);
			return Ok("Department updated successfully.");
		}
		private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
