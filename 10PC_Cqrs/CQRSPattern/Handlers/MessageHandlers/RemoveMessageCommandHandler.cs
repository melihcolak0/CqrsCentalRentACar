using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.MessageCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.MessageHandlers
{
    public class RemoveMessageCommandHandler
    {
        private readonly CqrsContext _context;

        public RemoveMessageCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveMessageCommand command)
        {
            var value = await _context.Messages.FindAsync(command.Id);

            _context.Messages.Remove(value);

            await _context.SaveChangesAsync();
        }
    }
}
