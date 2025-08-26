using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.AboutResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly CqrsContext _context;

        public GetAboutQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values = await _context.Abouts.AsNoTracking().ToListAsync();

            return values.Select(x => new GetAboutQueryResult
            {
                AboutId = x.AboutId,
                Description = x.Description,
                Mision = x.Mision,
                Vision = x.Vision
            }).ToList();
        }
    }
}
