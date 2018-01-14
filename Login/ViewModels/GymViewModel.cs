using WebDBApp.Service_References.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDBApp.ViewModels
{
    public class GymViewModel
    {
        [CustomRequired]
        public int ID { get; set; }
        [CustomRequired]
        public string Name { get; set; }
        [CustomRequired]
        public string Description { get; set; }
        [CustomRequired]
        public string Address { get; set; }
        [CustomRequired]
        public string ContactPhone { get; set; }
        [CustomRequired]
        [EmailAddress(ErrorMessage = "Niepoprawny format")]
        public string Email { get; set; }
    }
}