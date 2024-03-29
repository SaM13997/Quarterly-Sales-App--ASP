using Assignment_3_Part_1.Data;
using Assignment_3_Part_1.Models;
using Assignment_3_Part_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assignment_3_Part_1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var managers = _context.Employees.ToList();

            if (managers != null && managers.Any())
            {
                ViewBag.Managers = new SelectList(managers, "EmployeeId", "FullName");
            }
            else
            {
                ViewBag.Managers = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
            }
            var employees = _context.Employees.ToList();
            ViewBag.Employees = new SelectList(employees, "EmployeeId", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult FilterSales(int employeeId)
        {
            var sales = _context.Sales.Where(s => s.EmployeeId == employeeId).ToList();
            var employees = _context.Employees.ToList();
            ViewData["EmployeeId"] = new SelectList(employees, "EmployeeId", "FullName");

            var viewModel = new FilterSalesViewModel
            {
                Employees = new SelectList(_context.Employees, "EmployeeId", "FullName"),
                SelectedEmployeeId = employeeId, 
                Sales = sales
            };

            return View("Index", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Home");
            }

            ViewBag.Managers = new SelectList(_context.Employees, "EmployeeId", "FullName", employee.ManagerId);
            return View(employee);
        }
    }
}
