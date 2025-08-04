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
        [Required]
        public string Country { get; set; } = null!;
        public string EncryptedIBAN { get; set; }

        [NotMapped]
        [StringLength(Constants.MAX_IBAN_LENGTH, MinimumLength = Constants.MIN_IBAN_LENGTH, ErrorMessage = "IBAN must be between 15 and 34 characters.")]
        [RegularExpression(Constants.IBANREGEXPATTERN, ErrorMessage = "Invalid IBAN format.")]
        public string? IBAN
        {
            get => EncryptedIBAN == null ? null : EncryptionHelper.Decrypt(EncryptedIBAN);
            set => EncryptedIBAN = value == null ? null : EncryptionHelper.Encrypt(value);
        }
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        [ForeignKey(nameof(User))]
        [Required]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public ICollection<SalaryRecord> SalaryRecords { get; set; } = new List<SalaryRecord>();
    }
}
