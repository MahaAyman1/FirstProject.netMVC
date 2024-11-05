using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fashion.Models;

namespace Fashion.Data
{
    public class FDbContext: IdentityDbContext
    {
        public FDbContext(DbContextOptions<FDbContext> Options) : base(Options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Customer> Customers { get; set; }   
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<FAQ> fAQs { get; set; }    



    }
}
