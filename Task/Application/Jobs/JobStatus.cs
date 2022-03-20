using Domain;
using MediatR;
using Persistence;

namespace Application.Jobs;
public class JobStatus
{
    public class Command : IRequest
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var job = await _context.Jobs.FindAsync(request.Id);

            job.Status = request.Status; // validation can be done via fluid validation for the correct string.

            job.Updated = DateTime.Now;

            _context.Jobs.Update(job);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}