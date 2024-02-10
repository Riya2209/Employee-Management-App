using Employee_Management_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Employee_Management_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContext _context;
        private readonly string _dataFilePath;

        public HomeController(ILogger<HomeController> logger, DbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _context = context;
            _dataFilePath = Path.Combine(hostingEnvironment.ContentRootPath, "employees.json");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SaveEmployeeDetails(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", employee);
            }

            // Serialize the employee object to JSON
            string jsonData = JsonConvert.SerializeObject(employee);

            // Save the JSON data to a file
            System.IO.File.WriteAllText(_dataFilePath, jsonData);

            return RedirectToAction("Index");
        }
    }
}