using Microsoft.EntityFrameworkCore;

namespace MinimalAPi
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
    //Book Model 
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
        public string  Description { get; set; } = string.Empty;
    }
}
