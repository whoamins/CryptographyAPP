using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utils
{
    class CredentialsRequirements
    {
        public static bool LoginLength(string login)
        {
            return login.Length > 2;
        }

        public static bool PasswordLength(string password)
        {
            return password.Length > 8;
        }

        public static bool EmailFormat(string email)
        {
            return email.Length > 5 || email.Contains("@") || email.Contains(".");
        }

        public static bool IsAdmin(User user)
        {
            return user.id == 1 && user.Email == "admin@wpfapp.com" && user.Login == "admin";
        }

    }
}
