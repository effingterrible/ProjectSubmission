using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectSubmission.Models
{
    public class Submissions
    {
        public int ID { get; set; }
        [Display(Name="Submitter")]
        public String submitter { get; set; }
        [Display(Name = "Submission")]
        public String submission { get; set; }
        [Display(Name = "Reference Ticket")]
        public int refTicket { get; set; }
        [Display(Name = "Amount of votes!")]
        public int votes { get; set; }
    }

 }
 
