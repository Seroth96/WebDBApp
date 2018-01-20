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
    public class TestDataViewModel 
    {
        [CustomRequired]
        public int ID { get; set; }
        [CustomRequired]
        public double Result { get; set; }
        [CustomRequired]
        public double Age { get; set; }

    }
}