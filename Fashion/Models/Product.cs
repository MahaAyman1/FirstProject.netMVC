using System.ComponentModel.DataAnnotations.Schema;

namespace Fashion.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public string ProductDescription { get; set; }
        public Features ProductFeature { get; set; }

        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        public bool IspPopular { get; set; }

        public string ?ProductImg { get; set; }
        [NotMapped]

        public IFormFile ?formFile { get; set; }


        public enum Features
        {
            New, Discounted, Trending
        }

    }
}
