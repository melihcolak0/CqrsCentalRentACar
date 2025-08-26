using _10PC_Cqrs.CQRSPattern.Handlers.FeatureHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _10PC_Cqrs.ViewComponents
{
    public class _DefaultFeatureComponent : ViewComponent
    {
        private readonly GetFeatureQueryHandler _handler;

        public _DefaultFeatureComponent(GetFeatureQueryHandler handler)
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
