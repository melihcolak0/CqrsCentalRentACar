using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.BookingResults;
using Microsoft.EntityFrameworkCore;

namespace _10PC_Cqrs.CQRSPattern.Handlers.BookingHandlers
{
    public class GetTotalBookingsQueryHandler
    {
        private readonly CqrsContext _context;

        public GetTotalBookingsQueryHandler(CqrsContext context)
        {
            _context = context;
        }
        
        public async Task<GetTotalBookingsQueryResult> Handle()
        {
            var totalCount = await _context.Bookings.CountAsync();

            return new GetTotalBookingsQueryResult
            {
                TotalBookingsCount = totalCount
            };
        }
    }
}
