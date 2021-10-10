using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Studio3.Models
{
    public class MailModel
    {
        [Required(ErrorMessage = "Please enter the receiver")]
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}