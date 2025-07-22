using BookReview.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Core.Domain.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; } = null!;
        public string PhotoUrl { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
