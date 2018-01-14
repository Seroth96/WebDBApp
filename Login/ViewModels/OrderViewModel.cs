using WebDBApp.Service_References.Annotation;
using WebDBApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDBApp.Database;
using WebDBApp.Interfaces;
using NLog;

namespace WebDBApp.ViewModels
{
    public class OrderViewModel 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;


        public IEnumerable<Order> Orders { get; set; }
        

        public OrderViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Orders = new List<Order>();
        }

        public void SetOrders(bool isCompleted)
        {
            Orders = _unitOfWork.OrderRepository.All().Where(order => order.OrderDetails.IsCompleted == isCompleted).ToList();
        }

        public void SetOrdersforUser(User user)
        {
            Orders = _unitOfWork.OrderRepository.All().Where(order => order.User.Login == user.Login).OrderBy(g => g.Date).ToList();
        }

    }
}