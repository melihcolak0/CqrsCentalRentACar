using _10PC_Cqrs.CQRSPattern.Commands.ServiceCommands;
using _10PC_Cqrs.CQRSPattern.Handlers.ServiceHandlers;
using _10PC_Cqrs.CQRSPattern.Queries.ServiceQueries;
using Microsoft.AspNetCore.Mvc;

namespace _10PC_Cqrs.Controllers
{
    public class ServiceController : Controller
    {
        private readonly GetServiceQueryHandler _getServiceQueryHandler;
        private readonly GetServiceByIdQueryHandler _getServiceByIdQueryHandler;
        private readonly CreateServiceCommandHandler _createServiceCommandHandler;
        private readonly UpdateServiceCommandHandler _updateServiceCommandHandler;
        private readonly RemoveServiceCommandHandler _removeServiceCommandHandler;

        public ServiceController(GetServiceQueryHandler getServiceQueryHandler, GetServiceByIdQueryHandler getServiceByIdQueryHandler, CreateServiceCommandHandler createServiceCommandHandler, UpdateServiceCommandHandler updateServiceCommandHandler, RemoveServiceCommandHandler removeServiceCommandHandler)
        {
            _getServiceQueryHandler = getServiceQueryHandler;
            _getServiceByIdQueryHandler = getServiceByIdQueryHandler;
            _createServiceCommandHandler = createServiceCommandHandler;
            _updateServiceCommandHandler = updateServiceCommandHandler;
            _removeServiceCommandHandler = removeServiceCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getServiceQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await _createServiceCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            await _removeServiceCommandHandler.Handle(new RemoveServiceCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var values = await _getServiceByIdQueryHandler.Handle(new GetServiceByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await _updateServiceCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
