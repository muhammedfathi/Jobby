using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jobby.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Jobby.Controllers
{
    [Authorize(Roles ="Admins")]
    public class RolesController : Controller
    {
      private  ApplicationDbContext db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()                 //display All Roles
        {
           
            return View(db.Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(string id)
        {
            var role = db.Roles.Find(id);

            if (role == null)
                return HttpNotFound();


            return View(role);

        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");

            
            }
            return View(role);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id != null)
                return View(db.Roles.Find(id));

            else
                return HttpNotFound();
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            
            }

            return View(role);
            
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id != null)
                return View(db.Roles.Find(id));

            else
                return HttpNotFound();
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole r)
        {
            var del = db.Roles.Find(r.Id);
            if (del.Id == null)
                return HttpNotFound();
            else
            {
                db.Roles.Remove(del);
                db.SaveChanges();
                return RedirectToAction("Index");
            
            }
 
        }
    }
}
