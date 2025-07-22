using BookReview.Core.Domain.Entities;
using BookReview.Core.Domain.Interfaces;
using BookReview.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.Include(b => b.Reviews).ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.Reviews)
                .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Book>> SearchAsync(string query)
        {
            return await _context.Books
                .Where(b => b.Title.Contains(query) || b.Author.Contains(query) || b.Category.Contains(query))
                .ToListAsync();
        }

        public async Task<List<Book>> FilterByCategoryAsync(string category)
        {
            return await _context.Books.Where(b => b.Category == category).ToListAsync();
        }
    }
}
