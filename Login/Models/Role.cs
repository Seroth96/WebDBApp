using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDBApp.Models
{
    public class Role
    {

        [Required, Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }
    }
}