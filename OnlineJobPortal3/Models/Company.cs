using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal3.Models
{
    public class Company:ApplicationUser
    {
        [Required]
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Head office City")]
        public string HeadOfficeCity { get; set; }

        [Required]
        [Display(Name = "Head office Contact")]
        public string HeadOfficeContactNo { get; set; }

        [Required]
        [Display(Name = "No of Branches")]
        public int NoOfBranch { get; set; }

        [Required]
        [Display(Name = "Company Mail")]
        public string CompanyMail { get; set; }

        [Required]
        [Display(Name = "Company Type")]
        public string CompanyType { get; set; }

        [Required]
        [Display(Name = "Company Website")]
        public string CompanyWebsite { get; set; }

        public List<JobPost> JobPosts { get; set; }

        public List<Message> Messages { get; set; }
    }
}