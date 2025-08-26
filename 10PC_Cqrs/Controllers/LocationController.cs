using _10PC_Cqrs.CQRSPattern.Commands.LocationCommands;
using _10PC_Cqrs.CQRSPattern.Handlers.LocationHandlers;
using _10PC_Cqrs.CQRSPattern.Queries.LocationQueries;
using Microsoft.AspNetCore.Mvc;

namespace _10PC_Cqrs.Controllers
{
    public class LocationController : Controller
    {
        private readonly GetLocationQueryHandler _getLocationQueryHandler;
        private readonly GetLocationByIdQueryHandler _getLocationByIdQueryHandler;
        private readonly CreateLocationCommandHandler _createLocationCommandHandler;
        private readonly UpdateLocationCommandHandler _updateLocationCommandHandler;
        private readonly RemoveLocationCommandHandler _removeLocationCommandHandler;

        public LocationController(GetLocationQueryHandler getLocationQueryHandler, GetLocationByIdQueryHandler getLocationByIdQueryHandler, CreateLocationCommandHandler createLocationCommandHandler, UpdateLocationCommandHandler updateLocationCommandHandler, RemoveLocationCommandHandler removeLocationCommandHandler)
        {
            _getLocationQueryHandler = getLocationQueryHandler;
            _getLocationByIdQueryHandler = getLocationByIdQueryHandler;
            _createLocationCommandHandler = createLocationCommandHandler;
            _updateLocationCommandHandler = updateLocationCommandHandler;
            _removeLocationCommandHandler = removeLocationCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getLocationQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _createLocationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _removeLocationCommandHandler.Handle(new RemoveLocationCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var values = await _getLocationByIdQueryHandler.Handle(new GetLocationByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _updateLocationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
