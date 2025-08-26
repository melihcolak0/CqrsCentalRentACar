using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.ServiceCommands;
using _10PC_Cqrs.Entities;

namespace _10PC_Cqrs.CQRSPattern.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler
    {
        private readonly CqrsContext _context;

        public CreateServiceCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateServiceCommand command)
        {
            _context.Services.Add(new Service
            {
                Description = command.Description,
                IconUrl = command.IconUrl,
                Title = command.Title
            });

            await _context.SaveChangesAsync();
        }
    }
}
