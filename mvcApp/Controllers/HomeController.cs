using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using mvcApp.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace mvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var p = new BdPerson().GetPersons();
            return View(p);
        }
        [HttpGet]
        public IActionResult AddPerson(){
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person p){
            new BdPerson().InsertPerson(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SearchF(){
            return View();
        }
        [HttpPost]
        public IActionResult SearchF(Person p){
            var SelectedPerson = new BdPerson().GetPersonByFIO(p);
            return RedirectToAction("Index", new Person {Id = SelectedPerson[0].Id, FirstName = SelectedPerson[0].FirstName, MiddleName = SelectedPerson[0].MiddleName, LastName = SelectedPerson[0].LastName});
        }
        
    }
}
