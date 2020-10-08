using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace twitter_clone_netcore.Models
{
    public class TwitterCloneContext: DbContext
    {
        public TwitterCloneContext(DbContextOptions<TwitterCloneContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
    }
}
