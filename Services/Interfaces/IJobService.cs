using LinkUpSercice.Models;
using LinkUpService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkUpSercice.Services.Interfaces
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<Job> GetJobByIdAsync(Guid id);
        Task<Job> CreateJobAsync(JobRequest jobRequest);
        Task<Job> UpdateJobAsync(Guid id, JobRequest jobRequest);
        Task DeleteJobAsync(Guid id);
    }
}