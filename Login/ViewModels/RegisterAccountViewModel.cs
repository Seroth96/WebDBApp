using WebDBApp.Service_References.Annotation;
using WebDBApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDBApp.Database;

namespace WebDBApp.ViewModels
{
    public class RegisterAccountViewModel 
    {        
        [CustomRequired]
        public string FirstName { get; set; }
        [CustomRequired]
        public string LastName { get; set; }
        [CustomRequired]
        [Remote("IsLogin_Available", "Login")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Login musi zawierać od 5 do 50 znaków.")]
        public string Login { get; set; }
        [CustomRequired]
        //[RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[A-Z]).*$", ErrorMessage = "Hasło musi zawierać przynajmniej 8 znaków, w tym przynajmniej jedną cyfrę 0-9 oraz jedną dużą literę")]
        public string Password { get; set; }
        [CustomRequired]
        [Remote("IsEmail_Available", "Login")]
        [EmailAddress(ErrorMessage = "Niepoprawny format")]
        public string Email { get; set; }

        [CustomRequired]
        //[RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[A-Z]).*$", ErrorMessage = "Hasło musi zawierać przynajmniej 8 znaków, w tym przynajmniej jedną cyfrę 0-9 oraz jedną dużą literę")]
        public bool Sex { get; set; }

        public RegisterAccountViewModel()
        {
        }
        
    }
}