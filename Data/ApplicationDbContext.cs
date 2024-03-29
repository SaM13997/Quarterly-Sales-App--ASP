using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Assignment_3_Part_1.Models; 
namespace Assignment_3_Part_1.Data { 
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for an employee
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Ada",
                    LastName = "Lovelace",
                    DateOfBirth = new DateTime(1956, 12, 10),
                    DateOfHire = new DateTime(1995, 1, 1),
                    ManagerId = null
                }
            );
            modelBuilder.Entity<Sale>().HasData(
                new Sale
                {
                    SalesId = 1,
                    Quarter = 3,
                    Year = 2024,
                    Amount = 2541260,
                    EmployeeId =1,
                }
            );
        }
    }
}