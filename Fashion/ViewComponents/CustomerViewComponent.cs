using Fashion.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fashion.ViewComponents
{
    public class CustomerViewComponent : ViewComponent
    {
        private FDbContext Db;
        public CustomerViewComponent(FDbContext _db)
        {
            Db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(Db.Customers.Include(c => c.Department).ToList());
        }

    }
}
