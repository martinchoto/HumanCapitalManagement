using HumanCapitalManagement.Components.Pages;
using HumanCapitalManagement.Data;
using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.DTOs;
using HumanCapitalManagement.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HumanManagementCapital.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly ApplicationDbContext _dbContext;
		private UserManager<ApplicationUser> _userManager;
		public EmployeeService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
		}

		public async Task<List<DepartmentDTO>> GetDepartments()
		{
			return await _dbContext.Departments.Select(x => new DepartmentDTO
			{
				Id = x.Id,
				Name = x.Name,
			})
				.OrderBy(x => x.Name)
			.ToListAsync();
		}
		public async Task UpdateEmployeeAsync(Employee employee,
			EditEmployeeDTO editEmployeeDTO)
		{
			string[] fullName = editEmployeeDTO.FullName.Split(" ");
			employee.FirstName = fullName[0];
			employee.LastName = fullName[1];
			employee.CompanyEmail = editEmployeeDTO.Email;
			employee.DepartmentId = editEmployeeDTO.DepartmentId;
			employee.JobTitle = editEmployeeDTO.JobTitle;


			await _dbContext.SaveChangesAsync();
		}
		public async Task<EditEmployeeDTO> CreateEmployeeDTO(Employee employee)
		{
			return new EditEmployeeDTO
			{
				Id = employee.Id,
				DepartmentId = employee.DepartmentId,
				FullName = employee.FirstName + " " + employee.LastName,
				Email = employee.CompanyEmail,
				JobTitle = employee.JobTitle,
			};
		}
		public async Task<List<PersonalEmployeeDTO>> GetEmployeesByDepartmentAsync(string managerId)
		{
			var manager = await _dbContext.Employees.Where(x => x.UserId == managerId).FirstOrDefaultAsync();
			
			if (manager == null)
				return new List<PersonalEmployeeDTO>();


			var employees = await _dbContext.Employees
				.Where(x => x.DepartmentId == manager.DepartmentId)
				.Select(e => new PersonalEmployeeDTO
				{
					Id = e.Id,
					Email = e.CompanyEmail,
					FullName = e.FirstName + " " + e.LastName,
					Department = new DepartmentDTO { Name = e.Department.Name, Id = e.DepartmentId},
					JobTitle = e.JobTitle,
					Salary = e.Salary,
				})
				.ToListAsync();

			return employees;
		}

		public async Task<PersonalEmployeeDTO> GetPersonalDataAsync(string employeeId)
		{

			return await _dbContext.Employees
			.Where(e => e.UserId == employeeId)
			.Select(e => new PersonalEmployeeDTO
			{
				Id = e.Id,
				FullName = e.FirstName + " " + e.LastName,
				Email = e.CompanyEmail,
				Salary = e.Salary,
				JobTitle = e.JobTitle,
				Department = new DepartmentDTO { Id = e.Id, Name = e.Department.Name },
			})
			.FirstOrDefaultAsync();
		}

		public async Task<Employee> GetEmployeeById(int id)
		{
			return await _dbContext.Employees
				.Include(x => x.User)
				.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task UpdateEmployeeAsync(Employee employee, EditHRDTO editEmployeeDTO)
		{
			string[] fullName = editEmployeeDTO.FullName.Split(" ", 2);
			employee.FirstName = fullName[0];
			employee.LastName = fullName.Length > 1 ? fullName[1] : "";
			employee.CompanyEmail = editEmployeeDTO.Email;
			employee.DepartmentId = editEmployeeDTO.DepartmentId;
			employee.JobTitle = editEmployeeDTO.JobTitle;

			if (decimal.TryParse(editEmployeeDTO.Salary, out var salary))
			{
				employee.Salary = salary;
			}
			else
			{
				throw new Exception("Invalid salary format.");
			}

			var user = await _userManager.FindByIdAsync(employee.UserId);

			var currentRoles = await _userManager.GetRolesAsync(user);

			if (currentRoles.Any())
			{
				var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
				if (!removeResult.Succeeded)
				{
					return;
				}
			}

			if (!string.IsNullOrWhiteSpace(editEmployeeDTO.Role))
			{
				var addResult = await _userManager.AddToRoleAsync(user, editEmployeeDTO.Role);
				if (!addResult.Succeeded)
				{
					return;
				}
			}
			await _dbContext.SaveChangesAsync();
		}
	}
}
