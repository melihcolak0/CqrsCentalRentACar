using _10PC_Cqrs.CQRSPattern.Commands.CarCommands;
using _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers;
using _10PC_Cqrs.CQRSPattern.Queries.CarQueries;
using Microsoft.AspNetCore.Mvc;

namespace _10PC_Cqrs.Controllers
{
    public class CarController : Controller
    {
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;

        public CarController(GetCarQueryHandler getCarQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler)
        {
            _getCarQueryHandler = getCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getCarQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var values = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
