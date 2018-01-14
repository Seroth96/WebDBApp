﻿using WebDBApp.Service_References.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDBApp.ViewModels
{
    public class NewOrderViewModel
    {
        [CustomRequired]
        public int ID { get; set; }
        [CustomRequired]
        public string Title { get; set; }
        public string Description { get; set; }
        [CustomRequired]
        public int Amount { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsRejected { get; set; } = false;
    }
}