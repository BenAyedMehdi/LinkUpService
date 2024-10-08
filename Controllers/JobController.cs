using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LinkUpSercice.Models;

namespace LinkUpSercice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetJobs()
        {
            // Logic to retrieve all jobs
            return Ok(new { Message = "List of all jobs" });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateJob([FromBody] JobModel model)
        {
            // Logic to create a new job
            return Ok(new { Message = "Job created successfully" });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateJob(int id, [FromBody] JobModel model)
        {
            // Logic to update a job
            return Ok(new { Message = $"Job {id} updated successfully" });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteJob(int id)
        {
            // Logic to delete a job
            return Ok(new { Message = $"Job {id} deleted successfully" });
        }
    }

    public class JobModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        // Add other job-related properties
    }
}