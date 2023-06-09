﻿using System.ComponentModel.DataAnnotations;

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
        public int CategoryId { get; set; }
        public int CountryId { get; set; }

    }
}
