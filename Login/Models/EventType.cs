using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDBApp.Models
{
    public class EventType
    {
        [Required, Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}