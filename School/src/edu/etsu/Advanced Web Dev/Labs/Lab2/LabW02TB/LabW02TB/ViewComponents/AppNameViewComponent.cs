using LabW02TB.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabW02TB.ViewComponents
{
    public class AppNameViewComponent : ViewComponent
    {
        private readonly IConfiguration _config;

        public AppNameViewComponent(IConfiguration config)
        {
            _config = config;
        }
        public IViewComponentResult Invoke()
        {
            var model = new AppNameVM
            {
                AppName = _config.GetValue<string>("AppName") ?? string.Empty
            };
            return View(model);
        }
    }
}
