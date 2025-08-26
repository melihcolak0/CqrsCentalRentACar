using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.CarResults;

namespace _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers
{
    public class GetCarBrandAveragePriceQueryHandler
    {
        private readonly CqrsContext _context;

        public GetCarBrandAveragePriceQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public List<GetCarBrandAveragePriceQueryResult> Handle()
        {
            var result = _context.Cars
                .GroupBy(c => c.Brand)
                .Select(g => new GetCarBrandAveragePriceQueryResult
                {
                    Brand = g.Key,
                    AveragePrice = (double)g.Average(c => c.PriceByDay)
                })
                .ToList();

            return result;
        }
    }
}
