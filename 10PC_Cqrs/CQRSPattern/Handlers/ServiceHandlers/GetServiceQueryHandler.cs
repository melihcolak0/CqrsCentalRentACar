using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.ServiceResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler
    {
        private readonly CqrsContext _context;

        public GetServiceQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<List<GetServiceQueryResult>> Handle()
        {
            var values = await _context.Services.AsNoTracking().ToListAsync();

            return values.Select(x => new GetServiceQueryResult
            {
                ServiceId = x.ServiceId,
                Description = x.Description,
                IconUrl = x.IconUrl,
                Title = x.Title
            }).ToList();
        }
    }
}
