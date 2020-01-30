using WebDBApp.Models;
using WebDBApp.Service_References.Annotation;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using WebDBApp.ViewModels;
using WebDBApp.Interfaces;
using WebDBApp.Helpers;
using WebDBApp.Enum;
using System.Net;

namespace WebDBApp.Controllers
{
    [SessionExpireFilter]
    public class CalendarController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;

        public CalendarController(IUnitOfWork unitOfWork, IHashHelper hashHelper)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JoinEvent(int id)
        {
            var @event = _unitOfWork.CalendarEventsRepository.All().First(ev => ev.CalendarEventID == id);
            @event.Users.Add(_unitOfWork.UserRepository.Find(SessionHelper.GetElement<string>(SessionElement.Login)));

            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LeaveEvent(int id)
        {
            var @event = _unitOfWork.CalendarEventsRepository.All().First(ev => ev.CalendarEventID == id);
            @event.Users.Remove(_unitOfWork.UserRepository.Find(SessionHelper.GetElement<string>(SessionElement.Login)));

            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetEvents(string type)
        {
            var events = _unitOfWork.CalendarEventsRepository.All().Where(@event => @event.EventType.Name.Equals(type)).ToList();
            //var DidJoin = events.Any(ev => ev.Users.Any(user => user.Login.Equals(SessionHelper.GetElement<string>(SessionElement.Login))));
            var eventsFormatted = events.Select(x => new
            {
                ID = x.CalendarEventID,
                Title = x.Title,
                Description = x.Description,
                StartAt = x.StartAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                EndAt = x.EndAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                IsFullDay = x.IsFullDay,
                EventType = x.EventType,
                Owner = x.Owner.FullName,
                Building = x.Building.BuildingDetails.Name + ", " + x.Building.BuildingDetails.Address,
                Room = x.Room.Name,
                DidJoin = x.Users.Any(user => user.Login.Equals(SessionHelper.GetElement<string>(SessionElement.Login)))
            });

            var vv = eventsFormatted.OrderBy(a => a.StartAt).ToList();

            return new JsonResult { Data = vv, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public ActionResult OwnerEvent()
        {
            var viewModel = new CalendarEventsViewModel(_unitOfWork);
            var login = SessionHelper.GetElement<string>(SessionElement.Login);
            var user = _unitOfWork.UserRepository.Find(login);
            viewModel.SetEvents(user);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult NewEvent()
        {
            var viewModel = new NewCalendarEventViewModel();
            viewModel.Types = _unitOfWork.EventTypeRepository.All();
            var x = viewModel.Types.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.ID.ToString()
            });
            viewModel.choices.AddRange(x);
            viewModel.SelectedBuilding = 0;
            viewModel.Buildings = _unitOfWork.BuildingRepository.All();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult NewEvent(NewCalendarEventViewModel viewModel)
        {
            try
            {
                var login = SessionHelper.GetElement<string>(SessionElement.Login);
                _unitOfWork.CalendarEventsRepository.Add(new CalendarEvent
                {
                    Owner = _unitOfWork.UserRepository.Find(login),
                    StartAt = viewModel.StartAt,
                    EndAt = viewModel.EndAt,
                    Title = viewModel.Title,
                    EventType = _unitOfWork.EventTypeRepository.Find(viewModel.SelectedType),
                    Building = _unitOfWork.BuildingRepository.Find(viewModel.SelectedBuilding),
                    Room = _unitOfWork.RoomRepository.Find(viewModel.SelectedRoom),
                    Description = viewModel.Description            
                });

                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("~/Views/PartialViews/Error.cshtml", ex.Message);
            }
            return RedirectToAction("OwnerEvent");
        }


        [HttpGet]
        [CheckSession(Role = new string[] { "Organizator" })]
        public ActionResult EditEvent(int id)
        {
            var viewModel = new NewCalendarEventViewModel();
            viewModel.Types = _unitOfWork.EventTypeRepository.All();
            var x = viewModel.Types.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.ID.ToString()
            });
            viewModel.choices.AddRange(x);            
            viewModel.Buildings = _unitOfWork.BuildingRepository.All();
            var login = SessionHelper.GetElement<string>(SessionElement.Login);
            var user = _unitOfWork.UserRepository.Find(login);
            var @event = _unitOfWork.CalendarEventsRepository.All().First(d => d.CalendarEventID == id);
            viewModel.ID = @event.CalendarEventID;
            viewModel.Title = @event.Title;
            viewModel.Description = @event.Description;
            viewModel.StartAt = @event.StartAt;
            viewModel.EndAt = @event.EndAt;
            viewModel.SelectedType = @event.EventType.ID;
            viewModel.SelectedBuilding = @event.Building.ID;
            viewModel.SelectedRoom = @event.Room.ID;
            viewModel.Owner = user;

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Organizator" })]
        public ActionResult EditEvent(NewCalendarEventViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var login = SessionHelper.GetElement<string>(SessionElement.Login);
                var user = _unitOfWork.UserRepository.Find(login);
                var @event = _unitOfWork.CalendarEventsRepository.All().First(d => d.CalendarEventID == viewModel.ID);

                @event.Title = viewModel.Title;
                @event.Description = viewModel.Description;
                @event.StartAt = viewModel.StartAt;
                @event.EndAt = viewModel.EndAt;
                @event.EventType = _unitOfWork.EventTypeRepository.Find(viewModel.SelectedType);
                @event.Building = _unitOfWork.BuildingRepository.Find(viewModel.SelectedBuilding);
                @event.Room = _unitOfWork.RoomRepository.Find(viewModel.SelectedRoom);
                @event.Owner = user;
                @event.Users.Clear();

                _unitOfWork.SaveChanges();
                return RedirectToAction("OwnerEvent");
            }

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Organizator" })]
        public ActionResult DeleteEvent(int id)
        {
            if (ModelState.IsValid)
            {
                var oldEvent = _unitOfWork.CalendarEventsRepository.Find(id);
                oldEvent.Owner = null;
                oldEvent.EventType = null;
                oldEvent.Building = null;
                oldEvent.Room = null;
                oldEvent.Users = null;
                _unitOfWork.CalendarEventsRepository.Remove(id);

                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("OwnerEvent");
        }

    }


}