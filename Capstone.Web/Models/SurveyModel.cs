﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        [Required]
        [EmailAddress, Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "State of Residence")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Activity Level")]
        public string ActivityLevel { get; set; }

        [Required]
        [Display(Name="Your Favorite Park")]
        public string ParkCode { get; set; }

        [Required]
        public static List<SelectListItem> states = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "", Value = ""},
            new SelectListItem() { Text = "Alabama", Value = "Alabama"},
            new SelectListItem() { Text = "Alaska", Value = "Alaska"},
            new SelectListItem() { Text = "Arizona", Value = "Arizona"},
            new SelectListItem() { Text = "Arkansas", Value = "Arkansas"},
            new SelectListItem() { Text = "California", Value = "California"},
            new SelectListItem() { Text = "Colorado", Value = "Colorado"},
            new SelectListItem() { Text = "Connecticut", Value = "Connecticut"},
            new SelectListItem() { Text = "Delaware", Value = "Delaware"},
            new SelectListItem() { Text = "Florida", Value = "Florida"},
            new SelectListItem() { Text = "Georgia", Value = "Georgia"},
            new SelectListItem() { Text = "Hawaii", Value = "Hawaii"},
            new SelectListItem() { Text = "Idaho", Value = "Idaho"},
            new SelectListItem() { Text = "Illinois", Value = "Illinois"},
            new SelectListItem() { Text = "Indiana", Value = "Indiana"},
            new SelectListItem() { Text = "Iowa", Value = "Iowa"},
            new SelectListItem() { Text = "Kansas", Value = "Kansas"},
            new SelectListItem() { Text = "Kentucky", Value = "Kentucky"},
            new SelectListItem() { Text = "Louisiana", Value = "Louisiana"},
            new SelectListItem() { Text = "Maine", Value = "Maine"},
            new SelectListItem() { Text = "Maryland", Value = "Maryland"},
            new SelectListItem() { Text = "Massachusetts", Value = "Massachusetts"},
            new SelectListItem() { Text = "Michigan", Value = "Michigan"},
            new SelectListItem() { Text = "Minnesota", Value = "Minnesota"},
            new SelectListItem() { Text = "Mississipi", Value = "Mississipi"},
            new SelectListItem() { Text = "Missouri", Value = "Missouri"},
            new SelectListItem() { Text = "Montana", Value = "Montana"},
            new SelectListItem() { Text = "Nebraska", Value = "Nebraska"},
            new SelectListItem() { Text = "Nevada", Value = "Nevada"},
            new SelectListItem() { Text = "New Hampshire", Value = "New Hampshire"},
            new SelectListItem() { Text = "New Jersey", Value = "New Jersey"},
            new SelectListItem() { Text = "New Mexico", Value = "New Mexico"},
            new SelectListItem() { Text = "New York", Value = "New York"},
            new SelectListItem() { Text = "North Dakota", Value = "North Dakota"},
            new SelectListItem() { Text = "North Carolina", Value = "North Carolina"},
            new SelectListItem() { Text = "Ohio", Value = "Ohio"},
            new SelectListItem() { Text = "Oklahoma", Value = "Oklahoma"},
            new SelectListItem() { Text = "Oregon", Value = "Oregon"},
            new SelectListItem() { Text = "Pennsylvania", Value = "Pennsylvania"},
            new SelectListItem() { Text = "Rhode Island", Value = "Rhode Island"},
            new SelectListItem() { Text = "South Carolina", Value = "South Carolina"},
            new SelectListItem() { Text = "South Dakota", Value = "Connecticut"},
            new SelectListItem() { Text = "Tennessee", Value = "Tennessee"},
            new SelectListItem() { Text = "Texas", Value = "Texas"},
            new SelectListItem() { Text = "Utah", Value = "Utah"},
            new SelectListItem() { Text = "Vermont", Value = "Vermont"},
            new SelectListItem() { Text = "Virginia", Value = "Virginia"},
            new SelectListItem() { Text = "Washington", Value = "Washington"},
            new SelectListItem() { Text = "West Virginia", Value = "West Virginia"},
            new SelectListItem() { Text = "Wisconsin", Value = "Wisconsin"},
            new SelectListItem() { Text = "Wyoming", Value = "Wyoming"}
        };

        [Required]
        public static List<SelectListItem> nationalParks = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "", Value =""},
            new SelectListItem() { Text = "Cuyahoga Valley National Park", Value = "CVNP"},
            new SelectListItem() { Text = "Everglades National Park", Value = "ENP"},
            new SelectListItem() { Text = "Grand Canyon National Park", Value = "GCNP"},
            new SelectListItem() { Text = "Glacier National Park", Value = "GNP"},
            new SelectListItem() { Text = "Great Smokey Mountains National Park", Value = "GSMNP"},
            new SelectListItem() { Text = "Grand Teton National Park", Value = "GTNP"},
            new SelectListItem() { Text = "Mount Rainier National Park", Value = "MRNP"},
            new SelectListItem() { Text = "Rocky Mountain National Park", Value = "RMNP"},
            new SelectListItem() { Text = "Yellowstone National Park", Value = "YNP"},
            new SelectListItem() { Text = "Yosemite National Park", Value = "YNP2"},

        };

        [Required]
        public static List<SelectListItem> activyLevel = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "", Value = ""},
            new SelectListItem() { Text = "Inactive", Value = "Inactive"},
            new SelectListItem() { Text = "Sedentary", Value = "Sedentary"},
            new SelectListItem() { Text = "Active", Value = "Active"},
            new SelectListItem() { Text = "Extremely Active", Value = "Extremely Active"},

        };

    }




}
