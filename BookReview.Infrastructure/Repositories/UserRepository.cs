using BookReview.Core.Domain.Identity;
using BookReview.Core.Domain.Interfaces;
using BookReview.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApplicationUser?> GetUserWithReviewsByIdAsync(int userId)
        {
            return await _context.Users
                .Include(u => u.Reviews)
                .ThenInclude(b => b.Book)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
