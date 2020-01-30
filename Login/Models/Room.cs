using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDBApp.Models
{
    public class Room
    {
        [Required, Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public double SurfaceArea { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }

        public virtual Building Building { get; set; }

        public Room()
        {
            this.Accessories = new List<Accessory>();
        }

    }
}