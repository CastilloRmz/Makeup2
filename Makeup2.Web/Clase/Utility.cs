using Makeup2.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Makeup2.Web.Clase
{
    public class Utility
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();
        public static void CheckRoles(string rol)
        {
            var role = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if (!role.RoleExists(rol))
            {
                role.Create(new IdentityRole(rol)); 
            }
        }

        internal static void CheckSuperUser()
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var User=UserManager.FindByName("superuser@mail.com");
            if (User==null)
            {
                CreateSuperUser("superuser@mail.com", "Admin_123",null, "Administrator");
            }
        }

        private static void CreateSuperUser(string email, string password, string phone, string rol)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser()
            {
                UserName=email,
                Email=email,
                PhoneNumber=phone
            };
            UserManager.Create(user, password);
            UserManager.AddToRole(user.Id,rol);
        }
        public void Dispose()
        {
            db.Dispose();

        }
    }
}