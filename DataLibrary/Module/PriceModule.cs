using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Module
{
    public  static class PriceModule
    {
        public  static double PriceCalculation(double currentPrice, string location, int rateHistory, double gallons)
        {
            double CompanyProfit = 0.1; //constant
            double LocationRate = 0.04;//assume it is not texas
            double GallonFactor = 0.03;//assume it is less than 1000
            double RateHistoryFactor = 0; //they have not requested before
            if(location.Equals("Tx") || location.Equals("TX")||location.Equals("tx") ||location.Equals("tX") )
            {
                LocationRate = 0.02;
            }
            if(rateHistory != 0)
            {
                RateHistoryFactor = 0.01;
            }
            if(gallons > 1000)
            {
                GallonFactor = 0.02;
            }
            return(currentPrice + (currentPrice * (LocationRate - RateHistoryFactor + GallonFactor + CompanyProfit)));

        }
    }
}
