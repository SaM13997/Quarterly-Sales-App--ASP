using Assignment_3_Part_1.Models;

namespace Assignment_3_Part_1.ViewModels
{
    public class SalesListViewModel
    {
        public IEnumerable<Sale> Sales { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
       /* public int? EmployeeId { get; set; }
        public int? Year { get; set; }
        public int? Quarter { get; set; }*/
    }
}