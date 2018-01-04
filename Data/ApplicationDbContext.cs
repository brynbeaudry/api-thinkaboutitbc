using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using api_thinkaboutitbc.Models;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace api_thinkaboutitbc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public DBSet<OpenIdDictApplications> OpenIdDictApplications { get;set;}
        //public DbSet<Event> Events { get; set; }
        //public DbSet<EventGuest> EventGuests { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        //public DbSet<Game> Games { get; set; }
        //  public DbSet<GameRank> GameRanks { get; set; }
        //public DbSet<Leaderboard> Leaderboards { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //Relations

            builder.Entity<ApplicationUser>()
                .HasIndex("ProviderId")
                .IsUnique()
                .HasName("ProviderIdIndex");
            
            builder.Entity<ApplicationUser>()
                .HasIndex("UserName")
                .HasName("NonNormalizedUserNameIndex");

            builder.Entity<ApplicationUser>()
                .HasIndex("ProviderName")
                .HasName("ProviderNameIndex");
            //can make forieg key later


        }

    }
}
