using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJobPortal3.Models
{
    public class JobApplication
    {
        public int JobApplicationID { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        [Display(Name = "Course studied")]
        public string CourseStudied { get; set; }


        [Display(Name = "Year Of Graduation")]
        public int YearOfGraduation { get; set; }

        public int Experience { get; set; }

        public string Designation { get; set; }

        public string JobSeekerId { get; set; }

        
        public int JobPostId { get; set; }

        public JobPost JobPost { get; set; }

        public JobSeeker JobSeeker { get; set; }
    }
}