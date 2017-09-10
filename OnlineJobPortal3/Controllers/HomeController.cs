using OnlineJobPortal3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJobPortal3.Controllers
{
    public class HomeController : Controller
    {

      // private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            //db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = "Company" });
            //db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = "JobSeeker" });
            //db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = "Admin" });
            //db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}