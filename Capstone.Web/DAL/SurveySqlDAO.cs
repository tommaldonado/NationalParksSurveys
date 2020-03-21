using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAO : ISurveyDAO
    {
        private readonly string connectionString;

        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Survey> GetAllSurveys()
        {

            List<Survey> output = new List<Survey>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM survey_result";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a survey
                        Survey s = new Survey();
                        s.ParkCode = Convert.ToString(reader["parkCode"]);
                        s.Email = Convert.ToString(reader["emailAddress"]);
                        s.State = Convert.ToString(reader["state"]);
                        s.ActivityLevel = Convert.ToString(reader["activityLevel"]);                        

                        output.Add(s);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        public bool SaveNewSurvey(Survey survey)
        {
            bool isSaved = false;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    var sql = $"INSERT into survey_result(parkCode,emailAddress,state,activityLevel) values(@parkCode, @emailAddress, @state, @activityLevel)";
                    var cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();
                    isSaved = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isSaved;
        }

        public Dictionary<string, int> GetSurveyResults()
        {
            Dictionary<string, int> surveyResults = new Dictionary<string, int>();
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT parkCode, COUNT(parkCode) AS number_votes FROM survey_result GROUP BY parkCode ORDER BY number_votes DESC";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        surveyResults.Add(Convert.ToString(reader["parkCode"]), Convert.ToInt32(reader["number_votes"]));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return surveyResults;
        }
    }
}
