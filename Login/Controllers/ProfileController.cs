using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDBApp.Enum;
using WebDBApp.Helpers;
using WebDBApp.Interfaces;
using WebDBApp.Service_References.Annotation;
using WebDBApp.ViewModels;

namespace Login.Controllers
{
    public class ProfileController : Controller
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;

        public ProfileController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            //var viewModel = new ProfileViewModel(_unitOfWork);
            var login = SessionHelper.GetElement<string>(SessionElement.Login);
            var user = _unitOfWork.UserRepository.Find(login);

            // viewModel.SetTestsforUser(user);//All orders for current user

            var viewModel = new CalendarEventsViewModel(_unitOfWork);
            viewModel.SetEventsForUser(user);

            return View(viewModel);
        }        


    }
}