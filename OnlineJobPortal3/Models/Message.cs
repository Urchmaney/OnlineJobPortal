using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJobPortal3.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string msg { get; set; }

        public string SenderID { get; set; }

        public ApplicationUser Sender { get; set; }

        
    }
}