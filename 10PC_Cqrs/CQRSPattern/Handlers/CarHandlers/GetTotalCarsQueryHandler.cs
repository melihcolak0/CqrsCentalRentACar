using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.CarResults;
using Microsoft.EntityFrameworkCore;
using System;

namespace _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers
{
    public class GetTotalCarsQueryHandler
    {
        private readonly CqrsContext _context;

        public GetTotalCarsQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetTotalCarsQueryResult> Handle()
        {
            var totalCount = await _context.Cars.CountAsync();
            return new GetTotalCarsQueryResult { TotalCarsCount = totalCount };
        }
    }
}
