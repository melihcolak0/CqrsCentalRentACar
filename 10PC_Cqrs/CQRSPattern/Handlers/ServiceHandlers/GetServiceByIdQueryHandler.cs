using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Queries.ServiceQueries;
using _10PC_Cqrs.CQRSPattern.Results.ServiceResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler
    {
        private readonly CqrsContext _context;

        public GetServiceByIdQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery query)
        {
            var value = await _context.Services.AsNoTracking().FirstOrDefaultAsync(x => x.ServiceId == query.Id);

            return new GetServiceByIdQueryResult
            {
                ServiceId = value.ServiceId,
                Description = value.Description,
                Title = value.Title,
                IconUrl = value.IconUrl
            };
        }
    }
}
