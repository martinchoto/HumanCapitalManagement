using HumanCapitalManagement.Data;
using HumanCapitalManagement.DTOs;
using HumanCapitalManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HumanManagementCapital.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly ApplicationDbContext _dbContext;
		public EmployeeService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
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
				Department = e.Department.Name,
				JobTitle = e.JobTitle
			})
			.FirstOrDefaultAsync();
		}

	}
}
