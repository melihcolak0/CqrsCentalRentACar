using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.LocationCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler
    {
        private readonly CqrsContext _context;

        public RemoveLocationCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveLocationCommand command)
        {
            var value = await _context.Locations.FindAsync(command.Id);

            _context.Locations.Remove(value);

            await _context.SaveChangesAsync();
        }
    }
}
