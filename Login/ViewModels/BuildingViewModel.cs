using WebDBApp.Service_References.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDBApp.ViewModels
{
    public class BuildingViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactPhone { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Niepoprawny format")]
        public string Email { get; set; }
    }
}