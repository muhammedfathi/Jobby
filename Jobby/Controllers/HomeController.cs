using Jobby.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Jobby.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            //var usermanger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            return View();
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Contact(ContactUs contact)
        {
            // credintial email to used in smtp client(send msg to destination email from this mail)
            var middlemail = new NetworkCredential("jobby6503@gmail.com", "jobby@93");  //(1)

            //create msg object to form msg body(to,from,subj,msgtext) (2)
            var mail = new MailMessage();
            if (ModelState.IsValid)
            {
                //fill msg field
                mail.From = new MailAddress(contact.Mail);
                mail.To.Add(new MailAddress("muhamedfathics@gmail.com"));
                mail.Subject = contact.Subject;
                mail.IsBodyHtml = true;                   // to send html tags
                string body = "<q>" + contact.Message + "</q>" + "<br>" + "<br>" + "By : " + "<b>" + contact.Name + "</b>" + "<br>" +

                            "E-mail Address : " + contact.Mail;
                mail.Body = body;
            }


            ///// we can send it only throw smtpClient  (3)
            try
            {
                SmtpClient SC = new SmtpClient("smtp.gmail.com", 587);
                SC.EnableSsl = true;
                SC.Credentials = middlemail;
                SC.Send(mail);
                return RedirectToAction("index");
            }

            catch
            {
                ViewBag.net = "Check internet Connection and Resend it Again";
            }
            return View(contact);


        }



        [HttpPost]
        [Authorize(Roles ="Candidate")]
        public ActionResult Search(string searching)
        {

            var search_result = db.jobs.Where(jb => jb.job_Name.Contains(searching) || jb.job_description.Contains(searching)

              || jb.job_requirments.Contains(searching)
            );

            ViewBag.srch = searching;

            return View(search_result);
        }

        public ActionResult Mofathi()
        {
            return View();
        }




    }
}