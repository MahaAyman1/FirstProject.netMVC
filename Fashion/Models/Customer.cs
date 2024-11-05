using System.ComponentModel.DataAnnotations.Schema;

namespace Fashion.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string CustomerComment { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public string ?CustomerImg { get; set; }

        [NotMapped]
        public IFormFile ?formFile { get; set; }



    }
}
