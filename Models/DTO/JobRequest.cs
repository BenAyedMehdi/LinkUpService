using System;

namespace LinkUpService.Models.DTO
{
    public class JobRequest
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; } // e.g., Full-time, Part-time, Contract
        public string Employer { get; set; } 
        public string Description { get; set; }
    }
}