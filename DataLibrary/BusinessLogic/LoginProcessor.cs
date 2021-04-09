using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogics
{
    public static class LoginProcessor
    {
        public static string DecryptString(string encryptstr)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encryptstr);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException)
            {

                decrypted = "";
            }
            return decrypted;
        }
        public static string EncryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        public static int IsClientExists(string username, string password)
        {
             LoginModel data = new LoginModel
             {
                Username = username,
                Password = password
            };
            data.Password = EncryptString(data.Password);
            string sql = @"SELECT Id FROM dbo.UserCredentials WHERE Username = @Username
                AND  Password = @Password;";
            return sqlDataAccess.IsExist(sql, data);
        }
 
        

    }
}
