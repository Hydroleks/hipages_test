using Application.DTOs;
using Application.Jobs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class JobController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<JobDto>>> GetJobsAsync(CancellationToken cancellationToken)
    {
        return await Mediator.Send(new JobList.Query(), cancellationToken);
    }

    [HttpPut("{id}/{status}")]
    public async Task<IActionResult> EditJobAsync(Guid id, string status, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new JobStatus.Command{ Id = id, Status = status }, cancellationToken));
    }
}