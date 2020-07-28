using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Jobby.Models
{
    public class AppliedUser
    {
       

        public int Id { get; set; }
        public string UserMessage { get; set; }
        public DateTime Applyon { get; set; }

        public string AppliedUserId { get; set; }
        public int JobId { get; set; }

        public bool IsApplied { get; set; }

        public virtual job job { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}