using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class CalendarController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            //Here MyDatabaseEntities is our entity datacontext (see Step 4)
            //using (MyDatabaseEntities dc = new MyDatabaseEntities())
            //{
            //    var v = dc.Events.OrderBy(a => a.StartAt).ToList();
            //    
            //}

            
            var events = new List<CalendarEvent>();

            events.Add(new CalendarEvent
            {
                Title = "test2",
                Description = "wadwadwd bla bla",
                StartAt = DateTime.Now.AddDays(5).ToString(@"dd\/MM\/yyyy HH:mm:ss"),
                EndAt = DateTime.Now.AddDays(5).AddHours(2).ToString(@"dd\/MM\/yyyy HH:mm:ss"),
                IsFullDay = false
            });
            events.Add(new CalendarEvent
            {
                Title = "test5",
                Description = "opis bla bla",
                StartAt = DateTime.Now.AddDays(10).ToString(@"dd\/MM\/yyyy HH:mm:ss"),
                EndAt = DateTime.Now.AddDays(10).AddHours(7).ToString(@"dd\/MM\/yyyy HH:mm:ss"),
                IsFullDay = false
            });
            events.Add(new CalendarEvent
            {
                Title = "test8",
                Description = "opiskupa dupa",
                StartAt = DateTime.Now.AddDays(3).ToString(@"dd\/MM\/yyyy HH:mm:ss"),
                EndAt = DateTime.Now.AddDays(3).AddHours(2).ToString(@"dd\/MM\/yyyy HH:mm:ss"),
                IsFullDay = true
            });
            events.Add(new CalendarEvent
            {
                Title = "test234",
                Description = "opis bwadwad",
                StartAt = DateTime.Now.AddDays(-4).ToString(@"dd\/MM\/yyyy HH:mm:ss"),
                EndAt = DateTime.Now.AddDays(-4).AddHours(2).ToString(@"dd\/MM\/yyyy HH:mm:ss"),
                IsFullDay = false
            });

            var vv = events.OrderBy(a => a.StartAt).ToList();

            return new JsonResult { Data = vv, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
        
       
}