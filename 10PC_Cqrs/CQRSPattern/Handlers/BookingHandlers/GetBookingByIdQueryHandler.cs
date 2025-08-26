using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Queries.BookingQueries;
using _10PC_Cqrs.CQRSPattern.Results.BookingResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.BookingHandlers
{
    public class GetBookingByIdQueryHandler
    {
        private readonly CqrsContext _context;

        public GetBookingByIdQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetBookingByIdQueryResult> Handle(GetBookingByIdQuery query)
        {
            var value = await _context.Bookings.Include(x => x.Car).AsNoTracking().FirstOrDefaultAsync(x => x.BookingId == query.Id);

            return new GetBookingByIdQueryResult
            {
                BookingId = value.BookingId,
                PickUpAirport = value.PickUpAirport,
                DropOffAirport = value.DropOffAirport,
                PickUpDate = value.PickUpDate,
                DropOffDate = value.PickUpDate,
                CarId = value.CarId,
                CarModel = value.Car.Model,
                CarBrand = value.Car.Brand
            };
        }
    }
}
