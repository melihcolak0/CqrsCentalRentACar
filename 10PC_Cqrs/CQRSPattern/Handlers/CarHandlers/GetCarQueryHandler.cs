using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.CarResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly CqrsContext _context;

        public GetCarQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _context.Cars.AsNoTracking().ToListAsync();

            return values.Select(x => new GetCarQueryResult
            {
                CarId = x.CarId,
                Brand = x.Brand,
                Gear = x.Gear,
                ImageUrl = x.ImageUrl,
                Km = x.Km,
                Model = x.Model,
                Petrol = x.Petrol,
                PriceByDay = x.PriceByDay,
                Review = x.Review,
                Seat = x.Seat,
                Transmission = x.Transmission,
                Year = x.Year
            }).ToList();
        }
    }
}
