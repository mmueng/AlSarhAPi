
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
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
      //  protected override void OnModelCreating(ModelBuilder modelBuilder)
       // {
        //    modelBuilder.ApplyConfiguration(new MainDBDepartmentConfiguration());
           // modelBuilder.ApplyConfiguration(new StudentSubjectConfiguration());
       // }
        //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //  {
        //      if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=WebAPIContext-e4ab80a7-7639-40bc-bd05-3e2322a6e1c6;Trusted_Connection=True;MultipleActiveResultSets=true");
        //          
        //     }
        //  }
     //   protected override void OnModelCreating(ModelBuilder modelBuilder)
       // {

      
        //     base.OnModelCreating(modelBuilder);

        //   modelBuilder.Entity<Department>()
        //    .HasOne<MainDep>(s => s.CurrMainDep)
        //    .WithMany(g => g.DepartmentList)
        //    .HasForeignKey(s => s.CurrMainDepID);

        //modelBuilder.Entity<IdentityUserLogin>().HasNoKey();
        // modelBuilder.Entity<MainDep>()
        //   .HasMany<Department>(g => g.DepartmentList)
        //   .WithOne(s => s.CurrMainDep)
        //   .HasForeignKey(s => s.CurrMainDepID);
    }

       // protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            // configures one-to-many relationship
         //   modelBuilder.Entity<Department>()
           //     .HasRequired<MainDep>(s => s.CurrMainDep)
          //      .WithMany(g => g.DepartmentList)
         //       .HasForeignKey<int>(s => s.CurrMainDepID);
      // }
  //  }
}
    

