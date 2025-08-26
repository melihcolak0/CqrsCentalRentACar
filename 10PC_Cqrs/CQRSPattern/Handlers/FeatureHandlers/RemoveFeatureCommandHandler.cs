using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.FeatureCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler
    {
        private readonly CqrsContext _context;

        public RemoveFeatureCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveFeatureCommand command)
        {
            var value = await _context.Features.FindAsync(command.Id);

            _context.Features.Remove(value);

            await _context.SaveChangesAsync();
        }
    }
}
