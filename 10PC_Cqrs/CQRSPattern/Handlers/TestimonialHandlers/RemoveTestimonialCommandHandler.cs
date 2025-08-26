using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.TestimonialCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler
    {
        private readonly CqrsContext _context;

        public RemoveTestimonialCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveTestimonialCommand command)
        {
            var value = await _context.Testimonials.FindAsync(command.Id);

            _context.Testimonials.Remove(value);

            await _context.SaveChangesAsync();
        }
    }
}
