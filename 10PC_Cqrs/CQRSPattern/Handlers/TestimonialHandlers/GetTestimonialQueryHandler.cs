using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.TestimonialResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler
    {
        private readonly CqrsContext _context;

        public GetTestimonialQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle()
        {
            var values = await _context.Testimonials.AsNoTracking().ToListAsync();

            return values.Select(x => new GetTestimonialQueryResult
            {
                TestimonialId = x.TestimonialId,
                NameSurname = x.NameSurname,
                ImageUrl = x.ImageUrl,
                Comment = x.Comment,
                Profession = x.Profession,
                Star = x.Star
            }).ToList();
        }
    }
}
