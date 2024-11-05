using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fashion.Models
{
    public class Slider
    {
        public int SliderID { get; set; }
        public string SliderTitle { get; set; }

        public string ?SliderImg { get; set; }

        public string SliderText { get; set; }
        public string SliderLink { get; set; }
        [DataType(DataType.MultilineText)]

        public string SliderDes{ get; set; }

        [NotMapped]
        public IFormFile ?formFile { get; set; }



    }
}
