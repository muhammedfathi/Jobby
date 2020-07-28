using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Jobby.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string gender { get; set; }
        public string Country { get; set; }

        public string maritialStatus { get; set; }
        public string usertype { get; set; }
        public string  photo { get; set; }
       

        public string militaryStatus { get; set; }
        [Display (Name ="Date Of Birth")]
        public DateTime? StartDate { get; set; }

        public string University { get; set; }
        public string Faculty { get; set; }
        public DateTime? GraduationYear { get; set; }
        
        public string Workfield { get; set; }


        public virtual ICollection <job> jobs { get; set; }


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

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //for cascading on delete Prim key then delete all foriegn key
            modelBuilder.Entity<SaveJobs>()
                 .HasOptional<ApplicationUser>(b=>b.user)
                 .WithMany()
                 .WillCascadeOnDelete(true);
           

            modelBuilder.Entity<SaveJobs>()
                 .HasRequired<job>(j => j.job)
                 .WithMany()
                 .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);




        }

        public System.Data.Entity.DbSet<Jobby.Models.jobcategory> jobcategories { get; set; }

        public System.Data.Entity.DbSet<Jobby.Models.job> jobs { get; set; }
        public IEnumerable<object> AspNetUsers { get; internal set; }

        public System.Data.Entity.DbSet<Jobby.Models.AppliedUser> AppliedUsers { get; set; }

        public System.Data.Entity.DbSet<Jobby.Models.SaveJobs> SaveJobs { get; set; }

        //public System.Data.Entity.DbSet<Jobby.Models.ApplicationUser> ApplicationUsers { get; set; }



    }
}