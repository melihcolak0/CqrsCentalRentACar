using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Queries.AboutQueries;
using _10PC_Cqrs.CQRSPattern.Results.AboutResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly CqrsContext _context;

        public GetAboutByIdQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var value = await _context.Abouts.AsNoTracking().FirstOrDefaultAsync(x => x.AboutId == query.Id);

            return new GetAboutByIdQueryResult
            {
                AboutId = value.AboutId,
                Description = value.Description,
                Vision = value.Vision,
                Mision = value.Mision
            };
        }
    }
}
