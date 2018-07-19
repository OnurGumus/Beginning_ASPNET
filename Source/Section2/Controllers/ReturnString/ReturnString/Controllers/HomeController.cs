using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReturnString.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReturnString.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public string Index() => "Hello World! I am learning MVC!";

        public IActionResult IndexContent() => Content("Hello World! I am learning MVC!");

        public IActionResult IndexUpper() => new UpperStringActionResult("Hello World! I am learning MVC!");

        public IActionResult MyView() => View();

        public IActionResult Employee()
        {
            //Sample Model - Usually this comes from database
            var emp1 = new Employee
            {
                EmployeeId = 1,
                Name = "Jon Skeet",
                Designation = " Software Architect"
            };
            return View(emp1);
        }


        public IActionResult Employee2()
        {
            //Sample Model - Usually this comes from database
            var emp1 = new Employee
            {
                EmployeeId = 1,
                Name = "Jon Skeet",
                Designation = " Software Architect"
            };
            ViewBag.Company = "Google Inc";
            ViewData["CompanyLocation"] = "United States";

            return View(emp1);
        }


    }
}
