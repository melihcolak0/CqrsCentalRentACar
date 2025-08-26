using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.LocationResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler
    {
        private readonly CqrsContext _context;

        public GetLocationQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<List<GetLocationQueryResult>> Handle()
        {
            var values = await _context.Locations.AsNoTracking().ToListAsync();

            return values.Select(x => new GetLocationQueryResult
            {
                LocationId = x.LocationId,
                AirportCode = x.AirportCode,
                AirportId = x.AirportId,
                AirportName = x.AirportName,
                AreaCode = x.AreaCode,
                City = x.City,
                Country = x.Country,
                Latitude = x.Latitude,
                Longitude = x.Longitude               
            }).ToList();
        }
    }
}
