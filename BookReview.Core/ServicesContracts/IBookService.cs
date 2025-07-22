using BookReview.Core.Domain.Entities;
using BookReview.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Core.ServicesContracts
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooksAsync();
        Task<BookDetailDto?> GetBookByIdAsync(int id);
        Task<List<BookDto>> SearchBooksAsync(string query);
        Task<List<BookDto>> GetBooksByCategoryAsync(string category);
    }
}
