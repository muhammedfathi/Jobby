using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobby.Models
{
    public class SaveJobs
    {

        public int Id { get; set; }
      

        public string UserId { get; set; }
        public int JobId { get; set; }


        public virtual job job { get; set; }
        public virtual ApplicationUser user { get; set; }

    }
}