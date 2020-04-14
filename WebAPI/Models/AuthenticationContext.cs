using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{

        public class AuthenticationContext : IdentityDbContext
        {
            public AuthenticationContext(DbContextOptions options) : base(options)
            {

            }

            public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<MainDep> MainDeps { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
    }

