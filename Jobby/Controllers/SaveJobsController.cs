using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Jobby.Models;
using Microsoft.AspNet.Identity;

namespace Jobby.Controllers
{
    [Authorize (Roles ="Candidate")]
    public class SaveJobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET all SavedJobs for currentUser
        public ActionResult SavedJobs()
        {
            var Loginuser = User.Identity.GetUserId();
            var SavedJobs= db.SaveJobs.Where(jj => jj.UserId == Loginuser).ToList();

            
            return View(SavedJobs);
        }


        // POST: SaveJobs/saveJob
        [HttpPost]
        public ActionResult SaveJob(int id )
        {
            SaveJobs saveJobs = new SaveJobs();
            saveJobs.JobId = id;
            saveJobs.UserId = User.Identity.GetUserId();
            db.SaveJobs.Add(saveJobs);
            db.SaveChanges();
            return RedirectToAction("Details","jobs",new { id=id});
        }
       

        // POST: SaveJobs/UnsaveJob

        public ActionResult UnSaveJob(int id)
        {
            var lginuser = User.Identity.GetUserId();
            var saveJobs = db.SaveJobs.Where(sj => sj.JobId ==id && sj.UserId ==lginuser );
            db.SaveJobs.RemoveRange(saveJobs);
            db.SaveChanges();
            return RedirectToAction("Details", "jobs", new { id = id });
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
