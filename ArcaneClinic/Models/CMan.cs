using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ArcaneClinic.Models
{
    public class CMan
    {
        [Required(ErrorMessage = "Please Enter Pic Name")]
        [Display(Name = "Enter Pic Name")]
        public string PicName { get; set; }


        [Required(ErrorMessage = "Please choose file")]
        [Display(Name = "Choose your file")]
        [DataType(DataType.ImageUrl)]
        public HttpPostedFileBase ChairmanPic { get; set; }
        public string FileName { get; set; }
    }
}