using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.FeatureCommands;
using _10PC_Cqrs.Entities;

namespace _10PC_Cqrs.CQRSPattern.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler
    {
        private readonly CqrsContext _context;

        public CreateFeatureCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateFeatureCommand command)
        {
            _context.Features.Add(new Feature
            {
                Description = command.Description,
                Title = command.Title,
                IconUrl = command.IconUrl
            });

            await _context.SaveChangesAsync();
        }
    }
}
