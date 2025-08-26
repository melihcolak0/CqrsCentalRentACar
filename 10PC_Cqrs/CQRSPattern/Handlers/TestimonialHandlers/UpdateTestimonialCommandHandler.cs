using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.TestimonialCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler
    {
        private readonly CqrsContext _context;

        public UpdateTestimonialCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateTestimonialCommand command)
        {
            var value = await _context.Testimonials.FindAsync(command.TestimonialId);

            value.NameSurname = command.NameSurname;
            value.Comment = command.Comment;
            value.Star = command.Star;
            value.Profession = command.Profession;
            value.ImageUrl = command.ImageUrl;

            await _context.SaveChangesAsync();
        }
    }
}
