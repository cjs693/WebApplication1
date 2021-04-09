using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public  class FuelQuoteModel
    {
        public double Gallons { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double SuggestedPrice { get; set; }
        public double TotalAmountDue { get; set; }
        public int UserCredentialsID { get; set; }
    }
}
