namespace MVCPresentationLayer.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCPresentationLayer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Claims;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCPresentationLayer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCPresentationLayer.Models.ApplicationDbContext context)
        {

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin@stutor.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@stutor.com",
                    Email = "admin@stutor.com"
                };

                IdentityResult result = userManager.Create(user, "!N3wuser");

                if (result.Succeeded)
                {
                    userManager.AddClaim(user.Id, new Claim(ClaimTypes.GivenName, "Admin"));
                }

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Administrator" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Administrator");
                context.SaveChanges();

            }

            //Add the roles from the existing internal system (database)
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Employee" });
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Student" });
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Tutor" });
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
