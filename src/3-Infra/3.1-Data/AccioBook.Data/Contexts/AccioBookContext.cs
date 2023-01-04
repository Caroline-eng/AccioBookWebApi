using AccioBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccioBook.Data.Contexts
{
    public class AccioBookContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorSearch> AuthorsSearch { get; set; }
        public DbSet<BookSearch> BooksSearch { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WishList> WishList { get; set; }
        public AccioBookContext(DbContextOptions<AccioBookContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
