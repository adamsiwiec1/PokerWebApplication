using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PokerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace PokerWebApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {

            ApplicationDbContext context = new ApplicationDbContext();


            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Player"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Player";
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists("Administrator"))
            {
                //if not then we create it 
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Administrator";
                roleManager.Create(role);

                //we give them username + email
                var user = new ApplicationUser();
                user.Email = "adminuser1@test.com";
                user.UserName = user.Email;

                //then we create the user and add thier password
                var userCreated = UserManager.Create(user, "Test1234!");

                //if that is a success then we utilize the UserManager and at the administrator to a role
                if (userCreated.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Administrator");

                }

            }


            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}