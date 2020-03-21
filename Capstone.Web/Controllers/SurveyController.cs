using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Capstone.Web.Extensions;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAO surveyDao;
        private INationalParkDAO NPD;

        private IDictionary<string, int> SurveyResults { get; set; }

        public SurveyController(ISurveyDAO s, INationalParkDAO np)
        {
            this.surveyDao = s;
            this.SurveyResults = surveyDao.GetSurveyResults();
            this.NPD = np;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewSurvey(Survey survey)
        {
            bool worked = surveyDao.SaveNewSurvey(survey);
            if (worked)
            {
                return RedirectToAction("Results");
            }
           
            return View("Index");
            
        }

        public IActionResult Results()
        {
            ViewData["get-parks"] = NPD.GetAllNationalParks();
            ViewData["surveys"] = surveyDao.GetSurveyResults();
            return View("Results");
        }
    }
}
