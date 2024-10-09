using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinkUpSercice.Models;
using Microsoft.AspNetCore.Authorization;
using LinkUpService.Models.DTO;
using LinkUpSercice.Services.Interfaces;

namespace LinkUpSercice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // GET: api/Job
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
        {
            return Ok(await _jobService.GetAllJobsAsync());
        }

        // GET: api/Job/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Job>> GetJob(Guid id)
        {
            var job = await _jobService.GetJobByIdAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // POST: api/Job
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Job>> PostJob(JobRequest jobRequest)
        {
            var job = await _jobService.CreateJobAsync(jobRequest);
            return CreatedAtAction(nameof(GetJob), new { id = job.JobId }, job);
        }

        // PUT: api/Job/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutJob(Guid id, JobRequest jobRequest)
        {
            var updatedJob = await _jobService.UpdateJobAsync(id, jobRequest);

            if (updatedJob == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Job/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteJob(Guid id)
        {
            await _jobService.DeleteJobAsync(id);
            return NoContent();
        }
    }
}