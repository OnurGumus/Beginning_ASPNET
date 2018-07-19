using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Layout.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Layout.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "Hello";
            return View();
        }
        [HttpGet]
        public IActionResult ValidateAge()
        {
            ViewBag.Title = "Validate Age for voting";
            var person1 = new Person();
            return View(person1);
        }



        [HttpPost]
        public IActionResult ValidateAge(Person person1)
        {
            ViewBag.Title = "Validate Age for voting";
            if (person1.Age >= 18)
            {
                ViewBag.Message = "You are eligible to Vote!";
            }
            else
            {
                ViewBag.Message = "Sorry.You are not old enough to vote!";
            }
            return View();
        }
        [HttpGet]
        public IActionResult ValidateAge2()
        {
            ViewBag.Title = "Validate Age for voting";
            var person1 = new Person();
            return View(person1);
        }
        [HttpPost]
        public IActionResult ValidateAge2(Person person1)
        {

            if (Convert.ToBoolean(Request.Form["OlderThan18"][0]))
            {
                ViewData["OlderThan18"] = true;
                ViewBag.Message = "You are eligible to Vote!";
            }
            else
            {
                ViewBag.Message = "Sorry.You are not old enough to vote!";
            }
            return View();
        }
        public IActionResult MyPartialView()
        {
            return View();
        }
        public IActionResult ViewComponent()
        {
            return View();
        }

        public IActionResult TagHelpers()
        {
            ViewBag.Title = "Tag Helpers";
            Person person = new Person();
            return View(person);
        }
        public IActionResult CustomTagHelpers()
        {
            return View();
        }

    }
}
