
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebDBApp.Models
{
    public class User
    {
        [Required, Key]
        [XmlIgnore]
        public string Login { get; set; }
        [Required]
        [XmlIgnore]
        public DateTime? Created { get; set; }
        [Required]
        [XmlIgnore]
        public string Password { get; set; }
        [Required]
        [XmlIgnore]
        public DateTime? PasswordCreated { get; set; }        
        [Required]
        [XmlIgnore]
        public string Salt { get; set; }
        [Required]
        [XmlIgnore]
        public string FirstName { get; set; }
        [Required]
        [XmlIgnore]
        public string LastName { get; set; }
        [XmlIgnore]
        [Required]
        public string Email { get; set; }
        [XmlIgnore]
        [Required]
        public bool Sex { get; set; } // true == man and false == women
        [XmlIgnore]
        [Required]
        public bool IsFrozen { get; set; } = false;

        [Required]
        virtual public Role Role { get; set; }

        virtual public ICollection<Test> Tests { get; set; }

        public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }

        [NotMapped]
        [XmlElement("Name")]
        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
            set
            {
            }
        }

        public User()
        {
            this.CalendarEvents = new List<CalendarEvent>();
            this.Tests = new List<Test>();
        }
    }
}