using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.SliderCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.SliderHandlers
{
    public class RemoveSliderCommandHandler
    {
        private readonly CqrsContext _context;

        public RemoveSliderCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveSliderCommand command)
        {
            var value = await _context.Sliders.FindAsync(command.Id);

            _context.Sliders.Remove(value);

            await _context.SaveChangesAsync();
        }
    }
}
