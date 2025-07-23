namespace HumanCapitalManagement.DTOs
{
	public class SalaryRecordDTO
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

		public decimal Amount { get; set; }

		public DateTime DateIssued { get; set; }

		public int EmployeeId { get; set; }
	}
}
