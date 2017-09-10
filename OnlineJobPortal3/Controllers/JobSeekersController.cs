using Microsoft.AspNet.Identity;
using OnlineJobPortal3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace OnlineJobPortal3.Controllers
{
   // [Authorize(Roles ="JobSeeker")]
    public class JobSeekersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobSeekers
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(int SearchBy)
        {
            ViewBag.SearchBy = SearchBy;
            if (SearchBy == 0)
            {
                ViewBag.Name = "City";
            }
            if (SearchBy == 1)
            {
                ViewBag.Name = "Position";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Search(int SearchBy,string searchWord)
        {
            if (ModelState.IsValid)
            {
                List<JobPost> jobpost;
                if (SearchBy == 0)
                {
                    jobpost = db.JobPosts.Where(x => x.Location.Contains(searchWord)).ToList();
                }
                else if (SearchBy == 1)
                {
                    jobpost = db.JobPosts.Where(x => x.JobName.Contains(searchWord) || x.JobDescription.Contains(searchWord)).ToList();
                }
                else
                {
                    jobpost = new List<JobPost>();
                }
                return View("SearchResult", jobpost);
            }
            return View(searchWord);
        }

       

        [HttpGet]
        public ActionResult SearchJob()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchJob(int SearchBy)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Search", new { SearchBy = SearchBy });
            }
            return View(SearchBy);
        }

        public ActionResult EditDetail()
        {
            var id = User.Identity.GetUserId();
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        
        public ActionResult CompanyJobList(string id)
        {
            var JobList = db.JobPosts.Where(x => x.ApplcationUserID == id).ToList();
            return View(JobList);
        }

        public ActionResult ViewMessage()
        {
            var currentUser = User.Identity.GetUserId();
            var messageList = db.Messages.OfType<NormalMessage>().Where(x => x.RecipientID == currentUser).ToList();
            foreach(var MSG in messageList)
            {
                MSG.Sender = db.Users.Single(x => x.Id == MSG.SenderID);
            }
            return View(messageList);
        }

        [HttpGet]
        public ActionResult ReplyMsg( int id)
        {
            ViewBag.FormerId = id;
            return View();
        }

        [HttpPost]
        public ActionResult ReplyMsg(NormalMessage message, int FormerMsgId)
        {
            var SenderId = db.Messages.Single(x => x.MessageID == FormerMsgId).SenderID;
            message.RecipientID = SenderId;
            message.SenderID = User.Identity.GetUserId();
            db.Messages.Add(message);
            db.SaveChanges();
            ViewBag.Message = "Reply Sent Successfully";
            return View("AppliedSuccess");
        }
        public ActionResult NewsFeed()
        {
            return View(db.NewsFeeds.Where(x => x.NewsToWhom == NewsToWhom.jobseeker || x.NewsToWhom == NewsToWhom.All));
        }


        public ActionResult ViewCompanies()
        {
            //    List<Company> companies=new List<Company>();
            //    var currentUserId = User.Identity.GetUserId();
            //    var jobPost = db.JobPosts.Where(x => x.JobSeekersAppliedFOr.Any(y => y.Id == currentUserId)).ToList();
            //    foreach(JobPost jb in jobPost)
            //    {
            //        var companyId = jb.ApplcationUserID;
            //        Company company = db.Users.OfType<Company>().Single(x =>x.Id == companyId);
            //        companies.Add(company);
            //    }

            return View(db.Users.OfType<Company>().ToList());
        }

     

        public ActionResult EditDetails()
        {
            var user = db.Users.OfType<JobSeeker>().Single(x => x.Id == User.Identity.GetUserId());
           
            return View(user);
        }

        public ActionResult ApplyForJob(int id)
        {
            ViewBag.JobPostID = id;
            //var jobPost = db.JobPosts.Single(x => x.JobPostID == id);
            //var currentUserId = User.Identity.GetUserId();
            //if (jobPost.JobSeekersAppliedFOr == null)
            //{
            //    jobPost.JobSeekersAppliedFOr = new List<JobSeeker>();
            //}
            //jobPost.JobSeekersAppliedFOr.Add(db.Users.OfType<JobSeeker>().Single(x => x.Id ==currentUserId));
            //db.SaveChanges();
            return View();
        }

        public ActionResult ApplyForJob(JobApplication application)
        {
            if (ModelState.IsValid)
            {
                application.JobSeekerId = User.Identity.GetUserId();
                db.JobApplications.Add(application);
                db.SaveChanges();

                ViewBag.Message = "Applied Successfully";
                return View("AppliedSuccess");
            }
           
            return View(application);
        }
    }
}