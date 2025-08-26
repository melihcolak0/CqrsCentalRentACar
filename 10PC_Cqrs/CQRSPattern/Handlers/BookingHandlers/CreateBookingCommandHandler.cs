using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.BookingCommands;
using _10PC_Cqrs.Entities;

namespace _10PC_Cqrs.CQRSPattern.Handlers.BookingHandlers
{
    public class CreateBookingCommandHandler
    {
        private readonly CqrsContext _context;

        public CreateBookingCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateBookingCommand command)
        {
            _context.Bookings.Add(new Booking
            {
                PickUpAirport = command.PickUpAirport,
                DropOffAirport = command.DropOffAirport,
                PickUpDate = command.PickUpDate,
                DropOffDate = command.DropOffDate,
                CarId = command.CarId,                
            });

            await _context.SaveChangesAsync();
        }
    }
}
