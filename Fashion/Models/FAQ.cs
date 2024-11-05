namespace Fashion.Models
{
    public class FAQ
    {
        public int Id { get; set; } 
        public string Question { get; set; }
        public string answer { get; set; }
        public bool IsGeneral { get; set; }

        public bool IsRelatedToPro  { get; set; }

    }
}
