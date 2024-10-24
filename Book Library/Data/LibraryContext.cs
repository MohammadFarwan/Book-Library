using Book_Library.Data;
using Microsoft.EntityFrameworkCore;

namespace Book_Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        // Add Tables
        public DbSet<Book> Books { get; set; }
    }
}
