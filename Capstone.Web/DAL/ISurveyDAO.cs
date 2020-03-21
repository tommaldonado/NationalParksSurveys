using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAO
    {
          IList <Survey> GetAllSurveys();

        bool SaveNewSurvey(Survey survey);

        Dictionary<string, int> GetSurveyResults();
    }
}
