using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Jobby.Models;

namespace Jobby.Controllers
{
    [Authorize]
    public class jobcategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: jobcategories
      
        public ActionResult Index()
        {
            return View(db.jobcategories.ToList());
        }


        [HttpPost]
        public ActionResult Index(string category)
        {
            var cats = db.jobcategories.Where(gg => gg.jCategory.Contains(category) || gg.Category_desc.Contains(category));
            return View(cats);
        }




        // GET: jobcategories/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jobcategory = db.jobcategories.Find(id);
            if (jobcategory == null)
            {
                return HttpNotFound();
            }
            return View(jobcategory);
        }

        // GET: jobcategories/Create


      

        public ActionResult Create()
        {
            return View();
        }

        // POST: jobcategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,jCategory,Category_desc")] jobcategory jobcategory)
        {
            if (ModelState.IsValid)
            {
                db.jobcategories.Add(jobcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobcategory);
        }

        // GET: jobcategories/Edit/5
        
        public ActionResult Edit(int? CategoryId)
        {
            if (CategoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jobcategory jobcategory = db.jobcategories.Find(CategoryId);
            if (jobcategory == null)
            {
                return HttpNotFound();
            }
            return View(jobcategory);
        }

        // POST: jobcategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,jCategory,Category_desc")] jobcategory jobcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobcategory);
        }

        // GET: jobcategories/Delete/5
       
        public ActionResult Delete(int? CategoryId)
        {
            if (CategoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jobcategory jobcategory = db.jobcategories.Find(CategoryId);
            if (jobcategory == null)
            {
                return HttpNotFound();
            }
            return View(jobcategory);
        }

        // POST: jobcategories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int CategoryId)
        {
            jobcategory jobcategory = db.jobcategories.Find(CategoryId);
            var jobincatg = db.jobs.Where(jj => jj.Cat_name == jobcategory.jCategory);
            db.jobs.RemoveRange(jobincatg);
            db.jobcategories.Remove(jobcategory);
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
