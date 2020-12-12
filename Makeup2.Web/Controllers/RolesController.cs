using Makeup2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Makeup2.Web.Controllers
{

    public class RolesController : Controller
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }
        public ActionResult AddRoles(string id)
        {
            var user = db.Users.Find(id);
            return View();
        }
    }
}