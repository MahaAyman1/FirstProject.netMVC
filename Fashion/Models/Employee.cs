using System.ComponentModel.DataAnnotations.Schema;

namespace Fashion.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }    
        public string InstaUrl { get; set; }
        public string LinkeUrl { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string ?EmployeeImg { get; set; }

        [NotMapped]
        public IFormFile ?formFile { get; set; }



    }
}
