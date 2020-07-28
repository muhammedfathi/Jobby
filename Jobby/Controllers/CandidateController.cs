using Jobby.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobby.Controllers
{
    [Authorize (Roles ="Candidate")]
    public class CandidateController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
       

        public ActionResult AppliedJob(int? id)                         // Apply for A job Application 
        {
            AppliedUser tryingtoapplyuser = new AppliedUser();
            if (id == null)
            {
                return HttpNotFound();
            }

            Session["jobId"] = id;                                           // to send it to post method !!!
            tryingtoapplyuser.AppliedUserId = User.Identity.GetUserId();
            tryingtoapplyuser.JobId = (int)Session["jobId"];

            try
            {
                //check if the user applied before or not by its ID And the Job_ID 
                if (db.AppliedUsers.Where
                       ((ch => ch.AppliedUserId == tryingtoapplyuser.AppliedUserId && ch.JobId == tryingtoapplyuser.JobId))
                    .FirstOrDefault().IsApplied == true)
                {


                  var infoofuser = db.AppliedUsers.Where(c => c.AppliedUserId == tryingtoapplyuser.AppliedUserId && c.JobId == tryingtoapplyuser.JobId).FirstOrDefault();

                    return RedirectToAction("applied", "Candidate",new {dt =infoofuser.Applyon, masge = infoofuser.UserMessage }); //  applied before view;

                }

            }

            catch
            {
                
            }

            return View();


        }
        [HttpPost]
        public ActionResult AppliedJob(AppliedUser appuser)             //user Apply for A job Application  [post]
        {
            if (ModelState.IsValid)
            {

                appuser.AppliedUserId = User.Identity.GetUserId();
                appuser.JobId = (int)Session["jobId"];
                appuser.Applyon = DateTime.Now;
                appuser.IsApplied = true;
                db.AppliedUsers.Add(appuser);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(appuser);
        }

        public ActionResult applied( DateTime? dt,string masge )                                    //is user apply for this job before? 
        {
            if (dt == null || masge==null)
            {
                return HttpNotFound();
             }
           
            ViewBag.msg =masge;
            ViewBag.on = dt;
            return View();
        }
       
        public ActionResult application()                                // applicationS  applied before by logged-in-user
        {
            
            var Loggedinuser_id = User.Identity.GetUserId();
            //get the user from  tbl appliedusers if exist
            var applications = db.AppliedUsers.Where(app => app.AppliedUserId == Loggedinuser_id);
            return View(applications.ToList());
        }
        
        public ActionResult app_details(int? id)
        {
            var application = db.jobs.Find(id);


            return View(application);
        }                      //more  Deatils about application  (desc// reguiremts //...)


       public ActionResult app_Edit(int? id )                            // get application to edit it
        {
            if (id == null)
                return HttpNotFound();

            var usrid = User.Identity.GetUserId();
            var editapp = db.AppliedUsers.Where(app => app.JobId == id && app.AppliedUserId == usrid).FirstOrDefault();

            return View(editapp);
        }
       
        [HttpPost]
        public ActionResult app_Edit( AppliedUser newappl)
        {
            var us = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                var application               = db.AppliedUsers.Where(ap=>ap.JobId==newappl.JobId && ap.AppliedUserId==us).SingleOrDefault();
               
                application.AppliedUserId     = newappl.AppliedUserId;
                application.JobId             = newappl.JobId;
                application.IsApplied         = newappl.IsApplied;
                application.UserMessage       = newappl.UserMessage;
                application.Applyon           = DateTime.Now;
                

                db.SaveChanges();
                return RedirectToAction("application");


            }
            return View(newappl);
        
        
        }




        [HttpPost]
        public ActionResult app_Delete(int? id)                        //delete application  no get method( post with alert)
        {

                var usrid = User.Identity.GetUserId();


                var deletedapps = db.AppliedUsers.Where(app => app.JobId == id && app.AppliedUserId == usrid).FirstOrDefault();
                db.AppliedUsers.Remove(deletedapps);
                db.SaveChanges();

                return RedirectToAction("application", "Candidate");


        }

        //public ActionResult SavedJob(int? id)
        //{



        //    return View();
        //}
        //[HttpPost]
        //public ActionResult SaveJob(int id)
        //{
        //    var usrid = User.Identity.GetUserId();
        //    SaveJob Sj = new SaveJob();
        //    Sj.JobId = id;
        //    Sj.UserId = usrid;
            


        //    return View();
        
        
        //}


    }
}
