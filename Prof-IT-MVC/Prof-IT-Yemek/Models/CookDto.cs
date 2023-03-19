namespace YemekKitabı.Models
{
    public class CookDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Recipe { get; set; }
        public DateOnly Date { get; set; }
        public string Materials { get; set; }
        public string CategoryName { get; set; }
        public string CountryName { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}
