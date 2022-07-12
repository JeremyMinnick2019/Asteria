using Asteria.Classes;
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
            if (!HttpContext.Session.TryGetValue("IsLoggIn", out var Hold) || !HttpContext.Session.Get<bool>("IsLoggIn"))
            {
                return Redirect(Url.Action("LoginPage", "Login"));
            }

            return View();
        }

    }
}