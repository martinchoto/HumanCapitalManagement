using HumanCapitalManagement.Data;
using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.DTOs;
using HumanCapitalManagement.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HumanCapitalManagement.Services
{
	public class HRService : IHRService
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public HRService(ApplicationDbContext dbContext, 
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			_roleManager = roleManager;
		}
		private async Task<List<RoleDTO>> GetRoles(int id)
		{
			var e = await _dbContext.Employees.FindAsync(id);
			var user = await _userManager.FindByIdAsync(e.UserId);
			var roles = await _userManager.GetRolesAsync(user);

			var rolesDto = roles.Select(x => new RoleDTO
			{
				Name = x
			}).ToList();

			return rolesDto;
		}
		public async Task<List<EmployeeDataDTO>> AllWorkers()
		{

			var employees = await _dbContext.Employees.Select(e => new EmployeeDataDTO
			{
				Id = e.Id,
				FullName = e.FirstName + " " + e.LastName,
				Email = e.CompanyEmail,
				JobTitle = e.JobTitle,
				Department = new DepartmentDTO
				{
					Id = e.DepartmentId,
					Name = e.Department.Name
				},
				Salary = e.Salary

			})
			.OrderBy(x => x.Department.Name).ThenBy(x => x.Id).ToListAsync();

			foreach (var employee in employees)
			{
				employee.Roles = await GetRoles(employee.Id);
			}
			return employees;

		}
		public async Task<EditHRDTO> CreateEmployeeDTO(Employee employee)
		{
			return new EditHRDTO
			{
				Id = employee.Id,
				DepartmentId = employee.DepartmentId,
				FullName = employee.FirstName + " " + employee.LastName,
				Email = employee.CompanyEmail,
				JobTitle = employee.JobTitle,
				Salary = employee.Salary.ToString("F2"),
				Role = (await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(employee.UserId))).FirstOrDefault() ?? string.Empty
			};
		}

		public Task<List<RoleDTO>> GetRoles()
		{
			var roles = _roleManager.Roles.Select(r => new RoleDTO
			{
				Name = r.Name
			}).ToListAsync();

			return roles;
		}
	}
}
