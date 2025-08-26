using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.ServiceCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler
    {
        private readonly CqrsContext _context;

        public UpdateServiceCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateServiceCommand command)
        {
            var value = await _context.Services.FindAsync(command.ServiceId);

            value.Description = command.Description;
            value.Title = command.Title;
            value.IconUrl = command.IconUrl;

            await _context.SaveChangesAsync();
        }
    }
}
