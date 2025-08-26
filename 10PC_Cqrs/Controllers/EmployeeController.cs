using _10PC_Cqrs.CQRSPattern.Commands.EmployeeCommands;
using _10PC_Cqrs.CQRSPattern.Handlers.EmployeeHandlers;
using _10PC_Cqrs.CQRSPattern.Queries.EmployeeQueries;
using Microsoft.AspNetCore.Mvc;

namespace _10PC_Cqrs.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly GetEmployeeQueryHandler _getEmployeeQueryHandler;
        private readonly GetEmployeeByIdQueryHandler _getEmployeeByIdQueryHandler;
        private readonly CreateEmployeeCommandHandler _createEmployeeCommandHandler;
        private readonly UpdateEmployeeCommandHandler _updateEmployeeCommandHandler;
        private readonly RemoveEmployeeCommandHandler _removeEmployeeCommandHandler;

        public EmployeeController(GetEmployeeQueryHandler getEmployeeQueryHandler, GetEmployeeByIdQueryHandler getEmployeeByIdQueryHandler, CreateEmployeeCommandHandler createEmployeeCommandHandler, UpdateEmployeeCommandHandler updateEmployeeCommandHandler, RemoveEmployeeCommandHandler removeEmployeeCommandHandler)
        {
            _getEmployeeQueryHandler = getEmployeeQueryHandler;
            _getEmployeeByIdQueryHandler = getEmployeeByIdQueryHandler;
            _createEmployeeCommandHandler = createEmployeeCommandHandler;
            _updateEmployeeCommandHandler = updateEmployeeCommandHandler;
            _removeEmployeeCommandHandler = removeEmployeeCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getEmployeeQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand command)
        {
            await _createEmployeeCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _removeEmployeeCommandHandler.Handle(new RemoveEmployeeCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var values = await _getEmployeeByIdQueryHandler.Handle(new GetEmployeeByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeCommand command)
        {
            await _updateEmployeeCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
