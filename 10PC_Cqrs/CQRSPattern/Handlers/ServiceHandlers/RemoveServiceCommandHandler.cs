using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.ServiceCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler
    {
        private readonly CqrsContext _context;

        public RemoveServiceCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveServiceCommand command)
        {
            var value = await _context.Services.FindAsync(command.Id);

            _context.Services.Remove(value);

            await _context.SaveChangesAsync();
        }
    }
}
