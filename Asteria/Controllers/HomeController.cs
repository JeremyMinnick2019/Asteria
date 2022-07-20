using Asteria.Classes;
using Asteria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

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
                return Redirect(Url.Action("LoginPage", "Login") ?? Constants.ErrorRoute);
            }

            APOD PictureOfTheDayValue = GetPictureOfTheDay();

            return View(PictureOfTheDayValue);
        }

        

        public APOD GetPictureOfTheDay() 
        {
            string? APIKey = HttpContext.Session.Get<string>("APIKey");

            string URL = $"https://api.nasa.gov/planetary/apod?api_key={APIKey}";

            HttpClient Client = new HttpClient();

            HttpResponseMessage Resp = Client.GetAsync(URL).Result;

            string Obj = Resp.Content.ReadAsStringAsync().Result;

            JObject PicOfDayObj = JObject.Parse(Obj);

            APOD APODInfo = new APOD()
            {
                CopyRight = (string?)PicOfDayObj["copyright"],
                Date = (string?)PicOfDayObj["date"],
                Explanation = (string?)PicOfDayObj["explanation"],
                Hdurl = PhotoLinkToByteArray((string?)PicOfDayObj["hdurl"]),
                MediaType = (string?)PicOfDayObj["media_type"],
                Title = (string?)PicOfDayObj["title"],
            };

            return APODInfo;
        }

        public byte[]? PhotoLinkToByteArray(string? Link)
        {
            if(string.IsNullOrWhiteSpace(Link))
                return null;

            HttpClient Client = new HttpClient();

            return Client.GetByteArrayAsync(Link).Result;
        }
    }
}