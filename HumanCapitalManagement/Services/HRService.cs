using System.Text.RegularExpressions;
using HumanCapitalManagement.Components.Pages;
using HumanCapitalManagement.Data;
using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.DTOs;
using HumanCapitalManagement.Services.Interfaces;
using Humanizer;
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
		public async Task<AddEmployeeDTO> CreateEmployeeDTO(Employee employee)
		{
			return new AddEmployeeDTO
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

		public async Task AddEmployee(AddEmployeeDTO dto)
		{
			var nameParts = dto.FullName.Split(' ', 2);
			var firstName = nameParts[0];
			var lastName = nameParts.Length > 1 ? nameParts[1] : "";

			var user = new ApplicationUser
			{
				UserName = firstName+lastName,
				Email = dto.Email,
			};

			var employee = new Employee
			{
				UserId = user.Id,
				FirstName = firstName,
				LastName = lastName,
				CompanyEmail = dto.Email,
				DepartmentId = dto.DepartmentId,
				JobTitle = dto.JobTitle,
				Country = dto.Country,
            };

			if (IsIbanValid(dto.IBAN))
			{
				employee.EncryptedIBAN = EncryptionHelper.Encrypt(dto.IBAN);
			}
			else
			{
				throw new Exception("Invalid IBAN format.");
            }

            if (decimal.TryParse(dto.Salary, out var salary))
			{
				employee.Salary = salary;
			}
			else
			{
				throw new Exception("Invalid salary format.");
			}
            await _userManager.CreateAsync(user, "admin");

            if (!string.IsNullOrWhiteSpace(dto.Role))
            {
                var roleResult = await _userManager.AddToRoleAsync(user, dto.Role);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("Can't add this role.");
                }
            }
            await _dbContext.Employees.AddAsync(employee);
			await _dbContext.SaveChangesAsync();
		}
		private bool IsIbanValid(string inputIban)
		{
            if (string.IsNullOrWhiteSpace(inputIban)) return false;

			Regex regex = new Regex(Constants.IBANREGEXPATTERN);
            inputIban = inputIban.Replace(" ", "").ToUpperInvariant();
            return inputIban.Length >= Constants.MIN_IBAN_LENGTH && inputIban.Length <= Constants.MAX_IBAN_LENGTH && regex.IsMatch(inputIban);
        } 
		public async Task DeleteEmployee(Employee employee)
		{
			if (employee == null)
				throw new Exception($"Employee with ID {employee.Id} not found.");

			var user = await _userManager.FindByIdAsync(employee.UserId);
			if (user == null)
				throw new Exception($"Associated user with ID {employee.UserId} not found.");

			_dbContext.Employees.Remove(employee);


			var identityResult = await _userManager.DeleteAsync(user);
			if (!identityResult.Succeeded)
				throw new Exception($"Failed to delete user with ID {user.Id}: {string.Join(", ", identityResult.Errors.Select(e => e.Description))}");

			await _dbContext.SaveChangesAsync();
		}
		public async Task<List<SalaryRecordDTO>> GetSalaryRecordDTOs(int employeeId)
		{
			return await _dbContext.SalaryRecords
				.Where(sr => sr.EmployeeId == employeeId)
				.Select(sr => new SalaryRecordDTO
				{
					Id = sr.Id,
					Name = sr.Name,
					EmployeeId = sr.EmployeeId,
					Amount = sr.Amount,
					DateIssued = sr.DateIssued,
					Description = sr.Description,
				})
				.OrderByDescending(sr => sr.DateIssued)
				.ToListAsync();
		}

		public async Task AddSalaryRecord(Employee employee, SalaryRecordDTO salaryRecordDto)
		{
			SalaryRecord salaryRecord = new SalaryRecord
			{
				EmployeeId = employee.Id,
				DateIssued = DateTime.Now,
				Description = salaryRecordDto.Description,
				Name = salaryRecordDto.Name,
			};
			if (decimal.TryParse(salaryRecordDto.Amount.ToString(), out var amount))
			{
				salaryRecord.Amount = amount;
			}
			else
			{
				throw new Exception("Invalid salary amount format.");
			}
			await _dbContext.SalaryRecords.AddAsync(salaryRecord);
			await _dbContext.SaveChangesAsync();
		}
	}
}
