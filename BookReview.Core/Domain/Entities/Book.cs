using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Core.Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string Category { get; set; } = "";
        public string Summary { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
