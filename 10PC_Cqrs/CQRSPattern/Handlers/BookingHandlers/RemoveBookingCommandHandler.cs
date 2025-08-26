using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.BookingCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.BookingHandlers
{
    public class RemoveBookingCommandHandler
    {
        private readonly CqrsContext _context;

        public RemoveBookingCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveBookingCommand command)
        {
            var value = await _context.Bookings.FindAsync(command.Id);

            _context.Bookings.Remove(value);

            await _context.SaveChangesAsync();
        }
    }
}
