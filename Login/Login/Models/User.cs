
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Login.Models
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
        
        [NotMapped]
        [XmlElement("Name")]
        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
            set
            {
            }
        }

        /// <summary>
        /// Może by wymagać reset hasła co 30 dni albo coś takiego?
        /// </summary>
        /// <returns></returns>
        public bool IsPasswordExpired()
        {
            return (DateTime.Now - PasswordCreated.Value).TotalDays >= 30d;
        } 

        public User()
        {
        }
    }
}