using BookReview.Core.Domain.Entities;
using BookReview.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Core.ServicesContracts
{
    public interface IReviewService
    {
        Task CreateReviewAsync(CreateReviewDto dto, string userId);
        Task UpdateReviewAsync(int id, UpdateReviewDto dto, string userId);
        Task DeleteReviewAsync(int id, string userId);
    }
}
