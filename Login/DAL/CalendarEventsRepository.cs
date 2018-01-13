using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDBApp.DAL;
using WebDBApp.Database;
using WebDBApp.Models;

namespace WebDBApp.DAL
{
    public class CalendarEventsRepository : Repository<CalendarEvent, int>
    {

        public CalendarEventsRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}