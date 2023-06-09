﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Användare

        public string Name { get; set; }
        public bool PrivateProfile { get; set; }
        public string Address { get; set; }
        public virtual Cv Cv { get; set; }
        public virtual ICollection<Project> Projects {get; set;}

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Cv> Cvs { get; set; }
        public DbSet<ApplicationUserProject> ApplicationUserProjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Write Fluent API configurations here
            modelBuilder.Entity<ApplicationUser>()
             .HasMany(t => t.Projects)
             .WithMany(t => t.Users);

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


    }
        
}