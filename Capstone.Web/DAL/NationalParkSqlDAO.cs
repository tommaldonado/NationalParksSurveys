using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class NationalParkSqlDAO : INationalParkDAO
    {
        private readonly string connectionString;

        public NationalParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<NationalPark> GetAllNationalParks()
        {

            List<NationalPark> output = new List<NationalPark>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM park";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    //(order by review_title??)

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a review
                        NationalPark park = new NationalPark();
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
                        park.MilesTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        park.NumberCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        park.AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.Quote = Convert.ToString(reader["inspirationalQuote"]);
                        park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        park.NumberAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

                        output.Add(park);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        public NationalPark GetNationalPark(string parkCode)
        {
            NationalPark park = new NationalPark();

            try
            {

                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(($"SELECT * FROM park WHERE parkCode = @parkCode;"), conn) ;
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    //SqlCommand cmd = new SqlCommand(sql, conn);

                    //(order by review_title??)

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();


                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a review
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
                        park.MilesTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        park.NumberCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        park.AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.Quote = Convert.ToString(reader["inspirationalQuote"]);
                        park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        park.NumberAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        park.Longitude = Convert.ToString(reader["longitude"]);
                        park.Latitude = Convert.ToString(reader["latitude"]);



                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return park;
        }
    }
}
