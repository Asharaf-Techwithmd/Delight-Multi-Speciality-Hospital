using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ArcaneClinic.Models
{
    public class Contact
    {

        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Enter Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [Display(Name = "Enter Email:")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [Display(Name = "Enter Number:")]
        [DataType(DataType.PhoneNumber)]
        public long Mobile { get; set; }

        [Required]
        public string SelectedType { get; set; }
        public IEnumerable<SelectListItem> TypeList { get; set; }

        [Required(ErrorMessage = "Please Enter Message")]
        [Display(Name = "Enter Message:")]
        [DataType(DataType.Text)]
        public string Message { get; set; }
    }
}