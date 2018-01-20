using WebDBApp.Service_References.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDBApp.ViewModels
{
    public class ResetPasswordRequestViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [EmailAddress(ErrorMessage = "Niepoprawny format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        public DateTime? Date { get; set; }
    }
}