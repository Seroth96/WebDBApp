using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebDBApp.Models;

namespace WebDBApp.Models
{
    public class Building
    {
        [Required, Key]
        public int ID { get; set; }        

        public virtual BuildingDetails BuildingDetails { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public Building()
        {
            Rooms = new List<Room>();
        }
    }
}