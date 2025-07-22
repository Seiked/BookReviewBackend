using BookReview.Core.Domain.Entities;
using BookReview.Core.Domain.Interfaces;
using BookReview.Core.DTO;
using BookReview.Core.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IBookRepository _bookRepository;

        public ReviewService(IReviewRepository reviewRepository, IBookRepository bookRepository)
        {
            _reviewRepository = reviewRepository;
            _bookRepository = bookRepository;
        }

        public async Task CreateReviewAsync(CreateReviewDto dto, string userId)
        {
            var book = await _bookRepository.GetByIdAsync(dto.BookId);
            if (book == null) throw new Exception("Book not found.");

            var review = new Review
            {
                BookId = dto.BookId,
                UserId = int.Parse(userId),
                Comment = dto.Comment,
                Rating = dto.Rating,
                CreatedAt = DateTime.UtcNow
            };

            await _reviewRepository.AddAsync(review);
        }

        public async Task UpdateReviewAsync(int id, UpdateReviewDto dto, string userId)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null || review.UserId != int.Parse(userId))
                throw new UnauthorizedAccessException("You can't edit this review.");

            review.Comment = dto.Comment;
            review.Rating = dto.Rating;

            await _reviewRepository.UpdateAsync(review);
        }

        public async Task DeleteReviewAsync(int id, string userId)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null || review.UserId != int.Parse(userId))
                throw new UnauthorizedAccessException("You can't delete this review.");

            await _reviewRepository.DeleteAsync(review);
        }
    }
}
