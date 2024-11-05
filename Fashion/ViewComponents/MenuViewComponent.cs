using Fashion.Data;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private FDbContext Db;
        public MenuViewComponent(FDbContext _db)
        {
            Db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(Db.Menus.ToList());
        }


    }
}
