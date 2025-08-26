using _10PC_Cqrs.CQRSPattern.Commands.FeatureCommands;
using _10PC_Cqrs.CQRSPattern.Handlers.FeatureHandlers;
using _10PC_Cqrs.CQRSPattern.Queries.FeatureQueries;
using Microsoft.AspNetCore.Mvc;

namespace _10PC_Cqrs.Controllers
{
    public class FeatureController : Controller
    {
        private readonly GetFeatureQueryHandler _getFeatureQueryHandler;
        private readonly GetFeatureByIdQueryHandler _getFeatureByIdQueryHandler;
        private readonly CreateFeatureCommandHandler _createFeatureCommandHandler;
        private readonly UpdateFeatureCommandHandler _updateFeatureCommandHandler;
        private readonly RemoveFeatureCommandHandler _removeFeatureCommandHandler;

        public FeatureController(GetFeatureQueryHandler getFeatureQueryHandler, GetFeatureByIdQueryHandler getFeatureByIdQueryHandler, CreateFeatureCommandHandler createFeatureCommandHandler, UpdateFeatureCommandHandler updateFeatureCommandHandler, RemoveFeatureCommandHandler removeFeatureCommandHandler)
        {
            _getFeatureQueryHandler = getFeatureQueryHandler;
            _getFeatureByIdQueryHandler = getFeatureByIdQueryHandler;
            _createFeatureCommandHandler = createFeatureCommandHandler;
            _updateFeatureCommandHandler = updateFeatureCommandHandler;
            _removeFeatureCommandHandler = removeFeatureCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getFeatureQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await _createFeatureCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _removeFeatureCommandHandler.Handle(new RemoveFeatureCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var values = await _getFeatureByIdQueryHandler.Handle(new GetFeatureByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await _updateFeatureCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
