using System;
using System.ComponentModel.DataAnnotations;

namespace BookManager.Models
{
    public class Book
    {
        public int Id { get; set; } // Unique
        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Author { get; set; }
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        public bool Available { get; set; }
    }
}
