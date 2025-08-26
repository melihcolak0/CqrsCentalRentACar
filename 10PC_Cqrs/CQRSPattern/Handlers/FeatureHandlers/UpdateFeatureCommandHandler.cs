using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.FeatureCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler
    {
        private readonly CqrsContext _context;

        public UpdateFeatureCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateFeatureCommand command)
        {
            var value = await _context.Features.FindAsync(command.FeatureId);

            value.Description = command.Description;
            value.Title = command.Title;
            value.IconUrl = command.IconUrl;

            await _context.SaveChangesAsync();
        }
    }
}
