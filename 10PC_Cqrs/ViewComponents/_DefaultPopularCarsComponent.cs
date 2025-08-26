using _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.ServiceHandlers;
using Microsoft.AspNetCore.Mvc;

namespace _10PC_Cqrs.ViewComponents
{
    public class _DefaultPopularCarsComponent : ViewComponent
    {
        private readonly GetCarQueryHandler _handler;

        public _DefaultPopularCarsComponent(GetCarQueryHandler handler)
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
