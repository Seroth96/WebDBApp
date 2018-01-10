using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class CalendarEvent
    {
        
            public string Title { get; set; }
            public string Description { get; set; }
            public string StartAt { get; set; }
            public string EndAt { get; set; }
            public bool IsFullDay { get; set; }
        
    }
}