using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using HumanCapitalManagement.Services.Interfaces;
using HumanManagementCapital;
using HumanCapitalManagement.DTOs;

namespace HumanManagementCapital.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeService _employeeService;
		public EmployeeController(IEmployeeService employeeService) 
		{
			_employeeService = employeeService;
		}
		[HttpGet("me")]
		public async Task<IActionResult> PersonalData()
		{
			string currentUserId = "84c9f667-1b92-4e71-bca0-ffbe2d448d77";

			if (string.IsNullOrEmpty(currentUserId))
			{
				return Unauthorized();
			}

			PersonalEmployeeDTO personalData = await _employeeService.GetPersonalDataAsync(currentUserId);

			if (personalData == null)
			{
				return NotFound();
			}

			return Ok(personalData);
		}
		private string GetUserId() => User?.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
