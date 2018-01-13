using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebDBApp.Models;

namespace WebDBApp.Models
{
    public class Gym
    {
        [Required, Key]
        public int ID { get; set; }        

        public virtual GymDetails GymDetails { get; set; }

        public virtual ICollection<Hall> Halls { get; set; }
    }
}