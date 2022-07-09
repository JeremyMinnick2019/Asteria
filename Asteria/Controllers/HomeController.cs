using Asteria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Asteria.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}