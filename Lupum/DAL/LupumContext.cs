using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Lupum.Models;

namespace Lupum.DAL
{
    public class LupumContext:DbContext
    {
        public LupumContext() : base("LupumContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Action> Actions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}