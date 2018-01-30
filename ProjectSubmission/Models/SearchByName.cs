using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectSubmission.Models
{
    public class SearchByName
    {
        public List<Submissions> userSubmissions;
        public SelectList names;
        public String submitterNames { get; set; }
    }
}