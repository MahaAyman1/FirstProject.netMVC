using Fashion.Data;
using Fashion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Fashion.Controllers
{
    public class HomeController : Controller
    {
        private FDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, FDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext; 
        }

        public IActionResult Index()
        {
            var products = _dbContext.Products.Take(3).ToList();

            return View(products);
        }
        public IActionResult FAQS()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();  

        }

        
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Story() { 
            return View(_dbContext.Employees.Include(c => c.Department).ToList());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
