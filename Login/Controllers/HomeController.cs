using WebDBApp.Service_References.Annotation;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Database;
using WebDBApp.ViewModels;
using WebDBApp.Interfaces;
using System.Net;

namespace WebDBApp.Controllers
{
    [SessionExpireFilter]
    public class HomeController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel(_unitOfWork);
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult NewGym()
        {
            var viewModel = new GymViewModel();
            return View(viewModel);
        }

        [HttpGet]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult EditGym(int id)
        {
            var viewModel = new GymViewModel();
            var gym = _unitOfWork.GymRepository.Find(id);
            viewModel.ID = gym.ID;
            viewModel.Name = gym.GymDetails.Name;
            viewModel.Address = gym.GymDetails.Address;
            viewModel.Email = gym.GymDetails.Email;
            viewModel.ContactPhone = gym.GymDetails.ContactPhone;
            viewModel.Description = gym.GymDetails.Description;

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult EditGym(GymViewModel viewModel)
        {
            if (ModelState.IsValid)
            {                
                var oldGym = _unitOfWork.GymRepository.Find(viewModel.ID);

                oldGym.GymDetails.Name = viewModel.Name;
                oldGym.GymDetails.Address = viewModel.Address;
                oldGym.GymDetails.Email = viewModel.Email;
                oldGym.GymDetails.ContactPhone = viewModel.ContactPhone;
                oldGym.GymDetails.Description = viewModel.Description;               


                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult DeleteGym(int id)
        {
            if (ModelState.IsValid)
            {
                var oldGym = _unitOfWork.GymRepository.Find(id);

                oldGym.GymDetails = null;
                _unitOfWork.GymRepository.Remove(id);


                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult NewGym(GymViewModel viewModel)
        {
            try
            {
                MTABEntities entities = new MTABEntities();
                entities.newGym(viewModel.Name, viewModel.Address, viewModel.Description, viewModel.ContactPhone, viewModel.Email);
            }
            catch(Exception ex)
            {
                logger.Error(ex, ex.Message);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("~/Views/PartialViews/Error.cshtml", ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}