using _10PC_Cqrs.CQRSPattern.Commands.TestimonialCommands;
using _10PC_Cqrs.CQRSPattern.Handlers.TestimonialHandlers;
using _10PC_Cqrs.CQRSPattern.Queries.TestimonialQueries;
using Microsoft.AspNetCore.Mvc;

namespace _10PC_Cqrs.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly GetTestimonialQueryHandler _getTestimonialQueryHandler;
        private readonly GetTestimonialByIdQueryHandler _getTestimonialByIdQueryHandler;
        private readonly CreateTestimonialCommandHandler _createTestimonialCommandHandler;
        private readonly UpdateTestimonialCommandHandler _updateTestimonialCommandHandler;
        private readonly RemoveTestimonialCommandHandler _removeTestimonialCommandHandler;

        public TestimonialController(GetTestimonialQueryHandler getTestimonialQueryHandler, GetTestimonialByIdQueryHandler getTestimonialByIdQueryHandler, CreateTestimonialCommandHandler createTestimonialCommandHandler, UpdateTestimonialCommandHandler updateTestimonialCommandHandler, RemoveTestimonialCommandHandler removeTestimonialCommandHandler)
        {
            _getTestimonialQueryHandler = getTestimonialQueryHandler;
            _getTestimonialByIdQueryHandler = getTestimonialByIdQueryHandler;
            _createTestimonialCommandHandler = createTestimonialCommandHandler;
            _updateTestimonialCommandHandler = updateTestimonialCommandHandler;
            _removeTestimonialCommandHandler = removeTestimonialCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getTestimonialQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await _createTestimonialCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _removeTestimonialCommandHandler.Handle(new RemoveTestimonialCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var values = await _getTestimonialByIdQueryHandler.Handle(new GetTestimonialByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await _updateTestimonialCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
