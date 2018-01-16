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
    public class OrderController : Controller
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new OrderViewModel(_unitOfWork);

            viewModel.SetOrders(false);//All awaiting orders

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult OrdersForUser()
        {
            var viewModel = new OrderViewModel(_unitOfWork);
            var login = SessionHelper.GetElement<string>(SessionElement.Login);
            var user = _unitOfWork.UserRepository.Find(login);

            viewModel.SetOrdersforUser(user);//All orders for current user

            return View("~/Views/Order/Index.cshtml",viewModel);
        }

        [HttpGet]
        [CheckSession(Role = new string[] { "Trener" })]
        public ActionResult NewOrder()
        {
            var viewModel = new NewOrderViewModel();
            return View(viewModel);
        }
        
        [CheckSession(Role = new string[] { "Pracownik" })]
        public ActionResult AcceptOrder(int id)
        {
            var order = _unitOfWork.OrderRepository.Find(id);
            order.OrderDetails.IsCompleted = true;

            _unitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        [CheckSession(Role = new string[] { "Pracownik" })]
        public ActionResult RejectOrder(int id)
        {
            var order = _unitOfWork.OrderRepository.Find(id);
            
            order.OrderDetails.IsRejected = true;

            _unitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult NewOrder(NewOrderViewModel viewModel)
        {
            try
            {

                var login = SessionHelper.GetElement<string>(SessionElement.Login);
                _unitOfWork.OrderRepository.Add(new WebDBApp.Models.Order
                {
                    User = _unitOfWork.UserRepository.Find(login),
                    Date = DateTime.Now,
                    Title = viewModel.Title,
                    OrderDetails = new WebDBApp.Models.OrderDetails
                    {
                        Amount = viewModel.Amount,
                        Description = viewModel.Description,
                        
                    }
                });

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
        [CheckSession(Role = new string[] { "Trener" })]
        public ActionResult EditOrder(int id)
        {
            var viewModel = new NewOrderViewModel();
            var order = _unitOfWork.OrderRepository.Find(id);
            viewModel.ID = order.ID;
            viewModel.Title = order.Title;
            viewModel.Description = order.OrderDetails.Description;
            viewModel.Amount = order.OrderDetails.Amount;

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Trener" })]
        public ActionResult EditOrder(NewOrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var order = _unitOfWork.OrderRepository.Find(viewModel.ID);

                order.Title = viewModel.Title;
                order.Date = DateTime.Now;
                order.OrderDetails.Amount = viewModel.Amount;
                order.OrderDetails.Description = viewModel.Description;
                order.OrderDetails.IsCompleted = false;
                order.OrderDetails.IsRejected = false;


                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpPost]
        [CheckSession(Role = new string[] { "Trener" })]
        public ActionResult DeleteOrder(int id)
        {
            if (ModelState.IsValid)
            {
                var oldOrder = _unitOfWork.OrderRepository.Find(id);
                oldOrder.OrderDetails = null;
                _unitOfWork.OrderRepository.Remove(id);


                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}