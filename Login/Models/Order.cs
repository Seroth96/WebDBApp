using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDBApp.Models
{
    public class Order
    {
        [Required, Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Building Building { get; set; }
        [Required]
        public Room Room { get; set; }

        public virtual User User { get; set; }

        public virtual OrderDetails OrderDetails { get; set; }


    }
}