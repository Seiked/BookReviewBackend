using BookReview.Core.Domain.Identity;
using BookReview.Core.Domain.Interfaces;
using BookReview.Core.DTO;
using BookReview.Core.ServicesContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Core.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserProfileDto?> GetCurrentUserProfileAsync()
        {
            var userIdString = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
                return null;

            var user = await _userRepository.GetUserWithReviewsByIdAsync(userId);
            if (user == null)
                return null;

            return new UserProfileDto
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                UserName = user.UserName,
                FullName = user.FullName,
                Photo = user.PhotoUrl,
                Reviews = user.Reviews?.Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Comment = r.Comment,
                    Rating = r.Rating,
                    CreatedAt = r.CreatedAt,
                    UserName = r.User.UserName ?? "",
                    PhotoUrl = r.User.PhotoUrl ?? "",
                    UserId = r.User.Id.ToString(),
                    BookId = r.Book.Id.ToString(),
                    BookName = r.Book.Title
                }).ToList() ?? new List<ReviewDto>()
            };
        }
    }
}