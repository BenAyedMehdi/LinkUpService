using System;
using System.Collections.Generic;

namespace LinkUpSercice.Models
{
    public class Job
    {
        public Guid JobId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; } // e.g., Full-time, Part-time, Contract
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Employer { get; set; } // This can be a hospital or any other employer
        public string Description { get; set; }
        //public List<string> Responsibilities { get; set; }
        //public List<string> Qualifications { get; set; }
        //public List<string> Benefits { get; set; }
    }
}