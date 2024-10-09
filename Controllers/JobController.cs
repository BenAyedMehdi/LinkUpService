using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinkUpSercice.Models;
using Microsoft.AspNetCore.Authorization;
using LinkUpSercice.Data;
using LinkUpService.Models.DTO;

namespace LinkUpSercice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Job
        [HttpGet]
        [AllowAnonymous] // Allow unauthenticated access to view jobs
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
        {
            return await _context.Jobs.ToListAsync();
        }

        // GET: api/Job/5
        [HttpGet("{id}")]
        [AllowAnonymous] // Allow unauthenticated access to view a specific job
        public async Task<ActionResult<Job>> GetJob(Guid id)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // POST: api/Job
        [HttpPost]
        [Authorize(Roles = "Admin")] // Only allow admins to create jobs
        public async Task<ActionResult<Job>> PostJob(JobRequest jobRequest)
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

            return CreatedAtAction(nameof(GetJob), new { id = job.JobId }, job);
        }

        //// PUT: api/Job/5
        //[HttpPut("{id}")]
        //[Authorize(Roles = "Admin")] // Only allow admins to update jobs
        //public async Task<IActionResult> PutJob(Guid id, JobRequest jobRequest)
        //{
        //    var job = await _context.Jobs.FindAsync(id);

        //    if (job == null)
        //    {
        //        return NotFound();
        //    } 

        //    job.UpdatedDate = DateTime.UtcNow;
        //    _context.Entry(job).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!JobExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // DELETE: api/Job/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Only allow admins to delete jobs
        public async Task<IActionResult> DeleteJob(Guid id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobExists(Guid id)
        {
            return _context.Jobs.Any(e => e.JobId == id);
        }
    }
}