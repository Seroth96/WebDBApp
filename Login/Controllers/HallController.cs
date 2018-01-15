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
using WebDBApp.Models;

namespace WebDBApp.Controllers
{
    [SessionExpireFilter]
    public class HallController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;

        public HallController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new HallViewModel(_unitOfWork);
            return View(viewModel);
        }

        [HttpGet]
        [CheckSession(Role = new string[] { "Administrator", "Pracownik" })]
        public ActionResult NewHall()
        {
            var viewModel = new NewHallViewModel();
            viewModel.Gyms = _unitOfWork.GymRepository.All();
            var x = viewModel.Gyms.Select(r => new SelectListItem
            {
                Text = r.GymDetails.Name,
                Value = r.ID.ToString()
            });
            viewModel.choices.AddRange(x);

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Administrator", "Pracownik" })]
        public ActionResult NewHall(NewHallViewModel viewModel)
        {
            try
            {
                var hall = new Hall
                {
                    Name = viewModel.Name,
                    SurfaceArea = viewModel.SurfaceArea
                };
                var gym = _unitOfWork.GymRepository.Find(viewModel.SelectedGym);
                gym.Halls.Add(hall);

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

        [HttpGet]
        [CheckSession(Role = new string[] { "Administrator", "Pracownik" })]
        public ActionResult EditHall(int id)
        {
            var viewModel = new NewHallViewModel();
            viewModel.Gyms = _unitOfWork.GymRepository.All();
            var x = viewModel.Gyms.Select(r => new SelectListItem
            {
                Text = r.GymDetails.Name,
                Value = r.ID.ToString()
            });
            viewModel.choices.AddRange(x);
            var hall = _unitOfWork.HallRepository.Find(id);
            viewModel.ID = hall.ID;
            viewModel.Name = hall.Name;
            viewModel.SurfaceArea = hall.SurfaceArea;

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Administrator", "Pracownik" })]
        public ActionResult EditHall(NewHallViewModel viewModel)
        {
            if (ModelState.IsValid)
            {             
                var gym = _unitOfWork.GymRepository.All().First(g => g.ID == viewModel.SelectedGym);
                if (gym.Halls.Any(h => h.ID == viewModel.ID))
                {
                    var oldHall = gym.Halls.First(hall => hall.ID == viewModel.ID);
                    oldHall.Name = viewModel.Name;
                    oldHall.SurfaceArea = viewModel.SurfaceArea;
                }
                else
                {
                    var Hall = _unitOfWork.HallRepository.All().First(d => d.ID == viewModel.ID);
                    Hall.Gym = null;
                    gym.Halls.Add(Hall);
                }
                

                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Administrator", "Pracownik" })]
        public ActionResult DeleteHall(int id)
        {
            if (ModelState.IsValid)
            {
                var oldHall = _unitOfWork.HallRepository.Find(id);
                
                oldHall.Accessories = null;
                _unitOfWork.HallRepository.Remove(id);


                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        
    }
}