using WebDBApp.Service_References.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDBApp.Models;

namespace WebDBApp.ViewModels
{
    public class NewHallViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double SurfaceArea { get; set; }

        public IEnumerable<Gym> Gyms { get; set; }
        public List<SelectListItem> choices { get; set; }
        public int SelectedGym { get; set; }


        public NewHallViewModel()
        {
            choices = new List<SelectListItem>();

        }

    }
}