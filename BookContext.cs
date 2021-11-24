using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPi
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
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
        public string Description { get; set; } = string.Empty;

        //public string ImageName { get; set; } = string.Empty ;

        [NotMapped]
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }

        public byte[]? ImageData { get; set; }
        public string? ImageType { get; set; }
    }
}
