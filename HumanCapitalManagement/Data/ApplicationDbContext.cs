using HumanCapitalManagement.Data;
using HumanCapitalManagement.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HumanCapitalManagement.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Department> Departments { get; set; } = null!;
		public DbSet<Employee> Employees { get; set; } = null!;
		public DbSet<SalaryRecord> SalaryRecords { get; set; } = null!;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<ApplicationUser>(entity =>
			{
				entity.Ignore(u => u.EmailConfirmed);
				entity.Ignore(u => u.PhoneNumberConfirmed);
				entity.Ignore(u => u.TwoFactorEnabled);
				entity.Ignore(u => u.LockoutEnabled);
				entity.Ignore(u => u.LockoutEnd);
				entity.Ignore(u => u.AccessFailedCount);
				entity.Ignore(u => u.PhoneNumber);
				entity.Ignore(u => u.PhoneNumberConfirmed);
			});

			modelBuilder.Entity<Employee>()
			.HasOne(e => e.User)
			.WithOne()
			.HasForeignKey<Employee>(e => e.UserId)
			.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Employee>()
		   .HasOne(e => e.Department)
		   .WithMany(d => d.Employees)
		   .HasForeignKey(e => e.DepartmentId)
		   .OnDelete(DeleteBehavior.Restrict);

			// Uncomment if you want to seed 
			//SeedDatabase.SeedRoles(modelBuilder); 
			//SeedDatabase.SeedDepartments(modelBuilder);
			//SeedDatabase.SeedUsersAndEmployees(modelBuilder);
		}
	}

}

