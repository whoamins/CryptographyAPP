using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public int id { get; set; } // IDK Why, but we should use id instead ID for sqlite
        
        public User() { }

        public User(string login, string email, string password)
        {
            Login = login;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"ID: {id} | Login: {Login} | Email: {Email}";
        }
    }
}
