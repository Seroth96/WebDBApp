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
    public class ProfileViewModel 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;


        public IEnumerable<Test> Tests { get; set; }
        

        public ProfileViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Tests = new List<Test>();
        }      

        public void SetTestsforUser(User user)
        {
            Tests = _unitOfWork.TestRepository.All().Where(test => test.User.Login == user.Login).ToList();
        }

    }
}