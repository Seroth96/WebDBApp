using WebDBApp.Models;
using WebDBApp.Service_References.Annotation;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDBApp.Controllers
{
    [SessionExpireFilter]
    public class CalendarController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {   
            var events = new List<CalendarEvent>();

            events.Add(new CalendarEvent
            {
                Title = "test2",
                Description = "wadwadwd bla bla",
                StartAt = DateTime.Now.AddDays(5).ToString(@"MM\/dd\/yyyy HH:mm:ss"),
                EndAt = DateTime.Now.AddDays(5).AddHours(2).ToString(@"MM\/dd\/yyyy HH:mm:ss"),
                IsFullDay = false
            });
            events.Add(new CalendarEvent
            {
                Title = "test5",
                Description = "opis bla bla",
                StartAt = DateTime.Now.AddDays(10).ToString(@"MM\/dd\/yyyy HH:mm:ss"),
                EndAt = DateTime.Now.AddDays(10).AddHours(7).ToString(@"MM\/dd\/yyyy HH:mm:ss"),
                IsFullDay = false
            });
            events.Add(new CalendarEvent
            {
                Title = "test8",
                Description = "opiskupa dupa",
                StartAt = DateTime.Now.AddDays(3).ToString(@"MM\/dd\/yyyy HH:mm:ss"),
                EndAt = DateTime.Now.AddDays(3).ToString(@"MM\/dd\/yyyy HH:mm:ss"),
                IsFullDay = true
            });
            events.Add(new CalendarEvent
            {
                Title = "test234",
                Description = "opis bwadwad",
                StartAt = DateTime.Now.AddDays(-4).ToString(@"MM\/dd\/yyyy HH:mm:ss"),
                EndAt = DateTime.Now.AddDays(-4).AddHours(2).ToString(@"MM\/dd\/yyyy HH:mm:ss"),
                IsFullDay = false
            });

            var vv = events.OrderBy(a => a.StartAt).ToList();

            return new JsonResult { Data = vv, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
        
       
}