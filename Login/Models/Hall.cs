using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDBApp.Models
{
    public class Hall
    {
        [Required, Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public double SurfaceArea { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }
        public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }

    }
}