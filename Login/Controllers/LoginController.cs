using WebDBApp.Database;
using WebDBApp.Extensions;
using WebDBApp.Helpers;
using WebDBApp.Interfaces;
using WebDBApp.Models;
using WebDBApp.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace WebDBApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IHashHelper _hashHelper;

        public LoginController(IUnitOfWork unitOfWork,  IHashHelper hashHelper)
        {
            _unitOfWork = unitOfWork;
            _hashHelper = hashHelper;
            //logger.Trace("Sample trace message");
            //logger.Debug("Sample debug message");
            //logger.Info("Sample informational message");
            //logger.Warn("Sample warning message");
            //logger.Error("Sample error message");
            //logger.Fatal("Sample fatal error message");
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
            using (var dbContext = new AppDbContext())
            {
                var user = _unitOfWork.UserRepository.All().FirstOrDefault(usr => usr.Login == login && !usr.IsFrozen);
                if (user == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("~/Views/PartialViews/Error.cshtml", "Niepoprawny login lub hasło, bądź konto jest zamrożone");
                }
                if (!string.Equals(_hashHelper.Compute(password, user.Salt), user.Password))
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("~/Views/PartialViews/Error.cshtml", "Niepoprawny login lub hasło, bądź konto jest zamrożone.");
                }
                
                FormsAuthentication.SetAuthCookie(user.Login, false);
                SessionHelper.SetLogin(user.Login,user.Role.Name);
                return RedirectToAction("Index", "Home");
            }
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
                var role = _unitOfWork.RoleRepository.Find("Klient");
                _unitOfWork.UserRepository.Add(viewModel,role);
                
                EmailHelper.SendEmail(new EmailAccount()
                {
                    Email = viewModel.Email,
                    Subject = "Rejestracja nowego konta",
                    Request = EmailHelper.GetNewAccountCreatedMessage(viewModel)
                });

                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                logger.Error(e, e.Message);
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
                _unitOfWork.UserRepository.ResetPassword(resetRequest);
                _unitOfWork.SaveChanges();               
                return PartialView("~/Views/Login/Index.cshtml");
            }
            catch(Exception e)
            {
                logger.Error(e, e.Message);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("~/Views/PartialViews/Error.cshtml", e.Message);
            }            
        }                

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult IsEmail_Available(string email)
        {
            if (!_unitOfWork.UserRepository.All().Any(user => user.Email == email))
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
            if (!_unitOfWork.UserRepository.All().Any(user => user.Login == login))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            string suggestedLogin = String.Format(CultureInfo.InvariantCulture,
                "{0} jest niedostępny.", login);

            Random rnd = new Random();
            for (int i = 1; i < 100; i++)
            {
                string altCandidate = login + rnd.Next(i, i + 1000).ToString();
                if (!_unitOfWork.UserRepository.All().Any(user => user.Login == altCandidate))
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