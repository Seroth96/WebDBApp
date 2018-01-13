using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDBApp.Models
{
    public class OrderDetails
    {
        [Required, ForeignKey("Order")]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Amount { get; set; }
        public bool IsCompleted { get; set; } = false;

        [Required]
        public virtual Order Order { get; set; }
    }
}