using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogics
{
    public class ClientProfileProcessor
    {
        public static int InsertClientInformation(string fullname, string add1, string add2,
            string city, string state, string zipcode, int usercredentialsId)
        {
            ClientProfileModel data = new ClientProfileModel
            {
                FullName = fullname,
                Address1 = add1,
                Address2 = add2,
                City = city,
                State = state,
                Zipcode = zipcode,
                UserCredentialsID = usercredentialsId
            };
            string sql = @"insert into ClientInformation (FullName, Address1, Address2,
                City,State,Zipcode,UserCredentialsID)
            values(@Fullname, @Address1, @Address2,@City, @State, @Zipcode,@UserCredentialsID);";
            return sqlDataAccess.SaveData(sql, data);
        }
        public static string GetClientName(int UserCredentialsID)
        {
            ClientProfileModel data = new ClientProfileModel
            {
                UserCredentialsID = UserCredentialsID
            };
            string sql = @"SELECT FullName FROM dbo.ClientInformation WHERE UserCredentialsId = @UserCredentialsID;";

            return sqlDataAccess.GetInfo(sql, data);
        }
        public static string GetClientAddress(int UserCredentialsID)
        {
            ClientProfileModel data = new ClientProfileModel
            {
                UserCredentialsID = UserCredentialsID
            };
            string sql = @"SELECT Address1 FROM dbo.ClientInformation WHERE UserCredentialsId = @UserCredentialsID;";

            return sqlDataAccess.GetInfo(sql, data);
        }
        public static string GetClientState(int UserCredentialsID)
        {
            ClientProfileModel data = new ClientProfileModel
            {
                UserCredentialsID = UserCredentialsID
            };
            string sql = @"SELECT State FROM dbo.ClientInformation WHERE UserCredentialsId = @UserCredentialsID;";

            return sqlDataAccess.GetInfo(sql, data);
        }

        public static List<ClientProfileModel> LoadClients()
        {
            string sql = @"select FullName, Address1, Address2, City, State, Zipcode
                           From ClientInformation;";
            return sqlDataAccess.LoadData<ClientProfileModel>(sql);
        }
    }
}
