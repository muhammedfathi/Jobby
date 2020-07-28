using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Jobby.Models
{
    public class job
    {

        public int jobID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string job_Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string job_description { get; set; }
        [Required]
        [Display(Name = "Requirments")]
        public string job_requirments { get; set; }
        [Required]
        [Display(Name = "Company name")]
        public string PostedBy { get; set; }
        

        public string PostedOn { get; set; }
       
        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        public   bool  IsApproved { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Cat_name { get; set; }

      
        public string Userid { get; set; }

        public  virtual ApplicationUser user { get; set; }
        public virtual ICollection<jobcategory> category { get; set; }



    }
}