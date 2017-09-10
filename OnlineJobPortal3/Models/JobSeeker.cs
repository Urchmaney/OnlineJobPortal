using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal3.Models
{
    public class JobSeeker :ApplicationUser
    {

        public string Title { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string ContactNo { get; set; }


        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }


        public List<JobApplication> Applications { get; set; }

        public List<Message> Messages { get; set; }

    }
}