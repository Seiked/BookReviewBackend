using BookReview.Core.Domain.Identity;
using BookReview.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Core.ServicesContracts
{
    public interface IUserService
    {
        Task<UserProfileDto?> GetCurrentUserProfileAsync();
    }
}
