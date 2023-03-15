using System.ComponentModel.DataAnnotations;

namespace YemekKitabı.Models
{
    public class Cook
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Recipe { get; set; }
        public DateOnly Date { get; set; }
        public string Materials { get; set; }
        public Category Category { get; set; }
        public Country Country { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
