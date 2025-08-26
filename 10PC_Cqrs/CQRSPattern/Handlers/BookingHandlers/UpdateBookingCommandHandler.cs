using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.BookingCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.BookingHandlers
{
    public class UpdateBookingCommandHandler
    {
        private readonly CqrsContext _context;

        public UpdateBookingCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateBookingCommand command)
        {
            var value = await _context.Bookings.FindAsync(command.BookingId);

            value.PickUpAirport = command.PickUpAirport;
            value.DropOffAirport = command.DropOffAirport;
            value.PickUpDate = command.PickUpDate;
            value.DropOffDate = command.DropOffDate;
            value.CarId = command.CarId;

            await _context.SaveChangesAsync();
        }
    }
}
