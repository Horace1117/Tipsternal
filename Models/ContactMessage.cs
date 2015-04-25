using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FootballOdds.Models
{
    public class ContactMessage 
    {   
        [Required(ErrorMessage="Please provide your name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage="Please Provide your email address")]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessage="Please provide your message")]
        public string CustomerMessage { get; set; }
    }
}