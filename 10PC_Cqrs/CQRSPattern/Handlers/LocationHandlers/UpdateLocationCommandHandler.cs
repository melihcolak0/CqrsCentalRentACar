using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.LocationCommands;

namespace _10PC_Cqrs.CQRSPattern.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler
    {
        private readonly CqrsContext _context;

        public UpdateLocationCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateLocationCommand command)
        {
            var value = await _context.Locations.FindAsync(command.LocationId);

            value.AirportId = command.AirportId;
            value.AirportName = command.AirportName;
            value.Longitude = command.Longitude;
            value.Latitude = command.Latitude;
            value.AirportCode = command.AirportCode;
            value.AreaCode = command.AreaCode;
            value.City = command.City;
            value.Country = command.Country;

            await _context.SaveChangesAsync();
        }
    }
}
