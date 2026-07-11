using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ArcaneClinic.Models
{
    public class JoinUs
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
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Enter Password:")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm_Password")]
        [Display(Name = "Confirm_Password:")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string Confirm_Password { get; set; }

        [Required(ErrorMessage = "Please Enter DOB")]
        [Display(Name = "Enter DOB:")]
        [DataType(DataType.Date)]
        public string DOB { get; set; }


        [Required(ErrorMessage = "Please Select Gender")]
        [Display(Name = "Gender :")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "File not choosen")]
        [Display(Name = "Picture:")]
        [DataType(DataType.ImageUrl)]
        [FileExtensions(Extensions = "pdf", ErrorMessage = "Only Upload Pdf file")]

        public HttpPostedFileBase Picture { get; set; }

    }
}