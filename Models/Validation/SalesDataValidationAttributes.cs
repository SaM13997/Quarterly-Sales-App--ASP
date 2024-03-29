using Assignment_3_Part_1.Data;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3_Part_1.Models.Validation
{
    public class SalesDataUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var salesData = (Sale)validationContext.ObjectInstance;
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            var existingSalesData = context.Sales
                .FirstOrDefault(s =>
                    s.Quarter == salesData.Quarter &&
                    s.Year == salesData.Year &&
                    s.EmployeeId == salesData.EmployeeId &&
                    s.SalesId != salesData.SalesId);

            if (existingSalesData != null)
            {
                return new ValidationResult("Sales data for the same quarter, year, and employee already exists.", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }

}
