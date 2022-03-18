using Application.Jobs;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class JobController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<Job>>> GetJobsAsync(CancellationToken cancellationToken)
    {
        return await Mediator.Send(new JobList.Query(), cancellationToken);
    }
}