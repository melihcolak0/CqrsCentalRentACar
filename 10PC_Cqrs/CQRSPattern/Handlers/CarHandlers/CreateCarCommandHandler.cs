using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Commands.CarCommands;
using _10PC_Cqrs.Entities;

namespace _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly CqrsContext _context;

        public CreateCarCommandHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCarCommand command)
        {
            _context.Cars.Add(new Car
            {
                Brand = command.Brand,
                Gear = command.Gear,
                ImageUrl = command.ImageUrl,
                Km = command.Km,
                Model = command.Model,
                Petrol = command.Petrol,
                PriceByDay = command.PriceByDay,
                Review = command.Review,
                Seat = command.Seat,
                Transmission = command.Transmission,
                Year = command.Year       
            });

            await _context.SaveChangesAsync();
        }
    }
}
