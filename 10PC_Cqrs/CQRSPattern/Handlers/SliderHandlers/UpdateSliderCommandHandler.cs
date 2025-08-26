using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.SliderCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.SliderHandlers
{
    public class UpdateSliderCommandHandler
    {
        private readonly CqrsContext _context;

        public UpdateSliderCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateSliderCommand command)
        {
            var value = await _context.Sliders.FindAsync(command.SliderId);

            value.SubTitle = command.SubTitle;
            value.Title = command.Title;
            value.ImageUrl = command.ImageUrl;
            value.CarouselClass = command.CarouselClass;

            await _context.SaveChangesAsync();
        }
    }
}
