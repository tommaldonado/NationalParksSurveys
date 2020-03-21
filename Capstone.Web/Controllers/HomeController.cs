using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Capstone.Web.Extensions;
using static Capstone.Web.Models.WeatherAPI;
using System.Net.Http;
using Newtonsoft.Json;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private INationalParkDAO NPD;
        private IWeatherDAO WD;
        public HomeController(INationalParkDAO nationalP, IWeatherDAO weather)
        {
            this.NPD = nationalP;
            this.WD = weather;
        }

        public IActionResult Index()
        {
            ViewData["get-parks"] = NPD.GetAllNationalParks();
            return View("Index");
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> Detail(string parkCode)
        {
            NationalPark park = NPD.GetNationalPark(parkCode);
            string lat = park.Latitude;
            string longi = park.Longitude;

            //List <Weather> weatherForPark = WD.GetWeather(parkCode);
            Datum2[] arrayOfWeathers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.darksky.net/");
                //HTTP GET
                var responseTask = client.GetAsync($"forecast/8763304943d537b219b0eae054152e90/{lat},{longi}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    arrayOfWeathers = JsonConvert.DeserializeObject<Rootobject>(content).daily.data;
                }
            }


            for (int i = 0; i < arrayOfWeathers.Length - 1; i++)
            {
                Weather w = new Weather();
                w.Low = Convert.ToInt32(arrayOfWeathers[i].temperatureLow);
                w.High = Convert.ToInt32(arrayOfWeathers[i].temperatureHigh);
                w.Forecast = (arrayOfWeathers[i].icon);
                w.FiveDayForecast = i + 1;
                w.ParkCode = parkCode;
                park.forecasts.Add(w);
            }

            //park.forecasts = arrayOfWeathers;
            ViewData["user_preferences"] = GetUserPreferences();
            return View("Detail", park);
        }

        public IActionResult SwitchTempType(string parkCode)
        {
            UserPreferences p = GetUserPreferences();
            // NationalPark park = GetActiveNationalPark();
            if (p.isFarenheit == true)
            {
                p.isFarenheit = false;
            }
            else if(p.isFarenheit == false)
            {
                p.isFarenheit = true;
            }

            SaveUserPreferences(p);

            return RedirectToAction( "detail","home", new { parkCode = parkCode });
        }

        private UserPreferences GetUserPreferences()
        {
            UserPreferences up = HttpContext.Session.Get<UserPreferences>("User_Preferences");
            if (up == null) //the shopping cart does NOT exist
            {
                up = new UserPreferences();
                SaveUserPreferences(up);
            }
            return up;
        }

        private void SaveUserPreferences(UserPreferences up)
        {
            HttpContext.Session.Set("User_Preferences", up);
        }
    }
}
