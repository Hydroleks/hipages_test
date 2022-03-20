using Application.DTOs;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Jobs;

public class JobList
{
    public class Query : IRequest<List<JobDto>> {}

    public class Handler : IRequestHandler<Query, List<JobDto>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            this._context = context;
        }

        public async Task<List<JobDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await 
            (
                from job in _context.Jobs
                    join category in _context.Categories 
                        on job.CategoryId equals category.Id
                    join suburb in _context.Suburbs
                        on job.SuburbId equals suburb.Id
                where job.Status != "declined"
                select new JobDto
                {
                    Id = job.Id,
                    Status = job.Status,
                    Suburb = suburb.Name,
                    Category = category.Name,
                    ContactName = job.ContactName,
                    ContactPhone = job.ContactPhone,
                    ContactEmail = job.ContactEmail,
                    Price = job.Price,
                    Description = job.Description,
                    Created = job.Created,
                    Updated = job.Updated
                }
            ).ToListAsync(cancellationToken);
        }
    }
}