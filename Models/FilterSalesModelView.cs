using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment_3_Part_1.Models
{
    public class FilterSalesViewModel
    {
        public SelectList Employees { get; set; }
        public int SelectedEmployeeId { get; set; }
        public IEnumerable<Sale> Sales { get; set; }
    }
}
