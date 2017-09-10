using Microsoft.AspNet.Identity;
using OnlineJobPortal3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJobPortal3.Controllers
{
    [Authorize(Roles = "Company")]
    public class CompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Companies
        public ActionResult Index()
        {
            
            return View(db.ApplicationUsers.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult PostJob()
        {

            return View();
        }

        [HttpPost]
        public ActionResult PostJob(JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                jobPost.ApplcationUserID = User.Identity.GetUserId();
                db.JobPosts.Add(jobPost);
                db.SaveChanges();
                ViewBag.Message = "You Have successfully Uploaded job Vacancy";
                return View("Success");
            }
            return View();
        }


        public ActionResult NewsFeed()
        {
            var NewsFeed = db.NewsFeeds.Where(x => x.NewsToWhom == NewsToWhom.company || x.NewsToWhom == NewsToWhom.All);
            return View(NewsFeed);
        }

        [HttpGet]
        public ActionResult MsgAdmin()
        {
            return View();
        }

       public ActionResult ListJobPost()
        {
            var ListOfJobPost = db.JobPosts.Where(x => x.ApplcationUserID == User.Identity.GetUserId());
            return View(ListOfJobPost);
        }
        //public ActionResult ListJobSeekersInJobPost(int JobPostID)
        //{
        //  //  var ListOfJobSeekers = db.JobPosts.Single(x => x.JobPostID == JobPostID).JobSeekersAppliedFOr;
        //    return View(ListOfJobSeekers);
        //}

        [HttpGet]
        public ActionResult MsgJobSeeker(string jobSeekerID)
        {
            ViewBag.jobSeekerID = jobSeekerID;
            return View();
        }

        [HttpPost]
        public ActionResult MsgJobSeeker(NormalMessage message)
        {
            if (ModelState.IsValid)
            {
                message.SenderID = User.Identity.GetUserId();
                db.Messages.Add(message);
                db.SaveChanges();
                @ViewBag.Message = "You Have Successfully sent The Message";
                return View("Success");
            }
            return View(message);
        }

        [HttpPost]
        public ActionResult MsgAdmin(MessageToAdmin msg)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(msg);
                db.SaveChanges();
                return RedirectToAction("Index");
             }
            return View(msg);
        }
        public ActionResult JobPostListForApplicant()
        {
            var CurrentUserId = User.Identity.GetUserId();
            var JobPostList = db.JobPosts.Where(x => x.ApplcationUserID == CurrentUserId).ToList();
            return View(JobPostList);
        }
        public ActionResult Applicants(int JobPostId)
        {
            List<JobSeeker> jobSeekers = new List<JobSeeker>();
            var ApplicationList = db.JobApplications.Where(x => x.JobPostId == JobPostId).ToList();

            foreach(JobApplication app in ApplicationList)
            {
                jobSeekers.Add(db.Users.OfType<JobSeeker>().Single(x => x.Id == app.JobSeekerId));
            }
          //  var JobseekerForJobPost = db.Users.OfType<JobSeeker>().Where(x => x.JobPostsAppliedFor.Any(y => y.JobPostID == JobPostId)).ToList();
            return View(jobSeekers);
        }

        public ActionResult ViewSeekerprofile(string id,int JobPostId)
        {
            var SeekerProfile = db.JobApplications.Where(x => x.JobPostId == JobPostId && x.JobSeekerId == id).FirstOrDefault();
            return View(SeekerProfile);
        }

        public ActionResult MessageSeeker(string id)
        {
            return RedirectToAction("MsgJobSeeker",new { jobSeekerID=id });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
