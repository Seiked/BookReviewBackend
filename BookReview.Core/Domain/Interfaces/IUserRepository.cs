using BookReview.Core.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Core.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetUserWithReviewsByIdAsync(int userId);
    }
}
