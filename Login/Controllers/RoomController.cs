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
using Newtonsoft.Json;

namespace WebDBApp.Controllers
{
    [SessionExpireFilter]
    public class RoomController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;

        public RoomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new RoomViewModel(_unitOfWork);
            return View(viewModel);
        }

        [HttpGet]
        public string GetRoomsByBuilding(int id)
        {
            var rooms = _unitOfWork.BuildingRepository.Find(id).Rooms.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.ID.ToString()
            });

            var roomslist = new List<SelectListItem>();
            roomslist.AddRange(rooms);

            string json = JsonConvert.SerializeObject(roomslist);

            return json;
        }

        [HttpGet]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult NewRoom()
        {
            var viewModel = new NewRoomViewModel();
            viewModel.Buildings = _unitOfWork.BuildingRepository.All();
            var x = viewModel.Buildings.Select(r => new SelectListItem
            {
                Text = r.BuildingDetails.Name,
                Value = r.ID.ToString()
            });
            viewModel.choices.AddRange(x);

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult NewRoom(NewRoomViewModel viewModel)
        {
            try
            {
                var room = new Room
                {
                    Name = viewModel.Name,
                    SurfaceArea = viewModel.SurfaceArea
                };
                var gym = _unitOfWork.BuildingRepository.Find(viewModel.SelectedBuilding);
                gym.Rooms.Add(room);

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
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult EditRoom(int id)
        {
            var viewModel = new NewRoomViewModel();
            viewModel.Buildings = _unitOfWork.BuildingRepository.All();
            var x = viewModel.Buildings.Select(r => new SelectListItem
            {
                Text = r.BuildingDetails.Name,
                Value = r.ID.ToString()
            });
            viewModel.choices.AddRange(x);
            var room = _unitOfWork.RoomRepository.Find(id);
            viewModel.ID = room.ID;
            viewModel.Name = room.Name;
            viewModel.SurfaceArea = room.SurfaceArea;

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult EditRoom(NewRoomViewModel viewModel)
        {
            if (ModelState.IsValid)
            {             
                var building = _unitOfWork.BuildingRepository.All().First(g => g.ID == viewModel.SelectedBuilding);
                if (building.Rooms.Any(h => h.ID == viewModel.ID))
                {
                    var oldRoom = building.Rooms.First(room => room.ID == viewModel.ID);
                    oldRoom.Name = viewModel.Name;
                    oldRoom.SurfaceArea = viewModel.SurfaceArea;
                }
                else
                {
                    var Room = _unitOfWork.RoomRepository.All().First(d => d.ID == viewModel.ID);
                    Room.Building = null;
                    building.Rooms.Add(Room);
                }
                

                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult DeleteRoom(int id)
        {
            if (ModelState.IsValid)
            {
                var oldRoom = _unitOfWork.RoomRepository.Find(id);
                
                oldRoom.Accessories = null;
                _unitOfWork.RoomRepository.Remove(id);


                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        
    }
}