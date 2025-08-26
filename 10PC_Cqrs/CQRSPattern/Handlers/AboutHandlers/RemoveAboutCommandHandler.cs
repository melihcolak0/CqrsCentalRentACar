using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.AboutCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly CqrsContext _context;

        public RemoveAboutCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveAboutCommand command)
        {
            var value = await _context.Abouts.FindAsync(command.Id);

            _context.Abouts.Remove(value);

            await _context.SaveChangesAsync();
        }
    }
}
