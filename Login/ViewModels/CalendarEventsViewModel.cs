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
    public class CalendarEventsViewModel 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;


        public IEnumerable<CalendarEvent> CalendarEvents { get; set; }
        

        public CalendarEventsViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CalendarEvents = new List<CalendarEvent>();
        }

        public void SetEvents(User user)
        {
            CalendarEvents = _unitOfWork.CalendarEventsRepository.All().Where(ev => ev.Trainer.Login == user.Login).ToList();
        }

        public void SetEventsForUser(User user)
        {
            CalendarEvents = _unitOfWork.CalendarEventsRepository.All().Where(ev => ev.Users.Any(participant => participant.Login == user.Login)).OrderByDescending(x => x.StartAt).ToList();
        }

    }
}