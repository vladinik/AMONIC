using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AMONIC
{
    class Helper
    {
        public static UserOficeEntities userOficeEntities;
        public static Users currentUser;
        public static UserActivity currentUserActivity;
        public static UserOficeEntities GetEntities()
        {
            if (userOficeEntities == null)
            {
                userOficeEntities = new UserOficeEntities();
            }
            return userOficeEntities;
        }
        public static string MD5Hash(string password)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "").ToLower();
        }
    }
}
