using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.CarResults;

namespace _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers
{
    public class GetCarModelCountQueryHandler
    {
        private readonly CqrsContext _context;

        public GetCarModelCountQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public List<GetCarModelCountQueryResult> Handle()
        {
            var values = _context.Cars
                .GroupBy(x => x.Gear)
                .Select(g => new GetCarModelCountQueryResult
                {
                    Model = g.Key,
                    Count = g.Count()
                })
                .ToList();

            return values;
        }
    }
}
