using LinkUpSercice.Data;
using LinkUpSercice.Models;
using LinkUpSercice.Services.Interfaces;
using LinkUpService.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkUpSercice.Services
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job> GetJobByIdAsync(Guid id)
        {
            return await _context.Jobs.FindAsync(id);
        }

        public async Task<Job> CreateJobAsync(JobRequest jobRequest)
        {
            var job = new Job
            {
                JobId = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Title = jobRequest.Title,
                Description = jobRequest.Description,
                Employer = jobRequest.Employer,
                JobType = jobRequest.JobType,
                Location = jobRequest.Location
            };
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<Job> UpdateJobAsync(Guid id, JobRequest jobRequest)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return null;
            }

            job.Title = jobRequest.Title;
            job.Description = jobRequest.Description;
            job.Employer = jobRequest.Employer;
            job.JobType = jobRequest.JobType;
            job.Location = jobRequest.Location;
            job.UpdatedDate = DateTime.UtcNow;

            _context.Entry(job).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task DeleteJobAsync(Guid id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }
        }
    }
}