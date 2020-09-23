using CarRental.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Roles for project using Code First aaproach
        public ActionResult RoleList()
        {
            var roleList = _db.Roles.ToList();
            return View(roleList);
        }

        public ActionResult CreateRole()
        {
            var role = new IdentityRole();
            return View(role);
        }
        [HttpPost]
        public ActionResult CreateRole(IdentityRole identity)
        {
            _db.Roles.Add(identity);
            _db.SaveChanges();
            return RedirectToAction("RoleList");
        }
    }
}