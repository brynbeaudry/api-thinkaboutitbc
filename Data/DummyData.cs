using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_thinkaboutitbc.Models;
using api_thinkaboutitbc.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace api_thinkaboutitbc.Data
{
    public class DummyData
    {
        public static void Initialize(ApplicationDbContext db, IServiceProvider services)
        {
            IServiceScopeFactory scopeFactory = services.GetRequiredService<IServiceScopeFactory>();

            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                RoleManager<Microsoft.AspNetCore.Identity.IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                UserSeedAsync(db, roleManager, userManager);
            }
            /*
            if (!db.Activities.Any())
            {
                db.Activities.AddRange(GetActivities().ToArray());
                db.SaveChanges();
            }
            if (!db.Events.Any())
            {
                db.Events.AddRange(GetEvents(db).ToArray());
                db.SaveChanges();
            }
            */
        }

        public static async void UserSeedAsync(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            var isAdminRoleExist = await roleManager.RoleExistsAsync("Admin");
            var isMemberRoleExist = await roleManager.RoleExistsAsync("Member");
            if (!isAdminRoleExist)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!isMemberRoleExist)
            {
                await roleManager.CreateAsync(new IdentityRole("Member"));
            }
            if (await userManager.FindByNameAsync("a") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "richardbeaudry@shaw.ca",
                    UserName = "The_Editor",
                    FirstName = "Richard",
                    LastName = "Beaudry",
                    ProviderName = "EMAIL"
                };
                var result = await userManager.CreateAsync(user, "mysonbrynisagenius");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
            if (await userManager.FindByNameAsync("a") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "a@a.a",
                    UserName = "a"
                };
                var result = await userManager.CreateAsync(user, "");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Member");
                }
            }
        }

        //Make Posts first

        public static List<Post> GetPosts(ApplicationDbContext context)
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {

                },
            };
            //context.SaveChanges();
            return posts;
        }

        public static List<Comment> GetComments(ApplicationDbContext context)
        {
            List<Comment> comments = new List<Comment>()
            {
                new Comment()
                {

                },
            };
            //context.SaveChanges();
            return comments;
        }




        /*
        public static List<Event> GetEvents(ApplicationDbContext context)
        {
            List<Event> events = new List<Event>()
            {
                new Event()
                {
                    Activity = new Activity()
                    {
                        ActivityDescription = "Senior’s Golf Tournament"
                    },
                    StartDate = new DateTime(2017, 12, 22, 12, 00, 0),
                    EndDate = new DateTime(2017, 12, 22, 13, 30, 0),
                    IsActive = true,
                    EnteredByUsername = "a",
                },
            //context.SaveChanges();
            return events;
        }
        */
    }
}


