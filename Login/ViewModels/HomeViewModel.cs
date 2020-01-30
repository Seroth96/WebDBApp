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
    public class HomeViewModel 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;


        public IEnumerable<Building> Buildings { get; set; }
        

        public HomeViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            SetBuildings();
        }

        private void SetBuildings()
        {
            Buildings = _unitOfWork.BuildingRepository.All().ToList();
        }
        
    }
}