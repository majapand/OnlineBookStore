using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Models;

namespace OnlineBookStore.Data
{
    public class OnlineBookStoreContext : DbContext
    {
        public OnlineBookStoreContext (DbContextOptions<OnlineBookStoreContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineBookStore.Models.Author> Author { get; set; } = default!;

        public DbSet<OnlineBookStore.Models.Book>? Book { get; set; }

        public DbSet<OnlineBookStore.Models.BookGenres>? BookGenres { get; set; }

        public DbSet<OnlineBookStore.Models.Genre>? Genre { get; set; }

        public DbSet<OnlineBookStore.Models.Review>? Review { get; set; }

        public DbSet<OnlineBookStore.Models.UserBooks>? UserBooks { get; set; }
    }
}
