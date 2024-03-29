using Assignment_3_Part_1.Data;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3_Part_1.Models.Validation
{
    public class EmployeeUniqueNameAndBirthDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var employee = (Employee)validationContext.ObjectInstance;
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            var existingEmployee = context.Employees
                .FirstOrDefault(e =>
                    e.FirstName == employee.FirstName &&
                    e.LastName == employee.LastName &&
                    e.DateOfBirth == employee.DateOfBirth &&
                    e.EmployeeId != employee.EmployeeId);

            if (existingEmployee != null)
            {
                return new ValidationResult("An employee with the same first name, last name, and date of birth already exists.", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }

    public class ManagerNotSamePersonAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var employee = (Employee)validationContext.ObjectInstance;
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            if (employee.ManagerId.HasValue)
            {
                var manager = context.Employees.Find(employee.ManagerId);

                if (manager != null &&
                    manager.FirstName == employee.FirstName &&
                    manager.LastName == employee.LastName &&
                    manager.DateOfBirth == employee.DateOfBirth)
                {
                    return new ValidationResult("Employee and manager cannot be the same person.", new[] { validationContext.MemberName });
                }
            }

            return ValidationResult.Success;
        }
    }
}
