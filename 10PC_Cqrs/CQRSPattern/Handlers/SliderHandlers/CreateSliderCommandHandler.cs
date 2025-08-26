using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.SliderCommands;
using _10PC_Cqrs.Entities;

namespace _10PC_Cqrs.CQRSPattern.Handlers.SliderHandlers
{
    public class CreateSliderCommandHandler
    {
        private readonly CqrsContext _context;

        public CreateSliderCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateSliderCommand command)
        {
            _context.Sliders.Add(new Slider
            {
                SubTitle = command.Title,
                Title = command.Title,
                ImageUrl = command.ImageUrl,
                CarouselClass = command.CarouselClass                
            });

            await _context.SaveChangesAsync();
        }
    }
}
