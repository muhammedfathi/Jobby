using Jobby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Jobby.Controllers
{

    [Authorize(Roles ="Recrutier")]
    public class RecrutierController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Recrutier
        
        public ActionResult RecrutierApplication(string id)                     //posted Application by logged-in Recrutier
        {
            id = User.Identity.GetUserId();
            var jobapps = db.jobs.Where(jobs => jobs.Userid == id);
            return View(jobapps);
        }
        public ActionResult AppliedCanditate(int? id)                           // Candidate Applied for this Job
        {

            var candidates = db.AppliedUsers.Where(app => app.JobId == id);

            ViewBag.jobname = db.jobs.Find(id).job_Name;

            return View(candidates.ToList());
        }

        [HttpGet]
        public ActionResult EditApplication(int? id)                           //
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var application = db.jobs.Find(id);
            
            if (application == null)
            {
                return HttpNotFound();
            }

           

            return View(application);
        }

        [HttpPost]
        public ActionResult EditApplication(job newapplication)                           // 
        {
            if (ModelState.IsValid)
            {
                db.Entry(newapplication).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("RecrutierApplication", "Recrutier", new { @id = newapplication.Userid });
            }

            return View(newapplication);
        }

        public ActionResult DeleteApplication(int? id)
        {
            if (id == null)
            { 
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var application = db.jobs.Find(id);
           
            if (application == null)
            {
                return HttpNotFound();
            }

            return View(application);
        
        }

        [HttpPost]
        public ActionResult DeleteApplication(int id)
        {
            job app = db.jobs.Find(id);
            db.jobs.Remove(app);
            db.SaveChanges();



            return RedirectToAction("RecrutierApplication", "Recrutier", new { @id =User.Identity.GetUserId() });

        }


    }
}