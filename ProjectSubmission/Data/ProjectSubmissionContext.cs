using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectSubmission.Models
{
    public class ProjectSubmissionContext : DbContext
    {
        public ProjectSubmissionContext (DbContextOptions<ProjectSubmissionContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectSubmission.Models.Submissions> Submissions { get; set; }
        public DbSet<ProjectSubmission.Models.Submissions> Admin { get; set; }
    }
}
