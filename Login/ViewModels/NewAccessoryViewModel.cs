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
    public class NewAccessoryViewModel
    {
        [CustomRequired]
        public string Name { get; set; }
        [CustomRequired]
        public string Description { get; set; }

        public Hall Hall { get; set; }


        public NewAccessoryViewModel()
        {

        }

    }
}