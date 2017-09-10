using OnlineJobPortal3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJobPortal3.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PostNewsUpdate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostNewsUpdate(NewsFeed feed)
        {
            if (ModelState.IsValid)
            {
                db.NewsFeeds.Add(feed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feed);
        }

        [HttpGet]
        public ActionResult SendMessage()
        {
            ViewBag.Users = db.Users.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(NormalMessage message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        public ActionResult ViewMessages()
        {
           var AdminMessages= db.Messages.OfType<MessageToAdmin>().ToList();
            return View(AdminMessages);
        }

        public ActionResult ListOfJobSeeker()
        {
           var jobSeekerList= db.Users.OfType<JobSeeker>().ToList();
            return View(jobSeekerList);

        }
        public ActionResult ListOfCompanies()
        {
            var CompanyList = db.Users.OfType<Company>().ToList();
            return View(CompanyList);

        }

        public ActionResult SelectUserToCancel()
        {
            return View();
        }

        public ActionResult CancelRegistrationList()
        {
            return View(db.Users.ToList());
        }

        public ActionResult CancelRegistration(string UserId)
        {
            var user = db.Users.Single(x => x.Id == UserId);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}