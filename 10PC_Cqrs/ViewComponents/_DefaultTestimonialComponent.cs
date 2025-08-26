using _10PC_Cqrs.CQRSPattern.Handlers.ServiceHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.TestimonialHandlers;
using Microsoft.AspNetCore.Mvc;

namespace _10PC_Cqrs.ViewComponents
{
    public class _DefaultTestimonialComponent : ViewComponent
    {
        private readonly GetTestimonialQueryHandler _handler;

        public _DefaultTestimonialComponent(GetTestimonialQueryHandler handler)
        {
            _handler = handler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _handler.Handle();
            return View(values);
        }
    }
}
