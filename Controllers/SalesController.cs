using Microsoft.AspNetCore.Mvc;
using Assignment_3_Part_1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment_3_Part_1.Data;
using Assignment_3_Part_1.ViewModels;

namespace Assignment_3_Part_1.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "FullName");
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Sale salesData)
        {
            if (ModelState.IsValid)
            {
                _context.Sales.Add(salesData);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Home");
            }

            ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "FullName", salesData.EmployeeId);
            return View(salesData);
        }
    }

}
