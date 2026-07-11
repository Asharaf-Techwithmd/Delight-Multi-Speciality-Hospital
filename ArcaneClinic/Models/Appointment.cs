using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ArcaneClinic.Models
{
    public class Appointment
    {

        [Required]
        public string SelectedDoctor { get; set; }
        public IEnumerable<SelectListItem> DoctorList { get; set; }


        [Required]
        [Display(Name = "Enter Age :")]
        public string Age { get; set; }


        [Required]
        [Display(Name = "Select Appointment Date :")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required]
        [Display(Name = "Select Suitable Time :")]
        [DataType(DataType.Time)]
        public string Time { get; set; }

    }
}