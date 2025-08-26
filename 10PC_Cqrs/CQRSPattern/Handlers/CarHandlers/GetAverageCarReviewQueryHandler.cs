using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Results.CarResults;
using Microsoft.EntityFrameworkCore;
using System;

namespace _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers
{
    public class GetAverageCarReviewQueryHandler
    {
        private readonly CqrsContext _context;

        public GetAverageCarReviewQueryHandler(CqrsContext context)
        {
            _context = context;
        }

        public async Task<GetAverageCarReviewQueryResult> Handle()
        {
            var avg = await _context.Cars.AverageAsync(c => c.Review);
            return new GetAverageCarReviewQueryResult { AverageReview = avg };
        }
    }
}
