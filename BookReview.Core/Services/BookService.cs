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
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Category = b.Category,
                Summary = b.Summary
            }).ToList();
        }

        public async Task<BookDetailDto?> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return null;

            return new BookDetailDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Category = book.Category,
                Summary = book.Summary,
                Reviews = book.Reviews
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    CreatedAt = r.CreatedAt,
                    UserName = r.User.UserName ?? "",
                    PhotoUrl = r.User.PhotoUrl ?? "",
                    UserId = r.User.Id.ToString()
                }).ToList()
            };
        }

        public async Task<List<BookDto>> SearchBooksAsync(string query)
        {
            var books = await _bookRepository.SearchAsync(query);
            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Category = b.Category,
                Summary = b.Summary
            }).ToList();
        }

        public async Task<List<BookDto>> GetBooksByCategoryAsync(string category)
        {
            var books = await _bookRepository.FilterByCategoryAsync(category);
            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Category = b.Category,
                Summary = b.Summary
            }).ToList();
        }
    }
}
