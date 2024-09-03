using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCWebapp.Models;

namespace MVCWebapp.Data
{
    public class MVCWebappContext : DbContext
    {
        public MVCWebappContext (DbContextOptions<MVCWebappContext> options)
            : base(options)
        {
        }

        public DbSet<MVCWebapp.Models.User> User { get; set; } = default!;
        public DbSet<MVCWebapp.Models.Skill> Skill { get; set; } = default!;
    }
}
