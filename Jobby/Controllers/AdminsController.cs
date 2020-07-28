using Jobby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobby.Controllers
{
    public class AdminsController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Cpanel()
        {

            return View();
        
        }



    }
}
