using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ArcaneClinic.Models;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
namespace ArcaneClinic.Models
{
    public class AddSlider
    {
        [Required(ErrorMessage = "Please Enter Id")]
        [Display(Name = "Enter Pic Id")]
        public string Pid { get; set; }


        [Required(ErrorMessage = "Please Enter Pic Name")]
        [Display(Name = "Enter Pic Name")]
        public string Pname { get; set; }


        [Required(ErrorMessage = "Please choose file")]
        [Display(Name = "Choose your file")]
        [DataType(DataType.ImageUrl)]
        public HttpPostedFileBase Pic { get; set; }
        public string FileName { get; set; }


        [Required(ErrorMessage = "Please Enter Description")]
        [Display(Name = "Enter Description")]
        public string Description { get; set; }



       
    }


}