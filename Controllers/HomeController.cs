using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_3_Part_1.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment_3_Part_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var salesData = _context.Sales
                .Include(s => s.Employee)
                .ToList();

            var employees = _context.Employees.ToList();

            ViewBag.Employees = new SelectList(employees, "EmployeeId", "FullName");

            return View(salesData);
        }
    }
}