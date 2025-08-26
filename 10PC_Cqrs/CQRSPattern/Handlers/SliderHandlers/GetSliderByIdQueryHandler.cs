using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Queries.SliderQueries;
using _10PC_Cqrs.CQRSPattern.Results.SliderResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.SliderHandlers
{
    public class GetSliderByIdQueryHandler
    {
        private readonly CqrsContext _context;

        public GetSliderByIdQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetSliderByIdQueryResult> Handle(GetSliderByIdQuery query)
        {
            var value = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(x => x.SliderId == query.Id);

            return new GetSliderByIdQueryResult
            {
                SliderId = value.SliderId,                
                Title = value.Title,
                SubTitle = value.SubTitle,
                ImageUrl = value.ImageUrl,
                CarouselClass = value.CarouselClass
            };
        }
    }
}
