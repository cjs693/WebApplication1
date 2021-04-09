using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class ClientProfileModel
    {
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Delivery Address 1")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zipcode is required")]
        [Range(10000,9999999,ErrorMessage ="Zipcode is minimum 5 digits and maximum 7 digits")]
        public string Zipcode { get; set; }
    }
}