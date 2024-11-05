using Fashion.Data;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.ViewComponents
{
    public class FAQViewComponent:ViewComponent
    {
        private FDbContext Db;
        public FAQViewComponent(FDbContext _db)
        {
            Db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(Db.fAQs.ToList());
        }

    }
}
