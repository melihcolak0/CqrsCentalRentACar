using _10PC_Cqrs.CQRSPattern.Handlers.AboutHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.FeatureHandlers;
using Microsoft.AspNetCore.Mvc;

namespace _10PC_Cqrs.ViewComponents
{
    public class _DefaultAboutComponent : ViewComponent
    {
        private readonly GetAboutQueryHandler _handler;

        public _DefaultAboutComponent(GetAboutQueryHandler handler)
        {
            _handler = handler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _handler.Handle();

            var firstValue = values.FirstOrDefault();

            return View(firstValue);
        }
    }
}
