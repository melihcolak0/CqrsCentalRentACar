using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.BookingResults;
using Microsoft.EntityFrameworkCore;
using System;

namespace _10PC_Cqrs.CQRSPattern.Handlers.BookingHandlers
{
    public class GetRecentBookingsQueryHandler
    {
        private readonly CqrsContext _context;

        public GetRecentBookingsQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetRecentBookingsQueryResult> Handle()
        {
            var weekAgo = DateTime.Today.AddDays(-7);
            var recentCount = await _context.Bookings
                .CountAsync(b => b.PickUpDate >= weekAgo && b.PickUpDate <= DateTime.Today);

            return new GetRecentBookingsQueryResult { RecentBookingsCount = recentCount };
        }
    }
}
