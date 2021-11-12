using MinimalAPi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);
// establishing DbContext through builder method
builder.Services.AddDbContext<BookContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("BookDb")));
var app = builder.Build();

app.MapGet("/", () => "Hello Multiverse!");
//------------------------------------------------
//CRUD OPS BELOW
//-------------------------------------------------
//Read/GET
app.MapGet("/api/books", async (BookContext db) => await db.Books.ToListAsync());
//Read/GET
app.MapGet("api/books/{id}", async (BookContext db, int id) => await db.Books.FindAsync(id));

//Create/POST
app.MapPost("/api/books", async (BookContext db, Book book) =>
{
    await db.Books.AddAsync(book);
    await db.SaveChangesAsync();
    Results.Accepted();
});

//Update/Edit
app.MapPut("api/books/{id}", async (BookContext db, int id, Book book) =>
{
    if (id != book.Id) return Results.BadRequest();
    db.Update(book);
    await db.SaveChangesAsync();

    return Results.NoContent();
});


//DELETE
app.MapDelete("api/books/{id}", async (BookContext db, int id) =>
{
    var book = await db.Books.FindAsync(id);
    if (book == null) return Results.NotFound();

    db.Books.Remove(book);
    await db.SaveChangesAsync();

    return Results.NoContent();

});
app.Run();
