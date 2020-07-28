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
    [Authorize]
    public class jobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string category) //to get job by category//  get all jobs  // get all approved and not job to admins to approve or not;
        {
            ViewBag.field = category;

            if (!User.IsInRole("Admins")) // not Admins
            {
                if (category == null)
                    return View(db.jobs.Where(jb => jb.IsApproved));

                else
                {
                    var modl = db.jobs.Where(m => m.Cat_name == category && m.IsApproved == true);
                    return View(modl);
                }
            }

            else //Admins
            {
                if (category == null)
                    return View(db.jobs);

                var modl = db.jobs.Where(m => m.Cat_name == category);
                return View(modl);


            }
        }

        // GET: jobs/Details/5

        public ActionResult Details(int? id)  //job Details
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job job = db.jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: jobs/Create

        [Authorize(Roles = "Recrutier")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Cat_name = new SelectList(db.jobcategories, "jCategory","jCategory");

            return View();
        }

        // POST: jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Recrutier")]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "job_Name,job_description,job_requirments,PostedBy,Location,Cat_name")]  job job)
        {
            if (ModelState.IsValid)
            {
                job.Userid = User.Identity.GetUserId();
                job.PostedOn = DateTime.Now.ToShortDateString();
                job.IsApproved = false;
                db.jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Cat_name = new SelectList(db.jobcategories, "jCategory", "jCategory");

            return View(job);
        }

        // GET: jobs/Edit/5

        [Authorize(Roles = "Recrutier")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job job = db.jobs.Find(id);

            return View(job);
        }

        // POST: jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jobID,job_Name,job_description,job_requirments,PostedBy,PostedOn,Location,Cat_name")] job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: jobs/Delete/5


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job job = db.jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            job job = db.jobs.Find(id);
            db.jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Approvejob(int id)
        {
            job job = db.jobs.Find(id);
            job.IsApproved = true;
            db.SaveChanges();
            return RedirectToAction("Index");
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
