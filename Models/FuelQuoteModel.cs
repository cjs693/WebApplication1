using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace FinalProject.Models
{
    public class FuelQuoteModel
    {
        
        [Display(Name ="Gallons Requested")]
        [Required(ErrorMessage = "Gallons of Request is required")]

        public double Gallons { get; set; }

        [Display(Name ="Delivery Address")]
        [Editable(allowEdit: false)]
        public string DeliveryAddress { get; set; }
        [Display(Name = "Delivery Date")]
        public DateTime DeliveryDate { get; set; }
        [Display(Name = "Suggested Price")]
       
        public double SuggestedPrice { get; set; }

        [Display(Name = "Total Amount Due")]
        public double TotalAmountDue { get; set; }
        public int UserCredentialsID { get; set; }
        
    }
}