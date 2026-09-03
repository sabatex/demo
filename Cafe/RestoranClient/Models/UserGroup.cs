using System;
using System.Collections.Generic;
using System.Text;

namespace RestoranClient.Models
{
    public class UserGroup
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }

}
