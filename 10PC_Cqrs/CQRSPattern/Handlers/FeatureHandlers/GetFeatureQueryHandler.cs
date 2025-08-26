using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.FeatureResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler
    {
        private readonly CqrsContext _context;

        public GetFeatureQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<List<GetFeatureQueryResult>> Handle()
        {
            var values = await _context.Features.AsNoTracking().ToListAsync();

            return values.Select(x => new GetFeatureQueryResult
            {
                FeatureId = x.FeatureId,
                Description = x.Description,
                Title = x.Title,
                IconUrl = x.IconUrl,
            }).ToList();
        }
    }
}
