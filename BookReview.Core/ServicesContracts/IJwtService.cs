using BookReview.Core.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Core.ServicesContracts
{
    public interface IJwtService
    {
        Task<string> GenerateToken(ApplicationUser user);
    }
}
