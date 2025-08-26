using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.AboutCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly CqrsContext _context;

        public UpdateAboutCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateAboutCommand command)
        {
            var value = await _context.Abouts.FindAsync(command.AboutId);

            value.Description = command.Description;
            value.Mision = command.Mision;
            value.Vision = command.Vision;           

            await _context.SaveChangesAsync();
        }
    }
}
