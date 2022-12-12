using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP3.Models;

namespace TP3.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
       
        public IActionResult Search()
        {
            return View();
        }

    }
}