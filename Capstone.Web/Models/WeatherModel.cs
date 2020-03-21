using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecast { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string GetMessage()
        {
            string message = "";

            if (Forecast.Contains("snow"))
            {
                message += "Pack snow shoes! ";
            }
            if (Forecast.Contains("rain"))
            {
                message += "Pack rain gear and wear waterproof shoes. ";
            }
            if (Forecast.Contains("thunderstorms"))
            {
                message += "Seek shelter and avoid hiking on exposed ridges. ";
            }
            if (Forecast.Contains("sunny"))
            {
                message += "Pack sunblock. ";
            }
            if (High >= 75)
            {
                message += "Bring an extra gallon of water. ";
            }
            if ((High - Low) > 20)
            {
                message += "Wear breathable layers. ";
            }
            if (Low < 20)
            {
                message += "You will be exposed to frigid temperatures. ";
            }
            return message;

        }
    }
}
