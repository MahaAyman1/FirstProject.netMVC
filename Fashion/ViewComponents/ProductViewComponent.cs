using Fashion.Data;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.ViewComponents
{
    public class ProductViewComponent:ViewComponent

    {
        private FDbContext Db;
        public ProductViewComponent(FDbContext _db)
        {
            Db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(Db.Products.OrderByDescending(x => x.ProductId).ToList());
        }
    }
}
