using Jobby.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Jobby.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        
        ApplicationDbContext db = new ApplicationDbContext();
        [Authorize(Roles = "Admins")]
        public ActionResult Users(string idusr) //users 
        {
            List<ApplicationUser> findusr = new List<ApplicationUser>();
            if (idusr == null)
            {
                var allUsers = db.Users.ToList();
                return View(allUsers);
            }
            else
            {
                findusr = db.Users.Where(fu => fu.Email.Contains(idusr) || fu.UserName.Contains(idusr)   || fu.usertype.Contains(idusr)).ToList();
                return View(findusr);

            }
            
            
          }

          
           


        public ActionResult information(string id)                                       //user profile
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userinfo = db.Users.FirstOrDefault(u => u.Id == id);
            if ( userinfo== null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        [Authorize]
        public ActionResult EditUser(string id)                                          //Edit  user profile
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }




            var usertoedit = db.Users.Find(id);
            Session["oldpp"] = usertoedit.photo;
            return View(usertoedit);
        }

       
        [HttpPost]
        public ActionResult EditUser(ApplicationUser usermodified,HttpPostedFileBase photo)                     //Edit user   profile
        {
            ApplicationDbContext db = new ApplicationDbContext();
           

            if (ModelState.IsValid)
            {

                if (usermodified.photo == null) { usermodified.photo = (string)Session["oldpp"]; } //user not change photo.. to set it to old, unless will be null in DB
               //user chane to new one not in server or in BD
               //add it first to server then to DB
                else
                {
                    string path = Path.Combine(Server.MapPath("~/img"), photo.FileName);
                    photo.SaveAs(path);
                    usermodified.photo = photo.FileName;
                }
                db.Entry(usermodified).State = EntityState.Modified;
               
                db.SaveChanges();
                return RedirectToAction("index", "Home");

            }
            return View(usermodified);

        }


        //DeleteUser
        [Authorize(Roles = "Admins")]
        public ActionResult DeleteUser(string id)                                      //deleting user
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var usertodeleted = db.Users.Find(id);
            return View(usertodeleted);
        }
        
        [Authorize(Roles = "Admins")]
        [HttpPost]
        public ActionResult DeleteUser(string id, ApplicationUser user)               //deleting user
        {
            ApplicationDbContext db = new ApplicationDbContext();

            user = db.Users.Find(id);
            if (user.usertype == "Recrutier")
            {
                var JobsByThisUser = db.jobs.Where(jbu => jbu.Userid == user.Id);
                db.jobs.RemoveRange(JobsByThisUser);
            }

            else if (user.usertype == "Candidate")
            {
                var JobsAppliedByThisUser = db.AppliedUsers.Where(jbu => jbu.AppliedUserId == user.Id);
                db.AppliedUsers.RemoveRange(JobsAppliedByThisUser);

            }

         
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Users");
        }


    }
}