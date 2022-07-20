using Asteria.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Asteria.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginPage()
        {
            if (HttpContext.Session.TryGetValue("IsLoggIn", out var Hold) && HttpContext.Session.Get<bool>("IsLoggIn"))
            {
                return Redirect(Url.Action("Index", "Home") ?? Constants.ErrorRoute);
            }

            return View();
        }

        public JsonResult LoginVerification(string APIKey)
        {
            string URL = "https://api.nasa.gov/mars-photos/api/v1/rovers?api_key=" + APIKey;

            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync(URL).Result;

            if (response.IsSuccessStatusCode)
            {
                HttpContext.Session.Set<bool>("IsLoggIn", true);
                HttpContext.Session.Set("APIKey", APIKey);
                return Json(new { response = true });
            }
            else
            {
                return Json(new { response = false });
            }
        }
    }
}
