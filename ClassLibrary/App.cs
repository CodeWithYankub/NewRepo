using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class App
    {
        public static string Error { get; set; }
        public static User Logged { get; set; }
        public static string ConnectionString {
            get
            {
                return @"Data Source=DESKTOP-BSJERV7\YAKUBMUCK;Initial Catalog=slmb_app_db;Integrated Security=True";
            }
        }

        public enum Gender
        {
            Female,
            Male
        }

        public enum UserType
        {
            Admin,
            Bursar,
            ExamOfficer
        }

        public enum Color
        {
            Blue,
            Green,
            Red,
            Yellow
        }

        public enum Action
        {
            Create,
            Disable,
            Edit,
            Enable
        }

        public static string PasswordHash(string password)
        {
            using(SHA256Managed sha = new SHA256Managed())
            {
                var byts = Encoding.UTF8.GetBytes(password);
                var hashed = sha.ComputeHash(byts);

                return Convert.ToBase64String(hashed);
            }
        }

        public static bool PasswordVerify(string password, string hashed)
        {
            var hash = PasswordHash(password);

            return hashed.Equals(hash);
        }
    }
}
