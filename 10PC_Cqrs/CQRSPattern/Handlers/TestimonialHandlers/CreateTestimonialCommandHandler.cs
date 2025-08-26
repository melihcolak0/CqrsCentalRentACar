using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.TestimonialCommands;
using _10PC_Cqrs.Entities;

namespace _10PC_Cqrs.CQRSPattern.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler
    {
        private readonly CqrsContext _context;

        public CreateTestimonialCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateTestimonialCommand command)
        {
            _context.Testimonials.Add(new Testimonial
            {
                NameSurname = command.NameSurname,
                ImageUrl = command.ImageUrl,
                Profession = command.Profession,
                Comment = command.Comment,
                Star = command.Star               
            });

            await _context.SaveChangesAsync();
        }
    }
}
