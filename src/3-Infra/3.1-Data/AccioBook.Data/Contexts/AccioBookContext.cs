using AccioBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccioBook.Data.Contexts
{
    public class AccioBookContext: DbContext
    {
        public DbSet<Book> Books { get; set; }

        public AccioBookContext(DbContextOptions<AccioBookContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
