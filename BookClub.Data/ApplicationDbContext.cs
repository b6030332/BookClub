using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using BookClub.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookClub.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int Rating { get; set; }
        public string ProfileImage { get; set; }
        public DateTime? MemberSince { get; set; }
        public bool IsActive { get; set; }

        
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
            : base("name = ApplicationDbContext")
        {
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Discussion> Discussion { get; set; }
        public DbSet<PostReply> Replies { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       
    }
}