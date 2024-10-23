using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WhiteBlackList.Web.Filters;
using WhiteBlackList.Web.Models;

namespace WhiteBlackList.Web.Controllers
{
   // [ServiceFilter(typeof(CheckWhiteList))]  - Controller Level
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [ServiceFilter(typeof(CheckWhiteList))] //Method Level
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
    }
}
