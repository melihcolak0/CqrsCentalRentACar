using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.BookingResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.BookingHandlers
{
    public class GetLast10BookingsQueryHandler
    {
        private readonly CqrsContext _context;

        public GetLast10BookingsQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<List<GetBookingQueryResult>> Handle()
        {
            var values = await _context.Bookings.OrderByDescending(x => x.BookingId).Include(x => x.Car).AsNoTracking().ToListAsync();

            return values.Select(x => new GetBookingQueryResult
            {
                BookingId = x.BookingId,
                PickUpAirport = x.PickUpAirport,
                DropOffAirport = x.DropOffAirport,
                PickUpDate = x.PickUpDate,
                DropOffDate = x.DropOffDate,
                CarId = x.CarId,
                CarBrand = x.Car.Brand,
                CarModel = x.Car.Model
            }).Take(10).ToList();
        }
    }
}
