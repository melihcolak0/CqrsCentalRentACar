using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.CarCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly CqrsContext _context;

        public RemoveCarCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCarCommand command)
        {
            var value = await _context.Cars.FindAsync(command.Id);

            _context.Cars.Remove(value);

            await _context.SaveChangesAsync();
        }
    }
}
