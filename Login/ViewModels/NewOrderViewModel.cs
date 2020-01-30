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
    public class NewOrderViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Amount { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsRejected { get; set; } = false;

        public IEnumerable<Building> Buildings { get; set; }
        public int SelectedBuilding { get; set; }
        public int SelectedRoom { get; set; }

    }
}