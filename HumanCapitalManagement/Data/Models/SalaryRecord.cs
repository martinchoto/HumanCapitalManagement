using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanCapitalManagement.Data.Models
{
	public class SalaryRecord
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;

		public decimal Amount { get; set; }
		public DateTime DateIssued { get; set; }
		[ForeignKey(nameof(Employee))]
		public int EmployeeId { get; set; }
		public Employee Employee { get; set; } = null!;
	}
}
