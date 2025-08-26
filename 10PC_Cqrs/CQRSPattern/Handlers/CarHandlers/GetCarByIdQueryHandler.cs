using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Queries.CarQueries;
using _10PC_Cqrs.CQRSPattern.Results.CarResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly CqrsContext _context;

        public GetCarByIdQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _context.Cars.AsNoTracking().FirstOrDefaultAsync(x => x.CarId == query.Id);

            return new GetCarByIdQueryResult
            {
                CarId = value.CarId,
                Year = value.Year,
                Transmission = value.Transmission,
                Seat = value.Seat,
                Review = value.Review,
                PriceByDay = value.PriceByDay,
                Petrol = value.Petrol,
                Model = value.Model,
                Km = value.Km,
                ImageUrl = value.ImageUrl,
                Gear = value.Gear,
                Brand = value.Brand
            };
        }
    }
}
