using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private readonly string connectionString;

        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Weather> GetWeather(string parkCode)
        {
            
            List<Weather> forecast = new List<Weather>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(($"SELECT * FROM weather WHERE parkCode = @parkCode;"), conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    //(order by review_title??)

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a review 
                        Weather day = new Weather();
                        day.ParkCode = Convert.ToString(reader["parkCode"]);
                        day.FiveDayForecast = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        day.Low = Convert.ToInt32(reader["low"]);
                        day.High = Convert.ToInt32(reader["high"]);
                        day.Forecast = Convert.ToString(reader["forecast"]);
                        if(day.Forecast.Contains(" "))
                        {
                            string[] noSpaces = day.Forecast.Split(" ");
                            char[] secondWord = noSpaces[1].ToCharArray();
                            secondWord[0] = char.ToUpper(secondWord[0]);
                            string secondPart = noSpaces[1].ToString().Substring(1);
                            string firstWord = noSpaces[0].ToString();

                            day.Forecast = firstWord + char.ToUpper(secondWord[0]).ToString() + secondPart;
                        }
                        
                        forecast.Add(day);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return forecast;
        }


    }
}
