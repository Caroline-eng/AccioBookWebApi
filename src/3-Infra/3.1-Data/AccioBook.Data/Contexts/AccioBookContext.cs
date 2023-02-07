using AccioBook.Data.Models.Mapping;
using AccioBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccioBook.Data.Contexts
{
    public class AccioBookContext: DbContext
    {
        public DbSet<Access> Access { get; set; }        
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorSearch> AuthorsSearch { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookSearch> BooksSearch { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<GenreSearch> GenresSearch { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WishList> WishList { get; set; }
        public AccioBookContext(DbContextOptions<AccioBookContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccessMap());
            modelBuilder.ApplyConfiguration(new AuthorMap());
            modelBuilder.ApplyConfiguration(new AuthorSearchMap());
            modelBuilder.ApplyConfiguration(new BookMap());
            modelBuilder.ApplyConfiguration(new BookSearchMap());
            modelBuilder.ApplyConfiguration(new EditionMap());
            modelBuilder.ApplyConfiguration(new GenreMap());
            modelBuilder.ApplyConfiguration(new GenreSearchMap());
            modelBuilder.ApplyConfiguration(new LanguageMap());
            modelBuilder.ApplyConfiguration(new PublisherMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new WishListMap());

        }
    }
}
