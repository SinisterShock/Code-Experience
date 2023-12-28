using Microsoft.AspNetCore.Mvc;

namespace LabW02TB.ViewComponents
{
    public class TimeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var time = DateTime.Now;
            return View(time);
        }
    }
}
