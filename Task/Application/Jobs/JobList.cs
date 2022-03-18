using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Jobs;

public class JobList
{
    public class Query : IRequest<List<Job>> {}

    public class Handler : IRequestHandler<Query, List<Job>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            this._context = context;
        }

        public async Task<List<Job>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Jobs.ToListAsync(cancellationToken);
        }
    }
}