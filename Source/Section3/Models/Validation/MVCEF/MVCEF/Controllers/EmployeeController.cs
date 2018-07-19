using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCEF.Models;
using MVCEF.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCEF.Controllers
{
    public class EmployeeController : Controller
    {
        readonly EmployeeDbContext employeeDbContext;
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var employeeAddViewModel = new EmployeeAddViewModel();
            var db = this.employeeDbContext;
            employeeAddViewModel.EmployeesList = db.Employees.ToList();

            return View(employeeAddViewModel);
        }

        [HttpPost]
        public IActionResult Index(EmployeeAddViewModel employeeAddViewModel)
        {

            if (ModelState.IsValid)
            {
                var newEmployee = new Employee
                {
                    Name = employeeAddViewModel.Name,
                    Designation = employeeAddViewModel.Designation,
                    Salary = employeeAddViewModel.Salary
                };
                employeeDbContext.Employees.Add(newEmployee);
                employeeDbContext.SaveChanges();
                //Redirect to get Index GET method
                return RedirectToAction("Index");
            }
            employeeAddViewModel.EmployeesList = employeeDbContext.Employees.ToList();
            return View(employeeAddViewModel);
        }
    }
}
