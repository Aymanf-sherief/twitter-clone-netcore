using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace twitter_clone_netcore.Models
{
    public class Tweet
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public User User { get; set; }


    }
}
