using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.AboutCommands;
using _10PC_Cqrs.Entities;

namespace _10PC_Cqrs.CQRSPattern.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly CqrsContext _context;

        public CreateAboutCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateAboutCommand command)
        {
            _context.Abouts.Add(new About
            {
                Description = command.Description,
                Mision = command.Mision,
                Vision = command.Vision
            });

            await _context.SaveChangesAsync();
        }
    }
}
