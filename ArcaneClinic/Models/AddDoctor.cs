using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ArcaneClinic.Models
{
    public class AddDoctor
    {
        [Required]
        [Display(Name = "Enter Name :")]
        public string Name { get; set; }

        [Required]
    public string SelectedQualification { get; set; }
    public IEnumerable<SelectListItem> QualificationList { get; set; }

    [Required]
    public string SelectedSpecialist { get; set; }
    public IEnumerable<SelectListItem> SpecialistList { get; set; }

        [Required]
        [Display(Name = "Room No :")]
        public string Room_No { get; set; }

        [Required]
        [Display(Name = "Experience(in years) :")]
        public string Experience { get; set; }

        [Required]
        [Display(Name = "Fee :")]
        public string Fee { get; set; }

        [Required]
        [Display(Name="Picture :")]
        [DataType(DataType.ImageUrl)]
        public HttpPostedFileBase Image {get; set;}


    }
}