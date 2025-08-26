
using _10PC_Cqrs.CQRSPattern.Handlers.BookingHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers;
using _10PC_Cqrs.Models;
using Microsoft.AspNetCore.Mvc;

namespace _10PC_Cqrs.ViewComponents
{
    public class _DefaultStatisticsComponent : ViewComponent
    {
        private readonly GetTotalBookingsQueryHandler _bookingsHandler;
        private readonly GetRecentBookingsQueryHandler _recentBookingsHandler;
        private readonly GetTotalCarsQueryHandler _carsHandler;
        private readonly GetAverageCarReviewQueryHandler _avgReviewHandler;

        public _DefaultStatisticsComponent(
            GetTotalBookingsQueryHandler bookingsHandler,
            GetRecentBookingsQueryHandler recentBookingsHandler,
            GetTotalCarsQueryHandler carsHandler,
            GetAverageCarReviewQueryHandler avgReviewHandler)
        {
            _bookingsHandler = bookingsHandler;
            _recentBookingsHandler = recentBookingsHandler;
            _carsHandler = carsHandler;
            _avgReviewHandler = avgReviewHandler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalBookings = await _bookingsHandler.Handle();
            var recentBookings = await _recentBookingsHandler.Handle();
            var totalCars = await _carsHandler.Handle();
            var averageReview = await _avgReviewHandler.Handle();

            var model = new DefaultStatisticsViewModel
            {
                TotalBookings = totalBookings.TotalBookingsCount,
                RecentBookings = recentBookings.RecentBookingsCount,
                TotalCars = totalCars.TotalCarsCount,
                AverageReview = averageReview.AverageReview
            };

            return View(model);
        }
    }
}
