using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDBApp.Models
{
    public class Test
    {
        [Required, Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Result { get; set; }
        [Required]
        public double Value { get; set; }

        [Required]
        public User User { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfTest { get; set; }


        [NotMapped]
        public string Wynik {
            get
            {
                return "Dnia " + DateOfTest.ToString("d/MM/yyyy") + " osiągnięty przez Ciebie wynik to: " + Value + ". Oznacza to, że prezentujesz: " + Result + " poziom.";
            }
        }
    }
}