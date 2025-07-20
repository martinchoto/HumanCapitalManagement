using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace HumanCapitalManagement.Data
{
	public class SeedDatabase
	{
		internal static void SeedRoles(ModelBuilder builder)
		{
			builder.Entity<IdentityRole>().HasData(
				new IdentityRole { Id = "1", Name = "HR Admin", NormalizedName = "HR ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
				new IdentityRole { Id = "2", Name = "Manager", NormalizedName = "MANAGER", ConcurrencyStamp = Guid.NewGuid().ToString() },
				new IdentityRole { Id = "3", Name = "Employee", NormalizedName = "EMPLOYEE", ConcurrencyStamp = Guid.NewGuid().ToString() }
			);
		}
		internal static void SeedDepartments(ModelBuilder builder)
		{
			builder.Entity<Department>().HasData(
				new Department { Id = 1, Name = "Human Resources" },
				new Department { Id = 2, Name = "Finance" },
				new Department { Id = 3, Name = "IT" },
				new Department { Id = 4, Name = "Marketing" },
				new Department { Id = 5, Name = "Sales" },
				new Department { Id = 6, Name = "Operations" }
			);
		}
		internal static void SeedUsersAndEmployees(ModelBuilder builder)
		{
			var employees = new List<Employee>();
			var users = new List<ApplicationUser>();
			var userRoles = new List<IdentityUserRole<string>>();
			for (int i = 1; i <= 50; i++)
			{
				var userId = Guid.NewGuid().ToString();
				string userName = $"JohnDoe{i}";
				string personalEmail = $"johndoe{i}@personal.gmail";
				string companyEmail = $"johndoe{i}@company.gmail";
				var passwordHasher = new PasswordHasher<ApplicationUser>();

				ApplicationUser user = new ApplicationUser
				{
					Id = userId,
					UserName = userName,
					NormalizedUserName = userName.ToUpper(),
					Email = personalEmail,
					NormalizedEmail = personalEmail.ToUpper(),
					SecurityStamp = Guid.NewGuid().ToString(),
					ConcurrencyStamp = Guid.NewGuid().ToString(),
				};
				user.PasswordHash = passwordHasher.HashPassword(user, "admin");
				users.Add(user);
				//Check which department 
				int departmentId = (i % 6) + 1;
				// Check if its an HR
				bool isHR = departmentId == 1;
				//Check if its manager first 6 ids are managers in the seeding
				bool isManager = i <= 6;
				var random = new Random();
				Employee employee = new Employee
				{
					Id = i,
					FirstName = $"John",
					LastName = $"Doe",
					CompanyEmail = companyEmail,
					JobTitle = GetJobTitle(departmentId, isManager),
					Salary = GetSalaryByDepartment(departmentId, isManager),
					DepartmentId = i % 6 + 1,
					UserId = user.Id,
				};
				builder.Entity<Employee>().HasData(employee);
				string roleId = isHR ? "1" : (isManager ? "2" : "3");
				var userRole = new IdentityUserRole<string> { UserId = user.Id, RoleId = roleId };
				userRoles.Add(userRole);
			}
			builder.Entity<ApplicationUser>().HasData(users);
			builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
		}
		private static decimal GetSalaryByDepartment(int deptId, bool isManager)
		{
			var random = new Random();
			int baseSalary = deptId switch
			{
				1 => random.Next(1500, 1800),  // HR
				2 => random.Next(2000, 2200),  // Finance
				3 => random.Next(4000, 5000),  // IT
				4 => random.Next(2000, 2200),  // Marketing
				5 => random.Next(2000, 5000),  // Sales
				6 => random.Next(2500, 3000),  // Operations
				_ => random.Next(1500, 2000)
			};

			return isManager ? baseSalary * 1.5m : baseSalary;
		}
		private static string GetJobTitle(int deptId, bool isManager = false)
		{
			if (isManager)
			{
				return deptId switch
				{
					1 => "HR Manager",
					2 => "Finance Manager",
					3 => "IT Manager",
					4 => "Marketing Manager",
					5 => "Sales Manager",
					6 => "Operations Manager",
					_ => "Department Manager"
				};
			}

			return deptId switch
			{
				1 => new[] { "HR Generalist", "Recruiter", "Training Specialist", "Compensation Analyst" }[new Random().Next(4)],
				2 => new[] { "Accountant", "Financial Analyst", "Auditor", "Tax Specialist" }[new Random().Next(4)],
				3 => new[] { "Software Developer", "System Admin", "Network Engineer", "Database Admin" }[new Random().Next(4)],
				4 => new[] { "Marketing Specialist", "Content Writer", "SEO Analyst", "Social Media Manager" }[new Random().Next(4)],
				5 => new[] { "Sales Representative", "Account Executive", "Business Developer", "Sales Engineer" }[new Random().Next(4)],
				6 => new[] { "Operations Specialist", "Logistics Coordinator", "Facilities Manager", "Supply Chain Analyst" }[new Random().Next(4)],
				_ => "Department Specialist"
			};
		}
	}
}
