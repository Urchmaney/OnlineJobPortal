using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJobPortal3.Models
{
    public enum NewsToWhom{ company,jobseeker,All}

    public class NewsFeed
    {
        public int NewsFeedID { get; set; }

        [Required]
        [Display(Name = "Title of News")]
        public string  NewsTitle { get; set; }

        [Required]
        [Display(Name = "News")]
        public string  News { get; set; }

        [Required]
        [Display(Name = "Publication Date")]
        public DateTime DateOfPublication { get; set; }

        [Required]
        [Display(Name = "Directed To ")]
        public NewsToWhom NewsToWhom { get; set; }
    }
}