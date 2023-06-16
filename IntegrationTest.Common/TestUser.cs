using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Common
{
    public class TestUser
    {
        public TestUser(string username="standard_user", string password= "secret_sauce", string firstName="", string lastName="", string email="")
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string Username { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Name => FirstName + " " + LastName;

        public string EncodedPassword()
        {
            return WebUtility.UrlEncode(Password);
        }
    }
}
