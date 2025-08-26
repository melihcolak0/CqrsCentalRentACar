using _10PC_Cqrs.AIImplementation;
using _10PC_Cqrs.CQRSPattern.Commands.LocationCommands;
using _10PC_Cqrs.CQRSPattern.Handlers.LocationHandlers;
using _10PC_Cqrs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _10PC_Cqrs.Controllers
{
    public class AIController : Controller
    {
        private readonly HelsinkiNPLTranslation _helsinkiNPLTranslation;
        private readonly DeepSeekChatService _deepSeekChatService;
        private readonly RapidAPIAirportsService _rapidAPIAirportsService;
        private readonly CreateLocationCommandHandler _createLocationCommandHandler;

        public AIController(HelsinkiNPLTranslation helsinkiNPLTranslation, DeepSeekChatService deepSeekChatService, RapidAPIAirportsService rapidAPIAirportsService, CreateLocationCommandHandler createLocationCommandHandler)
        {
            _helsinkiNPLTranslation = helsinkiNPLTranslation;
            _deepSeekChatService = deepSeekChatService;
            _rapidAPIAirportsService = rapidAPIAirportsService;
            _createLocationCommandHandler = createLocationCommandHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(HelsinkiNPLViewModel model)
        {
            ModelState.Clear();

            model.Answer = await _helsinkiNPLTranslation.TranslateAsync(model.Prompt);

            return View(model);
        }

        [HttpGet]
        public IActionResult DeepSeekChat()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeepSeekChat(DeepSeekChatViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Prompt))
            {
                var result = await _deepSeekChatService.GetResponseAsync(model.Prompt);
                ModelState.Clear();
                model.Answer = result;
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ListAirports()
        {
            var airports = await _rapidAPIAirportsService.GetAirportsAsync();
            return View(airports);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAirportsToDb()
        {
            var airports = await _rapidAPIAirportsService.GetAirportsAsync();

            var commands = airports.Select(a => new CreateLocationCommand
            {
                AirportId = a.Id,
                AirportName = a.Airport_Name,
                AreaCode = a.Area_Code,
                AirportCode = a.Airport_Code,
                City = a.City,
                Country = a.Country_Alpha2,
                Latitude = a.Latitude,
                Longitude = a.Longitude
            }).ToList();

            foreach (var command in commands)
            {
                await _createLocationCommandHandler.Handle(command);
            }

            TempData["msg"] = "Havalimanları başarıyla kaydedildi!";
            return RedirectToAction("ListAirports");
        }

        // ChatGPT ChatBot
        [HttpGet]
        public IActionResult ChatBot()
        {
            return View(new RapidAPIChatBotViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> ChatBot(RapidAPIChatBotViewModel model, [FromServices] RapidAPIChatBotService chatService)
        {
            if (!string.IsNullOrWhiteSpace(model.Prompt))
            {
                ModelState.Clear();
                model.Answer = await chatService.GetAnswerAsync(model.Prompt);
            }
            return View(model);
        }
               
        // Gemini ChatBot
        [HttpGet]
        public IActionResult ChatBotWGemini()
        {
            return View(new GeminiChatBotViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> ChatBotWGemini(GeminiChatBotViewModel model, [FromServices] GeminiChatBotService chatService)
        {
            if (!string.IsNullOrWhiteSpace(model.Prompt))
            {
                ModelState.Clear();
                model.Answer = await chatService.GetAnswerAsync(model.Prompt);
            }

            return View(model);
        }
    }
}
