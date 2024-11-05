using Fashion.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fashion.ViewComponents
{
    public class SliderViewComponent:ViewComponent
    {
        private FDbContext Db;
        public SliderViewComponent(FDbContext _db)
        {
            Db = _db;
        }
        public IViewComponentResult Invoke()
        {
            var sliders = Db.Sliders.ToList();
            return View(sliders);
          
        }
    }
}
