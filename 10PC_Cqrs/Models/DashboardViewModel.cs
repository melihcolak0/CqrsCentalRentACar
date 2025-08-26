namespace _10PC_Cqrs.Models
{
    public class DashboardViewModel
    {
        public RapidAPIFuelPriceViewModel FuelPrices { get; set; }
        public CarModelDashboardViewModel CarTypeChart { get; set; }
        public CarBrandAveragePriceChartViewModel BrandAveragePriceChart { get; set; }
        public List<DashboardList10BookingsViewModel> Last10Bookings { get; set; }
    }
}
