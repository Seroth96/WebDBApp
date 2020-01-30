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
    public class NewRoomViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double SurfaceArea { get; set; }

        public IEnumerable<Building> Buildings { get; set; }
        public List<SelectListItem> choices { get; set; }
        public int SelectedBuilding { get; set; }


        public NewRoomViewModel()
        {
            choices = new List<SelectListItem>();

        }

    }
}