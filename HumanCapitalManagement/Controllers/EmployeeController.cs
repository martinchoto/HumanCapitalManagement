using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using HumanCapitalManagement.Services.Interfaces;
using HumanManagementCapital;
using HumanCapitalManagement.DTOs.HCMDTOs;

namespace HumanCapitalManagement.Controllers
{
	[Authorize]
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
			string currentUserId = GetUserId();

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
		private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
