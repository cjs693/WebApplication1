using DataLibrary.DataAccess;
using DataLibrary.Models;
using DataLibrary.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogics
{
    public static class FuelQuoteFormProcessor
    {
        public static int InsertFuelQuoteInformation(double gallons, string deliveryAddress, DateTime deliveryDate,
            double suggestedPrice, double amountDue, int usercredentialsId)
        {
            FuelQuoteModel data = new FuelQuoteModel
            {
                Gallons = gallons,
                DeliveryAddress = deliveryAddress,
                DeliveryDate = deliveryDate,
                SuggestedPrice = suggestedPrice,
                TotalAmountDue = amountDue,
                UserCredentialsID =usercredentialsId
                
            };
            
            string sql = @"insert into FuelQuote (Gallons, DeliveryDate, UserCredentialsId, DeliveryAddress, TotalAmountDue, SuggestedPrice)
            values(@Gallons, @DeliveryDate, @UserCredentialsId, @DeliveryAddress, @TotalAmountDue, @SuggestedPrice);";
            return sqlDataAccess.SaveData(sql, data);
        }
        public static int IsQuoteExisted(int usercredentialsId)
        {
            FuelQuoteModel data = new FuelQuoteModel
            {
                UserCredentialsID = usercredentialsId
            };
            
            string sql = @"SELECT Id FROM dbo.FuelQuote WHERE UserCredentialsID = @UserCredentialsID;";
            return sqlDataAccess.IsExist(sql, data);
        }
        public static List<FuelQuoteModel> LoadFuelQuotes()
        {
            string sql = @"select Gallons,
                           DeliveryAddress, 
                           DeliveryDate, 
                           SuggestedPrice,
                           TotalAmountDue
                           From dbo.FuelQuote;";
            return sqlDataAccess.LoadData<FuelQuoteModel>(sql);
        }
    }
}
