﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public interface IWeatherDAO
    {
          List <Weather> GetWeather(string parkCode);
    }
}
