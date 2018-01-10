using Login.Database;
using Login.Extensions;
using Login.Helpers;
using Login.Interfaces;
using Login.Models;
using Login.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace Login.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashHelper _hashHelper;

        public LoginController(IUnitOfWork unitOfWork,  IHashHelper hashHelper)
        {
            _unitOfWork = unitOfWork;
            _hashHelper = hashHelper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.Response.Cache.SetNoStore();

            return View(new User());
        }

        [HttpGet]
        public ActionResult IndexPartial()
        {
            return PartialView("~/Views/Login/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            //  if (!password.Any(c => char.IsUpper(c)) || !password.Any(c => char.IsNumber(c)))
            //     return Content("Hasło musi zawierać przynajmniej jedną wielką literę i cyfrę");
            //using (var dbContext = new LoginDbContext())
            // {
            // var user = _unitOfWork.UserRepository.All().FirstOrDefault(usr => usr.Login == login && !usr.IsFrozen);
            User user = null;
            if (login.Equals("test") && password.Equals("test"))
            {
                user = new User();
                user.Email = "pbokotko@gmail.com";
                user.FirstName = "Jan";
                user.LastName = "Testowy";
                user.Salt = _hashHelper.GetSalt();
                user.Password = _hashHelper.Compute("test", user.Salt);
                user.Login = "test";
                user.PasswordCreated = DateTime.Now;
            }

                if (user == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("~/Views/PartialViews/Error.cshtml", "Niepoprawny login lub hasło");
                }
                if (user.IsPasswordExpired())
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("~/Views/PartialViews/Error.cshtml", "Hasło wygasło. Musisz je zresetować.");
                }                    
                if (!string.Equals(_hashHelper.Compute(password, user.Salt), user.Password))
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("~/Views/PartialViews/Error.cshtml", "Niepoprawny login lub hasło, bądź konto jest zamrożone.");

                }
                //  if (DateTime.Now.Subtract(user.PasswordCreated.Value).Days > 30)
                //      return Content("Hasło wygasło, poproś o nowe");
                FormsAuthentication.SetAuthCookie(user.Login, false);
                SessionHelper.SetLogin(login);
                return new EmptyResult();
           // }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View("~/Views/Login/Register.cshtml", new RegisterAccountViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterAccountViewModel viewModel)
        {
            try
            {
                //_unitOfWork.UserRepository.Add(viewModel);
                
                EmailHelper.SendEmail(new EmailAccount()
                {
                    Email = viewModel.Email,
                    Subject = "Rejestracja nowego konta",
                    Request = EmailHelper.GetNewAccountCreatedMessage(viewModel)
                });

                //_unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("~/Views/PartialViews/Error.cshtml", e.Message);
            }
            
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View("~/Views/Login/ResetPassword.cshtml");
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordRequestViewModel resetRequest)
        {
            try
            {
                resetRequest.Date = DateTime.Now;
                //_unitOfWork.UserRepository.ResetPassword(resetRequest);
                //_unitOfWork.SaveChanges();               
                return PartialView("~/Views/Login/Index.cshtml");
            }
            catch(Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("~/Views/PartialViews/Error.cshtml", e.Message);
            }            
        }                

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult IsEmail_Available(string email)
        {
            //if (!_unitOfWork.UserRepository.All().Any(user => user.Email == email))
            if (!email.Equals("pbokotko@gmail.com"))//TODO: zmienić, żeby sprawdzało email
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }              

            string suggestedEmail = String.Format(CultureInfo.InvariantCulture,
                "{0} jest niedostępny.", email);

            return Json(suggestedEmail, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult IsLogin_Available(string login)
        {

            if (!login.Equals("test"))//TODO: zmienić, żeby sprawdzało login
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            string suggestedLogin = String.Format(CultureInfo.InvariantCulture,
                "{0} jest niedostępny.", login);

            Random rnd = new Random();
            for (int i = 1; i < 100; i++)
            {
                string altCandidate = login + rnd.Next(i, i + 1000).ToString();
                if (altCandidate.Equals("test"))//TODO: zmienić, żeby sprawdzało login
                {
                    suggestedLogin = String.Format(CultureInfo.InvariantCulture,
                   "{0} jest niedostępny. Spróbuj {1}.", login, altCandidate);
                    break;
                }
            }
            return Json(suggestedLogin, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}