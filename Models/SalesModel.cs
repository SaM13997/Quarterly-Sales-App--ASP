using System.ComponentModel.DataAnnotations;

namespace Assignment_3_Part_1.Models
{
    public class Sale
    {
        [Key]
        public int SalesId { get; set; }

        [Required]
        [Range(1, 4)]
        public int Quarter { get; set; }

        [Required]
        [Range(2001, 9999)]
        public int Year { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
 
}
