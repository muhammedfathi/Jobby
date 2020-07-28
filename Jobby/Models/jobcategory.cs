using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobby.Models
{
    public class jobcategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        
        [Display(Name = "Category Name")]
        public string jCategory { get; set; }

        [Required]
        [Display(Name = "Category Description")]
        public string Category_desc { get; set; }

        public virtual ICollection<job> jobs { get; set; }
    }
}