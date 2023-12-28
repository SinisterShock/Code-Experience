using Microsoft.AspNetCore.Mvc;

namespace RazorLec.NewFolder
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
