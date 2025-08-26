using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Queries.LocationQueries;
using _10PC_Cqrs.CQRSPattern.Results.LocationResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler
    {
        private readonly CqrsContext _context;

        public GetLocationByIdQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery query)
        {
            var value = await _context.Locations.AsNoTracking().FirstOrDefaultAsync(x => x.LocationId == query.Id);

            return new GetLocationByIdQueryResult
            {
                LocationId = value.LocationId,
                Longitude = value.Longitude,
                Latitude = value.Latitude,
                Country = value.Country,
                City = value.City,
                AreaCode = value.AreaCode,
                AirportName = value.AirportName,
                AirportId = value.AirportId,
                AirportCode = value.AirportCode                
            };
        }
    }
}
