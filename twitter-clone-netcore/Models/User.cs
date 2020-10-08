using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace twitter_clone_netcore.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<User> Following { get; set; }
            
    }
}
