using _10PC_Cqrs.CQRSPattern.Commands.SliderCommands;
using _10PC_Cqrs.CQRSPattern.Handlers.SliderHandlers;
using _10PC_Cqrs.CQRSPattern.Queries.SliderQueries;
using Microsoft.AspNetCore.Mvc;

namespace _10PC_Cqrs.Controllers
{
    public class SliderController : Controller
    {
        private readonly GetSliderQueryHandler _getSliderQueryHandler;
        private readonly GetSliderByIdQueryHandler _getSliderByIdQueryHandler;
        private readonly CreateSliderCommandHandler _createSliderCommandHandler;
        private readonly UpdateSliderCommandHandler _updateSliderCommandHandler;
        private readonly RemoveSliderCommandHandler _removeSliderCommandHandler;

        public SliderController(GetSliderQueryHandler getSliderQueryHandler, GetSliderByIdQueryHandler getSliderByIdQueryHandler, CreateSliderCommandHandler createSliderCommandHandler, UpdateSliderCommandHandler updateSliderCommandHandler, RemoveSliderCommandHandler removeSliderCommandHandler)
        {
            _getSliderQueryHandler = getSliderQueryHandler;
            _getSliderByIdQueryHandler = getSliderByIdQueryHandler;
            _createSliderCommandHandler = createSliderCommandHandler;
            _updateSliderCommandHandler = updateSliderCommandHandler;
            _removeSliderCommandHandler = removeSliderCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getSliderQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderCommand command)
        {
            await _createSliderCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _removeSliderCommandHandler.Handle(new RemoveSliderCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var values = await _getSliderByIdQueryHandler.Handle(new GetSliderByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderCommand command)
        {
            await _updateSliderCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
