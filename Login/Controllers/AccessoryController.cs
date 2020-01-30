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
    public class AccessoryController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;

        public AccessoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       

        [HttpGet]
        [CheckSession(Role = new string[] { "Administrator"})]
        public ActionResult NewAccessory(int id)
        {
            var viewModel = new NewAccessoryViewModel();
            viewModel.Room = _unitOfWork.RoomRepository.Find(id);
            

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Administrator"})]
        public ActionResult NewAccessory(NewAccessoryViewModel viewModel)
        {
            try
            {
                var accessory = new Accessory
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description
                };

                var room = _unitOfWork.RoomRepository.Find(viewModel.Room.ID);
                room.Accessories.Add(accessory);

                _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("~/Views/PartialViews/Error.cshtml", ex.Message);
            }
            return RedirectToAction("Index","Room");
        }

        [HttpGet]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult EditAccessory(int id)
        {
            var viewModel = new EditAccessoriesViewModel();
            viewModel.ID = id;
            viewModel.Accessories = _unitOfWork.RoomRepository.Find(id).Accessories.ToList();
            var x = viewModel.Accessories.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.ID.ToString()
            });
            viewModel.choices.AddRange(x);
            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult EditAccessory(EditAccessoriesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {             
                var oldAccessory = _unitOfWork.AccessoryRepository.Find(viewModel.SelectedAccesory);
                oldAccessory.Name = viewModel.NewName;
                oldAccessory.Description = viewModel.Description;

                _unitOfWork.SaveChanges();
                return RedirectToAction("Index", "Room");
            }

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Administrator" })]
        public ActionResult DeleteAccessory(int selectedAccesory)
        {
            if (ModelState.IsValid)
            {
                var oldAccessory = _unitOfWork.AccessoryRepository.Find(selectedAccesory);
                
                _unitOfWork.AccessoryRepository.Remove(selectedAccesory);


                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index", "Room");
        }

        
    }
}