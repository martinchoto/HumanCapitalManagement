using HumanCapitalManagement.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace HumanCapitalManagement.Data.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; } = null!;
		[Required]
		public string LastName { get; set; } = null!;
		[Required]
		public string CompanyEmail { get; set; } = null!;
		[Required]
		public string JobTitle { get; set; } = null!;
		public decimal Salary { get; set; }
		[ForeignKey(nameof(Department))]
		public int DepartmentId { get; set; }
		public Department Department { get; set; } = null!;
		[ForeignKey(nameof(User))]
		[Required]
		public string UserId { get; set; } = null!;
		public ApplicationUser User { get; set; } = null!;
	}
}
