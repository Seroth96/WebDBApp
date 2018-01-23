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
    public class EditUserViewModel 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        //private readonly IUnitOfWork _unitOfWork;

        public User user { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public List<SelectListItem> choices { get; set; }

        public int? SelectedRole { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Remote("IsLogin_Available", "Login")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Login musi zawierać od 5 do 50 znaków.")]
        public string Login { get; set; }
        [Required]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[A-Z]).*$", ErrorMessage = "Hasło musi zawierać przynajmniej 8 znaków, w tym przynajmniej jedną cyfrę 0-9 oraz jedną dużą literę")]
        public string Password { get; set; }
        [Required]
        [Remote("IsEmail_Available", "Login")]
        [EmailAddress(ErrorMessage = "Niepoprawny format")]
        public string Email { get; set; }

        public EditUserViewModel(User user)
        {
            choices = new List<SelectListItem>();         

            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Password = user.Password;
            SelectedRole = user.Role.ID;
            Login = user.Login;

        }

        public EditUserViewModel()
        {

        }

    }
}