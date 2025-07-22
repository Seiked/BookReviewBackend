using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Core.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int Rating { get; set; } 
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string BookName { get; set; } = string.Empty;
        public string BookId { get; set; } = string.Empty;
    }
}
