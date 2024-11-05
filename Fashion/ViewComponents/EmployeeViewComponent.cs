using Fashion.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fashion.ViewComponents
{
    public class EmployeeViewComponent:ViewComponent
    {
        private FDbContext Db;
        public EmployeeViewComponent(FDbContext _db)
        {
            Db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(Db.Employees.Include(c => c.Department).ToList());
        }

    }
}
