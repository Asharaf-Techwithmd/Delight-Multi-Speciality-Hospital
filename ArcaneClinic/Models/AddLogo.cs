using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ArcaneClinic.Models
{
    public class AddLogo
    {
        [Required(ErrorMessage = "Please Enter Pic Name")]
        [Display(Name = "Enter Logo Name")]
        public string LogoName { get; set; }


        [Required(ErrorMessage = "Please choose file")]
        [Display(Name = "Choose your file")]
        [DataType(DataType.ImageUrl)]
        public HttpPostedFileBase LogoPic { get; set; }
        public string FileName { get; set; }
    }
}