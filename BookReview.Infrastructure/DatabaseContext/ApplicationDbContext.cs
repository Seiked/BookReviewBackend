using BookReview.Core.Domain.Entities;
using BookReview.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    Category = "Programming",
                    Summary = "A Handbook of Agile Software Craftsmanship"
                },
                new Book
                {
                    Id = 2,
                    Title = "The Pragmatic Programmer",
                    Author = "Andrew Hunt & David Thomas",
                    Category = "Programming",
                    Summary = "Your Journey to Mastery"
                },
                new Book
                {
                    Id = 3,
                    Title = "1984",
                    Author = "George Orwell",
                    Category = "Dystopia",
                    Summary = "A novel about a dystopian future and government surveillance"
                },
                new Book
                {
                    Id = 4,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Category = "Classic",
                    Summary = "A novel about racial injustice in the Deep South"
                },
                new Book
                {
                    Id = 5,
                    Title = "Atomic Habits",
                    Author = "James Clear",
                    Category = "Self-Help",
                    Summary = "An Easy & Proven Way to Build Good Habits & Break Bad Ones"
                },
                new Book
                {
                    Id = 6,
                    Title = "Sapiens: A Brief History of Humankind",
                    Author = "Yuval Noah Harari",
                    Category = "History",
                    Summary = "Explores the history and impact of Homo sapiens on the world"
                }
            );
        }
    }
}
