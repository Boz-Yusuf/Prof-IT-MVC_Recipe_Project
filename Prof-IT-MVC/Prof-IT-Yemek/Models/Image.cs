using System.ComponentModel.DataAnnotations;

namespace YemekKitabı.Models
{
    public class Image
    {
        public int CookId { get; set; }
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }     
    }
}
