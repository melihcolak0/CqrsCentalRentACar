using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Queries.TestimonialQueries;
using _10PC_Cqrs.CQRSPattern.Results.TestimonialResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler
    {
        private readonly CqrsContext _context;

        public GetTestimonialByIdQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery query)
        {
            var value = await _context.Testimonials.AsNoTracking().FirstOrDefaultAsync(x => x.TestimonialId == query.Id);

            return new GetTestimonialByIdQueryResult
            {
                TestimonialId = value.TestimonialId,
                NameSurname = value.NameSurname,
                Comment = value.Comment,
                Star = value.Star,
                Profession = value.Profession,
                ImageUrl = value.ImageUrl
            };
        }
    }
}
