using _10PC_Cqrs.AIImplementation;
using _10PC_Cqrs.CQRSPattern.Handlers.BookingHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers;
using _10PC_Cqrs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.Json;

namespace _10PC_Cqrs.Controllers
{
    public class DashboardController : Controller
    {        
        private readonly RapidAPIFuelPrice _fuelPriceService;
        private readonly GetCarModelCountQueryHandler _getCarModelCountQueryHandler;
        private readonly GetCarBrandAveragePriceQueryHandler _getCarBrandAveragePriceQueryHandler;
        private readonly GetLast10BookingsQueryHandler _getLast10BookingsQueryHandler;

        public DashboardController(RapidAPIFuelPrice fuelPriceService, GetCarModelCountQueryHandler getCarModelCountQueryHandler, GetCarBrandAveragePriceQueryHandler getCarBrandAveragePriceQueryHandler, GetLast10BookingsQueryHandler getLast10BookingsQueryHandler)
        {
            _fuelPriceService = fuelPriceService;
            _getCarModelCountQueryHandler = getCarModelCountQueryHandler;
            _getCarBrandAveragePriceQueryHandler = getCarBrandAveragePriceQueryHandler;
            _getLast10BookingsQueryHandler = getLast10BookingsQueryHandler;
        }

        public async Task<IActionResult> Index()
        {
            //----- Yakıt fiyatları -----
            //var fuelModel = await _fuelPriceService.GetFuelPricesAsync();

            var fuelModel = new RapidAPIFuelPriceViewModel()
            {
                dieselTL = "50",
                gasolineTL = "51",
                lpgTL = "25"
            };
            //--------------------------------------------

            //----- Kasa Tipine Göre Araba Sayısı -----
            var result = _getCarModelCountQueryHandler.Handle();

            var carChartModel = new CarModelDashboardViewModel
            {
                Labels = result.Select(r => r.Model).ToList(),
                Counts = result.Select(r => r.Count).ToList()
            };
            //--------------------------------------------

            //----- Marka'ya Göre Ortalama Fiyat -----
            var result2 = _getCarBrandAveragePriceQueryHandler.Handle();

            var chartModel = new CarBrandAveragePriceChartViewModel
            {
                Labels = result2.Select(r => r.Brand).ToList(),
                AveragePrices = result2.Select(r => r.AveragePrice).ToList()
            };
            //--------------------------------------------

            //----- Son 10 Rezervasyon -----

            var last10BookingsResult = await _getLast10BookingsQueryHandler.Handle();

            var last10Bookings = last10BookingsResult.Select(x => new DashboardList10BookingsViewModel
            {
                BookingId = x.BookingId,
                PickUpAirport = x.PickUpAirport,
                DropOffAirport = x.DropOffAirport,
                PickUpDate = x.PickUpDate,
                DropOffDate = x.DropOffDate,
                CarId = x.CarId,
                CarBrand = x.CarBrand,
                CarModel = x.CarModel
            }).ToList();
            //--------------------------------------------

            // Ana model
            var vm = new DashboardViewModel
            {
                FuelPrices = fuelModel,
                CarTypeChart = carChartModel,
                BrandAveragePriceChart = chartModel,
                Last10Bookings = last10Bookings
            };

            return View(vm);
        }     
    }
}
