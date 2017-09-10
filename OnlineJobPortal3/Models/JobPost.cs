using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal3.Models
{
    public class JobPost
    {
        public int JobPostID { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobName { get; set; }

        [Required]
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }

        [Required]
        [Display(Name = "Job City")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Work Experience")]
        public int WorkExperience { get; set; }

        [Required]
        [Display(Name = "Minimum Salary")]
        public int MinimumSalary { get; set; }

        public string ApplcationUserID { get; set; }

        public Company Company { get; set; }

       

        public List<JobApplication> Applications { get; set; }
    }
}