using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.LocationCommands;
using _10PC_Cqrs.Entities;

namespace _10PC_Cqrs.CQRSPattern.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler
    {
        private readonly CqrsContext _context;

        public CreateLocationCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateLocationCommand command)
        {
            _context.Locations.Add(new Location
            {
                AirportCode = command.AirportCode,
                AirportId = command.AirportId,
                AirportName = command.AirportName,
                AreaCode = command.AreaCode,
                City = command.City,
                Country = command.Country,
                Latitude = command.Latitude,
                Longitude = command.Longitude           
            });

            await _context.SaveChangesAsync();
        }
    }
}
