using WebDBApp.Service_References.Annotation;
using WebDBApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDBApp.Database;
using WebDBApp.Interfaces;
using NLog;

namespace WebDBApp.ViewModels
{
    public class NewCalendarEventViewModel 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<EventType> Types { get; set; }
        public List<SelectListItem> choices { get; set; }
        public int SelectedType { get; set; }

        [CustomRequired]
        public int ID { get; set; }
        [CustomRequired]
        public string Title { get; set; }
        [CustomRequired]
        public string Description { get; set; }
        [CustomRequired]
        public DateTime StartAt { get; set; }
        [CustomRequired]
        public DateTime EndAt { get; set; }    
          
        public User Trainer { get; set; }


        

        public NewCalendarEventViewModel()
        {
            choices = new List<SelectListItem>();

        }

        

    }
}