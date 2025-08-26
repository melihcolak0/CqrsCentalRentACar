using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Queries.CarQueries;
using _10PC_Cqrs.CQRSPattern.Results.CarResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers
{
    public class GetCarFuelTypeByModelQueryHandler
    {
        private readonly CqrsContext _context;

        public GetCarFuelTypeByModelQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetCarFuelTypeByModelQueryResult> Handle(GetCarFuelTypeByModelQuery query)
        {
            var parts = query.Model.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
                return null; // yanlış formatta gelmişse

            var brand = parts[0];
            var model = parts[1];

            var car = await _context.Cars
                .Where(x => x.Brand == brand && x.Model == model)
                .Select(x => new GetCarFuelTypeByModelQueryResult
                {
                    Model = x.Model,
                    FuelType = x.Petrol
                })
                .FirstOrDefaultAsync();

            return car;
        }
    }
}
