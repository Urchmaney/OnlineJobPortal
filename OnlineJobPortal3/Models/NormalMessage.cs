using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobPortal3.Models
{
    public class NormalMessage :Message
    {
        public string RecipientID { get; set; }

        public ApplicationUser Recipient { get; set; }
    }
}