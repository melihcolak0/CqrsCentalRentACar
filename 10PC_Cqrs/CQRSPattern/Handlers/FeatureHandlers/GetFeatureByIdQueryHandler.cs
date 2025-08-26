using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Queries.FeatureQueries;
using _10PC_Cqrs.CQRSPattern.Results.FeatureResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler
    {
        private readonly CqrsContext _context;

        public GetFeatureByIdQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery query)
        {
            var value = await _context.Features.AsNoTracking().FirstOrDefaultAsync(x => x.FeatureId == query.Id);

            return new GetFeatureByIdQueryResult
            {
                FeatureId = value.FeatureId,
                Description = value.Description,
                IconUrl = value.IconUrl,
                Title = value.Title
            };
        }
    }
}
