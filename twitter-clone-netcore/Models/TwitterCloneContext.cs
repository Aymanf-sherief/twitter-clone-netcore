using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

    public class UserDBContext : IdentityDbContext
    {

        public DbSet<User> users { get; set; }
      
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options) { }

          }
}
