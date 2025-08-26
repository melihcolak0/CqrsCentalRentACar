using _10PC_Cqrs.AIImplementation;
using _10PC_Cqrs.CQRSPattern.Commands.BookingCommands;
using _10PC_Cqrs.CQRSPattern.Commands.MessageCommands;
using _10PC_Cqrs.CQRSPattern.Handlers.BookingHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.LocationHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.MessageHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.SliderHandlers;
using _10PC_Cqrs.CQRSPattern.Queries.CarQueries;
using _10PC_Cqrs.Entities;
using _10PC_Cqrs.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System.Globalization;
using System.Threading.Tasks;

namespace _10PC_Cqrs.Controllers
{
    public class DefaultController : Controller
    {
        private readonly CreateMessageCommandHandler _createMessageCommandHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetSliderQueryHandler _getSliderQueryHandler;
        private readonly GetBookingQueryHandler _getBookingQueryHandler;
        private readonly GetLocationQueryHandler _getLocationQueryHandler;
        private readonly CreateBookingCommandHandler _createBookingCommandHandler;
        private readonly RapidAPIDistanceAirportsService _rapidAPIDistanceAirportsService;
        private readonly RapidAPIFuelPrice _rapidAPIFuelPrice;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarFuelTypeByModelQueryHandler _getCarFuelTypeByModelQueryHandler;

        public DefaultController(CreateMessageCommandHandler createMessageCommandHandler, GetCarQueryHandler getCarQueryHandler, GetSliderQueryHandler getSliderQueryHandler, GetBookingQueryHandler getBookingQueryHandler, GetLocationQueryHandler getLocationQueryHandler, CreateBookingCommandHandler createBookingCommandHandler, RapidAPIDistanceAirportsService rapidAPIDistanceAirportsService, RapidAPIFuelPrice rapidAPIFuelPrice, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarFuelTypeByModelQueryHandler getCarFuelTypeByModelQueryHandler)
        {
            _createMessageCommandHandler = createMessageCommandHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _getSliderQueryHandler = getSliderQueryHandler;
            _getBookingQueryHandler = getBookingQueryHandler;
            _getLocationQueryHandler = getLocationQueryHandler;
            _createBookingCommandHandler = createBookingCommandHandler;
            _rapidAPIDistanceAirportsService = rapidAPIDistanceAirportsService;
            _rapidAPIFuelPrice = rapidAPIFuelPrice;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarFuelTypeByModelQueryHandler = getCarFuelTypeByModelQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sliders = await _getSliderQueryHandler.Handle();

            // Araç modellerini çek
            var allCars = await _getCarQueryHandler.Handle();
            var carModels = allCars
    .Select(c => $"{c.Brand} {c.Model}") // Marka ve modeli birleştir
    .Distinct()
    .ToList();

            // Lokasyonları çek
            var allLocations = await _getLocationQueryHandler.Handle();
            var pickUpLocations = allLocations.Select(l => l.AirportName).Distinct().ToList();
            var dropOffLocations = allLocations.Select(l => l.AirportName).Distinct().ToList();

            var model = new HomePageViewModel
            {
                Sliders = sliders,
                CarSearch = new SearchAvailableCarsViewModel(),
                Message = new CreateMessageCommand()
            };

            // ViewBag ile View'e gönder
            ViewBag.CarModels = carModels;
            ViewBag.PickUpLocations = pickUpLocations;
            ViewBag.DropOffLocations = dropOffLocations;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomePageViewModel model)
        {
            // PickUp ve DropOff aynıysa geri dön
            if (model.CarSearch.PickUpLocation == model.CarSearch.DropOffLocation)
            {
                TempData["ErrorMessage"] = "Alış ve teslim havalimanı aynı olamaz!";
                return RedirectToAction("Index");
            }

            var carSearch = model.CarSearch;

            return RedirectToAction("ListAvailableCars", new
            {
                carModel = carSearch.CarModel,
                pickUpLocation = carSearch.PickUpLocation,
                dropOffLocation = carSearch.DropOffLocation,
                startDate = carSearch.StartDate,
                endDate = carSearch.EndDate
            });
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        //[HttpPost]
        //public async Task<IActionResult> SendMessage(CreateMessageCommand command)
        //{
        //    await _createMessageCommandHandler.Handle(command);

        //    MimeMessage mimeMessage = new MimeMessage();

        //    MailboxAddress mailboxAddressFrom = new MailboxAddress("Cental Rent A Car", "projectsdotnet1@gmail.com");
        //    mimeMessage.From.Add(mailboxAddressFrom);

        //    MailboxAddress mailboxAddressTo = new MailboxAddress("User", command.Email);
        //    mimeMessage.To.Add(mailboxAddressTo);

        //    var bodyBuilder = new BodyBuilder();
        //    bodyBuilder.TextBody = "Merhaba, bu Cental Rent A Car firmasından gönderilen bir test mesajıdır.";
        //    mimeMessage.Body = bodyBuilder.ToMessageBody();
        //    mimeMessage.Subject = "Test Mesajı";

        //    SmtpClient client = new SmtpClient();
        //    client.Connect("smtp.gmail.com", 587, false);
        //    client.Authenticate("projectsdotnet1@gmail.com", "mcgr hwum ntkb qenl");

        //    client.Send(mimeMessage);
        //    client.Disconnect(true);

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageCommand command, [FromServices] RapidAPIChatBotService chatService)
        {            
            await _createMessageCommandHandler.Handle(command);
                        
            string prompt = $"Sen bir araç kiralama şirketi adına profesyonel müşteri temsilcisi gibi cevap yazacaksın. Sana müşteri tarafından Bize Ulaşın bölümünden gelen mesaj verilecek. Sadece resmi mail içeriği oluştur. Şirketimin adı Cental Rent A Car. Mesaj: {command.MessageDetail}";

            string aiResponse = await chatService.GetAnswerAsync(prompt);

            MimeMessage mimeMessage = new MimeMessage();

            var senderNameSurname = command.Name + " " + command.Surname;

            MailboxAddress mailboxAddressFrom = new MailboxAddress(senderNameSurname, "projectsdotnet1@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", command.Email);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = aiResponse;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Cental Rent A Car - Yanıt";

            using (SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("projectsdotnet1@gmail.com", "mcgr hwum ntkb qenl");
                client.Send(mimeMessage);
                client.Disconnect(true);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> ListAvailableCars(string carModel, string pickUpLocation, string dropOffLocation, DateTime startDate, DateTime endDate)
        {
            ViewBag.CarModel = carModel;
            ViewBag.PickUpLocation = pickUpLocation;
            ViewBag.DropOffLocation = dropOffLocation;
            ViewBag.StartDate = startDate.ToString("dd MMM yyyy");
            ViewBag.EndDate = endDate.ToString("dd MMM yyyy");

            
            var allCars = await _getCarQueryHandler.Handle();
            var allBookings = await _getBookingQueryHandler.Handle();


            var availableCars = allCars.Where(car =>
            (string.IsNullOrEmpty(carModel) || $"{car.Brand} {car.Model}" == carModel) &&
            !allBookings.Any(b =>
                b.CarId == car.CarId &&
                    (
                        (startDate >= b.PickUpDate && startDate < b.DropOffDate) ||
                        (endDate > b.PickUpDate && endDate <= b.DropOffDate) ||
                        (startDate <= b.PickUpDate && endDate >= b.DropOffDate)
                    )
                )
            ).ToList();

            var model = new SearchAvailableCarsViewModel
            {
                CarModel = carModel,
                PickUpLocation = pickUpLocation,
                DropOffLocation = dropOffLocation,
                StartDate = startDate,
                EndDate = endDate,
                AvailableCars = availableCars
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ListAvailableCars(SearchAvailableCarsViewModel  model) // Rezervayon yapılır.
        {
            if (model.SelectedCarId == 0)
            {
                // Araç seçilmediyse hata verelim
                ModelState.AddModelError("", "Lütfen bir araç seçiniz.");
                return View(model);
            }

            // Booking nesnesi oluştur
            var booking = new Booking
            {
                CarId = model.SelectedCarId,
                PickUpAirport = model.PickUpLocation,
                DropOffAirport = model.DropOffLocation,
                PickUpDate = model.StartDate,
                DropOffDate = model.EndDate
            };

            // booking kaydını DB’ye ekle
            await _createBookingCommandHandler.Handle(new CreateBookingCommand
            {
                CarId = booking.CarId,
                PickUpAirport = booking.PickUpAirport,
                DropOffAirport = booking.DropOffAirport,
                PickUpDate = booking.PickUpDate,
                DropOffDate = booking.DropOffDate
            });

            TempData["Success"] = "Rezervasyon başarıyla oluşturuldu!";

            return RedirectToAction("Index");
        }        

        [HttpGet]
        public async Task<IActionResult> GetDistanceByName(string pickUpName, string dropOffName, string carModel)
        {
            if (pickUpName == dropOffName)
                return Json(new { error = "Alış ve Teslim havaalanı aynı olamaz!" });

            // 1️⃣ Mesafeyi bul
            var allLocations = await _getLocationQueryHandler.Handle();
            var pickUpIata = allLocations.FirstOrDefault(l => l.AirportName == pickUpName)?.AreaCode;
            var dropOffIata = allLocations.FirstOrDefault(l => l.AirportName == dropOffName)?.AreaCode;

            if (pickUpIata == null || dropOffIata == null)
                return Json(new { error = "Havalimanı kodları bulunamadı!" });

            var distanceResult = await _rapidAPIDistanceAirportsService.GetDistanceAsync(pickUpIata, dropOffIata);
            if (distanceResult?.Status != "ok" || distanceResult.Data == null)
                return Json(new { error = distanceResult?.Error ?? "Mesafe hesaplanamadı" });

            double distanceKm = distanceResult.Data.DistanceKm;

            // 2️⃣ Aracın yakıt tipini bul
            var carFuelResult = await _getCarFuelTypeByModelQueryHandler.Handle(new GetCarFuelTypeByModelQuery(carModel));
            if (carFuelResult == null)
                return Json(new { error = "Araç bulunamadı!" });

            string fuelType = carFuelResult.FuelType; // Örn: "Benzin", "Dizel", "LPG", "Elektrik", "Hybrid"

            // 3️⃣ Yakıt birim fiyatı
            var fuelPrices = await _rapidAPIFuelPrice.GetFuelPricesAsync();
            double fuelUnitPrice = fuelType switch
            {
                "Benzin" => double.Parse(fuelPrices.gasolineTL.Replace(" ₺", "").Replace(',', '.'), CultureInfo.InvariantCulture),
                "Dizel" => double.Parse(fuelPrices.dieselTL.Replace(" ₺", "").Replace(',', '.'), CultureInfo.InvariantCulture),
                "LPG" => double.Parse(fuelPrices.lpgTL.Replace(" ₺", "").Replace(',', '.'), CultureInfo.InvariantCulture),
                "Elektrik" => 0.69,  // TL/km kabul ettim
                "Hybrid" => 1.53,  // TL/km kabul ettim
                _ => -1
            };

            if (fuelUnitPrice < 0)
                return Json(new { error = "Bilinmeyen yakıt türü!" });

            // 4️⃣ 100 km maliyeti
            double costPer100Km;

            // Benzin, Dizel, LPG → litre tüketimi sabit (ör: 6 lt/100 km)
            double averageConsumptionPer100Km = 6.0; // DB’den alabilirsin
            if (fuelType == "Benzin" || fuelType == "Dizel" || fuelType == "LPG")
            {
                costPer100Km = averageConsumptionPer100Km * fuelUnitPrice;
            }
            else
            {
                // Elektrik & Hybrid → zaten TL/km üzerinden
                costPer100Km = fuelUnitPrice * 100;
            }

            // 5️⃣ Toplam maliyet
            double totalFuelCost = (distanceKm / 100) * costPer100Km;

            return Json(new
            {
                distance = distanceKm,
                fuelType = fuelType,
                fuelUnitPrice = fuelUnitPrice,
                costPer100Km = Math.Round(costPer100Km, 2),
                totalFuelCost = Math.Round(totalFuelCost, 2)
            });
        }

        [HttpGet]
        public IActionResult VehicleRecommendationAssistant()
        {
            return View(new GeminiChatBotViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> VehicleRecommendationAssistant(GeminiChatBotViewModel model, [FromServices] GeminiChatBotService chatService)
        {
            if (!string.IsNullOrWhiteSpace(model.Prompt))
            {
                ModelState.Clear();
                var prompt = "Sen bir Yapay Zeka Araç Öneri Asistanısın. Görevin, kullanıcının sorduğu soruya göre ona en arabaları önermek.\r\nKullanıcının sorduğu alanı analiz et\r\nKullanıcının ihtiyacını detaylıca özetle.\r\nArdından 3–5 mantıklı araç önerisi yap.\r\nHer aracın yanında kısa açıklama yaz: ne işe yarar, neden bu soruya uygun, güçlü yönü nedir.\r\nÖnerilerin güncel ve kullanışlı olsun.\r\nKullanıcı sadece tek bir soru soracak (örn: \" Ailemle hafta sonu tatiline çıkacağız, 5 kişilik geniş ve bagajı büyük bir araç önerebilir misiniz?\"). Sen de yukarıdaki kurallara göre cevap ver.\r\nGelen Soru:\r\n" +  model.Prompt;
                model.Answer = await chatService.GetAnswerAsync(prompt);
            }

            return View(model);
        }
    }
}
