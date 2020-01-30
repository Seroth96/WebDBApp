using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDBApp.Models
{
    public class BuildingDetails
    {
        [Required, ForeignKey("Building")]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        [Required]
        public virtual Building Building { get; set; }
    }
}