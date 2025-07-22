using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Core.DTO
{
    public class CreateReviewDto
    {
        public int BookId { get; set; }
        public int Rating { get; set; } // 1 - 5
        public string Comment { get; set; } = string.Empty;
    }
}
