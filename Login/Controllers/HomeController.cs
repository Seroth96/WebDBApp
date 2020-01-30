using WebDBApp.Service_References.Annotation;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDBApp.ViewModels;
using WebDBApp.Interfaces;
using System.Net;
using WebDBApp.Models;

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
        public ActionResult NewBuilding()
        {
            var viewModel = new BuildingViewModel();
            return View(viewModel);
        }

        [HttpGet]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult EditBuilding(int id)
        {
            var viewModel = new BuildingViewModel();
            var building = _unitOfWork.BuildingRepository.Find(id);
            viewModel.ID = building.ID;
            viewModel.Name = building.BuildingDetails.Name;
            viewModel.Address = building.BuildingDetails.Address;
            viewModel.Email = building.BuildingDetails.Email;
            viewModel.ContactPhone = building.BuildingDetails.ContactPhone;
            viewModel.Description = building.BuildingDetails.Description;

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult EditBuilding(BuildingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {                
                var oldBuilding = _unitOfWork.BuildingRepository.Find(viewModel.ID);

                oldBuilding.BuildingDetails.Name = viewModel.Name;
                oldBuilding.BuildingDetails.Address = viewModel.Address;
                oldBuilding.BuildingDetails.Email = viewModel.Email;
                oldBuilding.BuildingDetails.ContactPhone = viewModel.ContactPhone;
                oldBuilding.BuildingDetails.Description = viewModel.Description;               


                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult DeleteBuilding(int id)
        {
            if (ModelState.IsValid)
            {
                var oldBuilding = _unitOfWork.BuildingRepository.Find(id);

                oldBuilding.BuildingDetails = null;
                _unitOfWork.BuildingRepository.Remove(id);


                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult NewBuilding(BuildingViewModel viewModel)
        {
            try
            {
                var building = new Building
                {
                    BuildingDetails = new BuildingDetails
                    {
                        Name = viewModel.Name,
                        Address = viewModel.Address,
                        Description = viewModel.Description,
                        ContactPhone = viewModel.ContactPhone,
                        Email = viewModel.Email
                    },
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            Name = "Main",
                            SurfaceArea = 50
                        }
                    }
                };

                _unitOfWork.BuildingRepository.Add(building);

                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("~/Views/PartialViews/Error.cshtml", ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}