using System;
using System.Collections.Generic;
using System.Text;

namespace RestoranClient.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public static User defaultAdmin = new User
        {
            Id = 1,
            Name = "Admin",
            Password = "12345"
        }; 

    }
}
