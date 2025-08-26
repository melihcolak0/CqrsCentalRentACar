using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.SliderResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.SliderHandlers
{
    public class GetSliderQueryHandler
    {
        private readonly CqrsContext _context;

        public GetSliderQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<List<GetSliderQueryResult>> Handle()
        {
            var values = await _context.Sliders.AsNoTracking().ToListAsync();

            return values.Select(x => new GetSliderQueryResult
            {
                SliderId = x.SliderId,               
                Title = x.Title,
                ImageUrl = x.ImageUrl,
                SubTitle = x.SubTitle,
                CarouselClass = x.CarouselClass
                
            }).ToList();
        }
    }
}
