using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDBApp.Models
{
    public class CalendarEvent
    {
        [Required, Key]
        public int CalendarEventID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartAt { get; set; }
        [Required]
        public DateTime EndAt { get; set; }
        [Required]
        public bool IsFullDay { get; set; } = false;
        [Required]
        public User Owner { get; set; }
        [Required]
        public Building Building { get; set; }
        [Required]
        public Room Room { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual EventType EventType {get; set;}


        public CalendarEvent()
        {
            this.Users = new List<User>();
        }

    }
}